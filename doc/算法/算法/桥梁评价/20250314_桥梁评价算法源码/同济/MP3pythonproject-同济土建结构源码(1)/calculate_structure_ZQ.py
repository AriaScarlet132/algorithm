import numpy as np
import pymysql
import pandas as pd
from sqlalchemy import create_engine
import method
import json
from datetime import *


def cal(TaskNO, DataSource_StartDate, DataSource_EndDate, ProjectID, conn, cursor, engine):
    # 定义数据库连接
    """
    conn = pymysql.Connect(host='121.41.10.16', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                           charset="utf8")
    cursor = conn.cursor()
    engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@121.41.10.16:3306/rcbi_model?charset=utf8")
    """
    task_no = TaskNO  # 任务号
    project_code = ProjectID  # 项目号

    # 提取设施清单信息
    sql = 'select * from tb_bridge_assessment_facilitylist where delete_flag=0 and project_code ="' + str(
        project_code) + '" and task_no = "' + task_no + '"'  # 根据project_code和task_no提取设施清单信息
    df_facilitylist = pd.read_sql(sql=sql, con=engine)
    # df_facilitylist.insert(2, 'task_no', task_no)  # 插入任务号
    df_facilitylist = df_facilitylist.drop('id', axis=1)  # 去掉id列
    df_facilitylist = df_facilitylist.drop('delete_flag', axis=1)  # 去掉delete_flag列

    # 定义材料退化与表观缺损
    clth = ['混凝土强度', '碳化', '保护层厚度', '钢筋锈蚀', '氯离子含量', '碱骨料反应', '钢梁—锈蚀']
    bgqs = ['混凝土裂缝', '蜂窝', '掉角', '空洞孔洞', '露筋', '涂层劣化']

    class Output():  # 定义输出类，方便后续输出，属性包含父类编码，父类名称，编码，名称，权重
        points = 100  # 初始化得分
        grade = 1

        def __init__(self, parent_code, parent_name, code, name):
            self.parent_code = parent_code
            self.parent_name = parent_name
            self.code = code
            self.name = name
            self.weight = get_weight_from_db(parent_code, code)
            self.delete_flag = 0

        def get_grade(self):
            if self.delete_flag == 0:
                self.grade = method.point_to_grade(self.points)
            else:
                self.points = 0
                self.grade = 0

    def get_data_from_db(sql):  # select数据
        df = pd.read_sql(sql=sql, con=engine)
        return df

    def write_data_to_db(dataframe, table_name):  # 写入数据库数据，写入前清空本任务号数据
        # sql = 'delete from ' + table_name + ' where task_no=\'' + task_no + '\' and project_code=\'' + project_code + '\''
        # cursor.execute(sql)
        # conn.commit()
        dataframe.to_sql(name=table_name, con=engine, if_exists='append', index=False, index_label=False)

    def get_weight_from_db_xls(parent_code, code_list):  # 从权重表格中提取权重数据——斜拉索系统
        sql4 = 'select * from ' + 'tb_bridge_assessment_weights' + ' where parent_code="' + parent_code + '" and project_code="ZQ"'
        df_weight = pd.read_sql(sql=sql4, con=engine)
        w = []
        for i in df_weight.index:
            w.append(df_weight[df_weight['code'].str.contains(code_list[i])]['weight'].values[0])
        return w

    def get_weight_from_db(parent_code, code_list):  # 从权重表格中提取权重数据
        sql4 = 'select * from ' + 'tb_bridge_assessment_weights' + ' where code="' + code_list + '" and project_code="ZQ"'
        df_weight = pd.read_sql(sql=sql4, con=engine)
        w = df_weight['weight'].values[0]
        return float(w)

    def weight_re_average(data_list):  # 根据delete_flag重新计算各部分权重
        weight1 = 0  # 待分配的权重
        weight2 = 0
        for i in range(len(data_list)):
            if data_list[i].delete_flag == 0:
                weight2 += data_list[i].weight
            else:
                weight1 += data_list[i].weight
        #  重新分配权重
        for i in range(len(data_list)):
            if data_list[i].delete_flag == 0:
                data_list[i].weight = data_list[i].weight / weight2
            else:
                data_list[i].weight = 0

    def facility_disease(code):  # 根据code提取构件病害列表
        sql = 'select * from tb_bridge_assessment_disease where facility_code =\'' + code + '\''
        df_disease = pd.read_sql(sql=sql, con=engine)
        disease = df_disease['disease_name'].values
        return disease

    def facility_classification(code, outputtable):  # 根据设施清单表，将构件分类至输出表内
        delete_flag = 0
        newdf = df_facilitylist[df_facilitylist['facility_code'].str.contains(code, regex=False)].copy()
        if newdf.empty:
            delete_flag = 1
        newdf['points'] = 100.0
        newdf['grade'] = 1
        write_data_to_db(newdf, outputtable)
        conn.commit()
        return delete_flag

    def facility_points(code, checkvaluetable, outputtable):  # 根据checkvalue记录，计算构件得分，并写入output表
        sql1 = 'select * from ' + checkvaluetable + ' where task_no="' + task_no + '" and project_code="' + project_code + '" and facility_code like "%%' + code + '%%"'  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        newdf = newdf.drop('id', axis=1)  # 去掉id列
        disease_list = facility_disease(code)  # 根据code去构件病害表中提取构件对应的病害
        for i in newdf.index:  # 遍历每条病害记录
            disease = newdf['disease'].values[i]  # disease为第i个病害json数组
            disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
            disease = json.loads(disease)  # json数组转化为python字典
            # 分辨材料退化与表观缺损病害
            grade_clth = []  # 初始化材料退化等级
            grade_bgqs = []  # 初始化表观缺损等级
            disease_copy = disease.copy()  # 复制病害列表，以去除材料退化，表观缺损病害
            for m in range(len(clth)):  # 遍历材料退化病害数组
                for key in disease_copy:  # 遍历disease字典
                    if clth[m] in key:  # 如果第m个材料退化在disease字典中
                        grade_clth.append(disease_copy[key])  # clth数组中增加disease中的等级
                        del disease[key]  # 删除disease中对应的材料退化项
            if grade_clth != []:
                grade_clth = max(grade_clth)  # 选取最高等级作为材料退化等级

            for m in range(len(bgqs)):  # 表观缺损，同材料退化部分
                for key in disease_copy:
                    name = bgqs[m]
                    if bgqs[m] in key:
                        grade_bgqs.append(disease_copy[key])
                        del disease[key]
            if grade_bgqs != []:
                grade_bgqs = max(grade_bgqs)

            grade = []
            if grade_clth != []:
                grade.append(grade_clth)
            if grade_bgqs != []:
                grade.append(grade_bgqs)

            for j in range(len(disease_list)):  # 对于构件对应的disease_list，遍历病害，添加等级
                try:
                    grade.append(disease[disease_list[j]])
                except:
                    continue
            DP = method.grade_dp(grade)  # 计算DP扣分值
            points = method.dp_points(DP)  # 计算单个构件得分值
            points = round(points, 3)
            # 修改output中对应构件得分
            facility_code = newdf['facility_code'].values[i]  # 获得构件编码
            sql2 = 'UPDATE  ' + outputtable + ' SET points=' + str(
                points) + ' WHERE facility_code=\'' + facility_code + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
            cursor.execute(sql2)
            conn.commit()
            grade = method.point_to_grade(points)
            sql3 = 'UPDATE  ' + outputtable + ' SET grade=' + str(
                grade) + ' WHERE facility_code=\'' + facility_code + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
            cursor.execute(sql3)
            conn.commit()
        conn.commit()

    def facility_bianquan(outputtable):  # 变权分析，总和构件得分
        sql = 'select points from ' + outputtable + ' where task_no=\'' + task_no + '\' and project_code=\'' + project_code + '\''
        df = pd.read_sql(sql=sql, con=engine)
        points = df['points'].values
        if len(points) != 0:
            point = method.bianquan(points)
        else:
            point = 100
        return point

    def facility(code, checkvaluetable, outputtable):  # 普通构件运行该函数
        delete_flag = facility_classification(code, outputtable)  # 根据编码，从设施清单表中提出对应设施，写入输出表中
        facility_points(code, checkvaluetable, outputtable)  # 根据checkvaluetable中的病害，计算各构件得分
        return delete_flag

    def facility_xls_classification():
        df_xls = df_facilitylist[df_facilitylist['facility_code'].str.contains('SSBXLS')]  # 根据编码，选出斜拉索构件
        df_xls = df_xls.copy()
        df_xls.rename(columns={'facility_code': 'xls_code', 'facility_name': 'xls_name'}, inplace=True)
        df_xls['xlsst_points'] = 100.0  # 初始化各部分得分
        df_xls['xlsst_grade'] = 1
        df_xls['xlsht_points'] = 100.0
        df_xls['xlsht_grade'] = 1
        df_xls['mgxt_points'] = 100.0
        df_xls['mgxt_grade'] = 1
        df_xls['jzxt_points'] = 100.0
        df_xls['jzxt_grade'] = 1
        df_xls['points'] = 100.0
        df_xls['grade'] = 1
        write_data_to_db(df_xls, 'tb_bridge_bgzk_xlsxt_output')  # 写入输出表格
        conn.commit()

    def facility_xls_points(code, checkvaluetable, index):  # 计算斜拉索各部分得分，并写入output表（已去重），并计算单根总分
        sql1 = 'select * from ' + checkvaluetable + ' where task_no="' + task_no + '" and project_code="' + project_code + '" '
        newdf = get_data_from_db(sql1)  # 从checkvaluetable中选出病害记录
        newdf = newdf.drop('id', axis=1)
        xls_code = newdf['xls_code'].values
        xls_code = list(set(xls_code))  # 筛选报病害的斜拉索编号
        disease_list = facility_disease(code)
        for i in range(len(xls_code)):
            data = newdf[newdf['xls_code'].str.contains(xls_code[i])]  # 筛选同一斜拉索的病害记录
            disease = data['disease'].values  # 筛选同一斜拉索的病害记录
            disease_df = pd.DataFrame()
            for j in range(len(disease)):  # 提取同一斜拉索不同构件（上下锚头）的病害记录
                newdisease = disease[j].replace('\'', '"')  # 单引号更换为双引号，以符合json.loads得到要求
                newdisease = json.loads(newdisease)
                newpd = pd.DataFrame([newdisease])
                disease_df = pd.concat([disease_df, newpd])
            grade = []
            for j in range(len(disease_list)):
                try:
                    grade.append(disease_df[disease_list[j]].max())
                except:
                    continue

            DP = method.grade_dp(grade)  # 计算DP扣分值
            points = method.dp_points(DP)  # 计算单个构件得分值
            points = round(points, 3)
            sql2 = 'UPDATE tb_bridge_bgzk_xlsxt_output  SET ' + index + '_points' + '=' + str(
                points) + ' WHERE xls_code=\'' + xls_code[
                       i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''
            cursor.execute(sql2)
            conn.commit()
            grade = method.point_to_grade(points)
            sql3 = 'UPDATE tb_bridge_bgzk_xlsxt_output  SET ' + index + '_grade' + '=' + str(
                grade) + ' WHERE xls_code=\'' + xls_code[
                       i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''
            cursor.execute(sql3)
            conn.commit()
        conn.commit()

    def facility_xls_total():  # 斜拉索部分运行该函数
        facility_xls_classification()
        facility_xls_points('SSBSMG', 'tb_bridge_bgzk_xlsxt_mgxt_checkvalue', 'mgxt')  # 三个参数分别为构件编码，对应病害数据表，对应输出编码
        facility_xls_points('SSBXJZ', 'tb_bridge_bgzk_xlsxt_jzxt_checkvalue', 'jzxt')
        facility_xls_points('SSBXHT', 'tb_bridge_bgzk_xlsxt_xlsht_checkvalue', 'xlsht')
        facility_xls_points('SSBXLS', 'tb_bridge_bgzk_xlsxt_xls_checkvalue', 'xlsst')
        # 计算单根总分
        code_list = ['XLSST', 'XLSHT', 'MGXT', 'JZXT']
        w = get_weight_from_db_xls('XLSXT', code_list)  # 提取斜拉索系统部分的权重
        sql1 = 'select * from tb_bridge_bgzk_xlsxt_output where task_no="' + task_no + '" and project_code="' + project_code + '" '
        datadf = get_data_from_db(sql1)
        for i in datadf.index:
            points = [datadf['xlsst_points'].values[i], datadf['xlsht_points'].values[i],
                      datadf['mgxt_points'].values[i],
                      datadf['jzxt_points'].values[i]]  # 提取每根斜拉索对应的索体、护套、锚固系统、减振系统得分
            point = method.lishudu(points, w)  # 计算单根斜拉索总分
            sql2 = 'UPDATE tb_bridge_bgzk_xlsxt_output  SET points=' + str(
                point) + ' WHERE xls_code=\'' + datadf['xls_code'].values[
                       i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 更新对应输出表格
            cursor.execute(sql2)
            conn.commit()
            grade = method.point_to_grade(point)
            sql3 = 'UPDATE tb_bridge_bgzk_xlsxt_output  SET grade=' + str(
                grade) + ' WHERE xls_code=\'' + datadf['xls_code'].values[
                       i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 更新对应输出表格
            cursor.execute(sql3)
            conn.commit()
        # 计算总分
        sql3 = 'select points from tb_bridge_bgzk_xlsxt_output where project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 选取所有斜拉索的得分
        df = pd.read_sql(sql=sql3, con=engine)
        points = df['points'].values
        point = method.bianquan(points)  # 计算斜拉索总体得分
        conn.commit()
        return point

    def get_output_list_jc():  # 获得各层次输出得分数组
        total = Output('0', '0', 'TOTAL', '总体技术状况得分')  # 属性分别为父类编码，父类名称，编码，名称。权重自动数据库读取。下同
        # 总体技术状况下属
        lxxn = Output('TOTAL', '总体技术状况得分', 'LXXN', '力学性能')
        bgzk = Output('TOTAL', '总体技术状况得分', 'BGZK', '表观状况')
        yyhj = Output('TOTAL', '总体技术状况得分', 'YYHJ', '运营环境')

        # 力学性能下属
        # 计算结构频率得分
        jgpl = Output('LXXN', '总体技术状况得分-力学性能', 'JGPL', '结构频率')
        delete_flag1 = facility('SAV', 'tb_bridge_lxxn_jgpl_checkvalue', 'tb_bridge_lxxn_jgpl_output')
        delete_flag2 = facility('SAH', 'tb_bridge_lxxn_jgpl_checkvalue', 'tb_bridge_lxxn_jgpl_output')
        delete_flag3 = facility('SAW', 'tb_bridge_lxxn_jgpl_checkvalue', 'tb_bridge_lxxn_jgpl_output')
        jgpl.delete_flag = min(delete_flag3, delete_flag2, delete_flag1)
        jgpl.points = facility_bianquan('tb_bridge_lxxn_jgpl_output')  # 计算结构频率总分
        jgpl.get_grade()  # 获得结构频率等级

        jhbw = Output('LXXN', '总体技术状况得分-力学性能', 'JHBW', '结构几何变位')
        # 计算基础位移得分
        jcwy = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'JCWY', '基础沉降')
        delete_flag1 = facility('SRJ02', 'tb_bridge_lxxn_jhbw_jcwy_checkvalue', 'tb_bridge_lxxn_jhbw_jcwy_output')
        delete_flag2 = facility('SRJ03', 'tb_bridge_lxxn_jhbw_jcwy_checkvalue', 'tb_bridge_lxxn_jhbw_jcwy_output')
        delete_flag3 = facility('SRJ07', 'tb_bridge_lxxn_jhbw_jcwy_checkvalue', 'tb_bridge_lxxn_jhbw_jcwy_output')
        delete_flag4 = facility('SRJ109', 'tb_bridge_lxxn_jhbw_jcwy_checkvalue', 'tb_bridge_lxxn_jhbw_jcwy_output')
        delete_flag5 = facility('SRJ12', 'tb_bridge_lxxn_jhbw_jcwy_checkvalue', 'tb_bridge_lxxn_jhbw_jcwy_output')
        jcwy.delete_flag = min(delete_flag5, delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        jcwy.get_grade()

        # 计算塔顶位移得分
        tdwy = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'TDWY', '塔墩倾斜')
        delete_flag1 = facility('SQHT', 'tb_bridge_lxxn_jhbw_tdwy_checkvalue', 'tb_bridge_lxxn_jhbw_tdwy_output')
        delete_flag2 = facility('SQWT', 'tb_bridge_lxxn_jhbw_tdwy_checkvalue', 'tb_bridge_lxxn_jhbw_tdwy_output')
        delete_flag3 = facility('S202110', 'tb_bridge_lxxn_jhbw_tdwy_checkvalue', 'tb_bridge_lxxn_jhbw_tdwy_output')
        tdwy.delete_flag = min(delete_flag3, delete_flag2, delete_flag1)
        tdwy.points = facility_bianquan('tb_bridge_lxxn_jhbw_tdwy_output')
        tdwy.get_grade()

        # 计算主梁线形得分
        zlxx = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'ZLXX', '主梁线形')
        delete_flag1 = facility('SRJ05', 'tb_bridge_lxxn_jhbw_zlxx_checkvalue', 'tb_bridge_lxxn_jhbw_zlxx_output')
        delete_flag2 = facility('SRJ09', 'tb_bridge_lxxn_jhbw_zlxx_checkvalue', 'tb_bridge_lxxn_jhbw_zlxx_output')
        delete_flag3 = facility('SRJ04', 'tb_bridge_lxxn_jhbw_zlxx_checkvalue', 'tb_bridge_lxxn_jhbw_zlxx_output')
        delete_flag4 = facility('SRJ100', 'tb_bridge_lxxn_jhbw_zlxx_checkvalue', 'tb_bridge_lxxn_jhbw_zlxx_output')
        zlxx.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        zlxx.points = facility_bianquan('tb_bridge_lxxn_jhbw_zlxx_output')
        zlxx.get_grade()
        jhbw.points = min(jcwy.points, tdwy.points, zlxx.points)  # 综合基础位移、塔顶位移、主梁线形得分，取最小值作为几何变位得分
        jhbw.get_grade()
        # jhbw.delete_flag += jcwy.delete_flag + tdwy.delete_flag + zlxx.delete_flag

        # 计算斜拉索索力得分
        xlssl = Output('LXXN', '总体技术状况得分-力学性能', 'XLSSL', '斜拉索索力')
        xlssl.delete_flag = facility('SSZ', 'tb_bridge_lxxn_xlssl_checkvalue', 'tb_bridge_lxxn_xlssl_output')
        xlssl.points = facility_bianquan('tb_bridge_lxxn_xlssl_output')
        xlssl.get_grade()

        # 计算结构应力得分
        jgyl = Output('LXXN', '总体技术状况得分-力学性能', 'JGYL', '结构应力')
        jgpl.delete_flag = facility('SEW', 'tb_bridge_lxxn_jgyl_checkvalue', 'tb_bridge_lxxn_jgyl_output')
        jgyl.points = facility_bianquan('tb_bridge_lxxn_jgyl_output')
        jgyl.get_grade()

        # 计算伸缩缝位移得分
        sszzwy = Output('LXXN', '总体技术状况得分-力学性能', 'SSZZWY', '伸缩装置位移')
        sszzwy.delete_flag = facility('SDW', 'tb_bridge_lxxn_sszz_checkvalue', 'tb_bridge_lxxn_sszz_output')
        sszzwy.points = facility_bianquan('tb_bridge_lxxn_sszz_output')
        sszzwy.get_grade()

        # 计算支座位移得分
        zzwy = Output('LXXN', '总体技术状况得分-力学性能', 'ZZWY', '支座位移')
        delete_flag1 = facility('QJJ', 'tb_bridge_lxxn_zzwy_checkvalue', 'tb_bridge_lxxn_zzwy_output')
        delete_flag2 = facility('WYJ', 'tb_bridge_lxxn_zzwy_checkvalue', 'tb_bridge_lxxn_zzwy_output')
        zzwy.delete_flag = min(delete_flag1, delete_flag2)
        zzwy.points = facility_bianquan('tb_bridge_lxxn_zzwy_output')
        zzwy.get_grade()

        # 表观状况下属
        # 计算索塔得分
        st = Output('BGZK', '总体技术状况得分-表观状况', 'ST', '索塔系统')
        st.delete_flag = facility('SSBSTT', 'tb_bridge_bgzk_stxt_st_checkvalue', 'tb_bridge_bgzk_stxt_st_output')
        st.points = facility_bianquan('tb_bridge_bgzk_stxt_st_output')
        st.get_grade()

        # 计算斜拉索系统得分
        xlsxt = Output('BGZK', '总体技术状况得分-表观状况', 'XLSXT', '斜拉索系统')
        xlsxt.points = facility_xls_total()
        xlsxt.get_grade()

        # 计算主梁系统得分
        zl = Output('BGZK', '总体技术状况得分-表观状况', 'ZL', '主梁系统')
        delete_flag1 = facility('SSBGZL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag2 = facility('SSBGXZ', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag3 = facility('SSBGHL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag4 = facility('SSBYLL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        zl.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        zl.points = facility_bianquan('tb_bridge_bgzk_zlxt_zl_output')
        zl.get_grade()

        # 计算下部结构
        xbjg = Output('BGZK', '总体技术状况得分-表观状况', 'XBJG', '下部结构')

        # 计算基础承台得分
        jcct = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'JCCT', '基础承台')
        jcct.delete_flag = facility('SXBJCC', 'tb_bridge_bgzk_xbjg_jcct_checkvalue', 'tb_bridge_bgzk_xbjg_jcct_output')
        jcct.points = facility_bianquan('tb_bridge_bgzk_xbjg_jcct_output')
        jcct.get_grade()

        # 计算桥墩得分
        qd = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'QD', '桥墩')
        delete_flag1 = facility('SXBQGL', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 盖梁
        delete_flag2 = facility('SXBQDS', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 桥墩身
        qd.delete_flag = min(delete_flag2, delete_flag1)
        qd.points = facility_bianquan('tb_bridge_bgzk_xbjg_qd_output')
        qd.get_grade()

        # 计算桥台得分
        qt = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'QT', '桥台')
        delete_flag1 = facility('SXBQTS', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 台身
        delete_flag2 = facility('SXBQTM', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 台帽
        qt.delete_flag = min(delete_flag2, delete_flag1)
        qt.points = facility_bianquan('tb_bridge_bgzk_xbjg_qt_output')
        qt.get_grade()

        #  重新分配下部结构权重
        weight_re_average([jcct, qd, qt])
        xbjg.delete_flag = min(jcct.delete_flag, qd.delete_flag, qt.delete_flag)
        xbjg.points = method.lishudu([jcct.points, qd.points, qt.points], [jcct.weight, qd.weight, qt.weight])
        xbjg.get_grade()

        # 支座及限位装置下属
        zzznq = Output('BGZK', '总体技术状况得分-表观状况', 'ZZZNQ', '支座及限位装置')

        znq = Output('ZZZNQ', '总体技术状况得分-表观状况-支座与限位装置', 'ZNQ', '主梁阻尼器')
        delete_flag1 = facility('SSBZZQ', 'tb_bridge_bgzk_zzxt_znq_checkvalue', 'tb_bridge_bgzk_zzxt_znq_output')  # 阻尼器
        delete_flag2 = facility('SSBZXK', 'tb_bridge_bgzk_zzxt_znq_checkvalue', 'tb_bridge_bgzk_zzxt_znq_output')  # 限位块
        znq.delete_flag = min(delete_flag2, delete_flag1)
        znq.points = facility_bianquan('tb_bridge_bgzk_zzxt_znq_output')
        znq.get_grade()

        zz = Output('ZZZNQ', '总体技术状况得分-表观状况-支座与限位装置', 'ZZ', '支座')
        delete_flag1 = facility('SSBPXZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue', 'tb_bridge_bgzk_zzxt_zz_output')
        delete_flag2 = facility('SSBGZZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue', 'tb_bridge_bgzk_zzxt_zz_output')
        zz.delete_flag = min(delete_flag2, delete_flag1)
        zz.points = facility_bianquan('tb_bridge_bgzk_zzxt_zz_output')
        zz.get_grade()

        weight_re_average([znq, zz])
        zzznq.delete_flag = min(znq.delete_flag, zz.delete_flag)
        zzznq.points = method.lishudu([znq.points, zz.points], [znq.weight, zz.weight])
        zzznq.get_grade()

        # 桥面系下属
        qmx = Output('BGZK', '总体技术状况得分-表观状况', 'QMX', '桥面系')

        qmpz = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'QMPZ', '桥面铺装')
        qmpz.delete_flag = facility('SQMLQP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue', 'tb_bridge_bgzk_qmx_qmpz_output')
        qmpz.points = facility_bianquan('tb_bridge_bgzk_qmx_qmpz_output')
        qmpz.get_grade()

        rxd = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'RXD', '人行道')
        rxd.delete_flag = facility('SQMRXD', 'tb_bridge_bgzk_qmx_rxd_checkvalue', 'tb_bridge_bgzk_qmx_rxd_output')
        rxd.points = facility_bianquan('tb_bridge_bgzk_qmx_rxd_output')
        rxd.get_grade()

        sszz = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'SSZZ', '伸缩装置')
        delete_flag1 = facility('SQMMSF', 'tb_bridge_bgzk_qmx_sszz_checkvalue', 'tb_bridge_bgzk_qmx_sszz_output')
        delete_flag2 = facility('SQMLXF', 'tb_bridge_bgzk_qmx_sszz_checkvalue', 'tb_bridge_bgzk_qmx_sszz_output')
        sszz.delete_flag = min(delete_flag2, delete_flag1)
        sszz.points = facility_bianquan('tb_bridge_bgzk_qmx_sszz_output')
        sszz.get_grade()

        weight_re_average([qmpz, rxd, sszz])
        qmx.delete_flag = min(qmpz.delete_flag, rxd.delete_flag, sszz.delete_flag)
        qmx.points = method.lishudu([rxd.points, sszz.points, qmpz.points],
                                    [rxd.weight, sszz.weight, qmpz.weight])  # 根据隶属度方法计算桥面系得分，下同
        qmx.get_grade()

        # 运营环境下属
        czczfx = Output('YYHJ', '总体技术状况得分-运营环境', 'CZCZFX', '船撞车撞风险')
        delete_flag1 = facility('SXBJCC', 'tb_bridge_bgzk_xbjg_jcct_checkvalue',
                                'tb_bridge_bgzk_xbjg_jcct_output')  # 基础承台防撞
        delete_flag2 = facility('SSBGZL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')  # 主梁防撞
        czczfx.delete_flag = min(delete_flag2, delete_flag1)
        czczfx.points = facility_bianquan('tb_bridge_yyhj_czczfx_output')
        czczfx.get_grade()

        fs = Output('YYHJ', '总体技术状况得分-运营环境', 'FS', '风速')
        fs.delete_flag = facility('SWST', 'tb_bridge_yyhj_fs_checkvalue', 'tb_bridge_yyhj_fs_output')
        fs.points = facility_bianquan('tb_bridge_yyhj_fs_output')
        fs.get_grade()

        jtl = Output('YYHJ', '总体技术状况得分-运营环境', 'JTL', '交通量')
        jtl.delete_flag = facility('SCS', 'tb_bridge_yyhj_jtl_checkvalue', 'tb_bridge_yyhj_jtl_output')
        jtl.points = facility_bianquan('tb_bridge_yyhj_jtl_output')
        jtl.get_grade()

        qmzjd = Output('YYHJ', '总体技术状况得分-运营环境', 'QMZJD', '桥面整洁度')
        qmzjd.delete_flag = facility('SQMLQP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue', 'tb_bridge_yyhj_qmzjd_output')
        qmzjd.points = facility_bianquan('tb_bridge_yyhj_qmzjd_output')
        qmzjd.get_grade()

        wd = Output('YYHJ', '总体技术状况得分-运营环境', 'WD', '温度')
        delete_flag1 = facility('STHT101', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        delete_flag2 = facility('STHT201', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        delete_flag3 = facility('STH0501', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        wd.delete_flag = min(delete_flag3, delete_flag2, delete_flag1)
        wd.points = facility_bianquan('tb_bridge_yyhj_wd_output')
        wd.get_grade()

        #  重新分配运营环境下属权重
        weight_re_average([czczfx, fs, jtl, qmzjd, wd])
        yyhj.delete_flag = min(jtl.delete_flag, qmzjd.delete_flag, wd.delete_flag, czczfx.delete_flag, fs.delete_flag)
        yyhj.points = method.lishudu([jtl.points, qmzjd.points, wd.points, czczfx.points, fs.points],
                                     [jtl.weight, qmzjd.weight, wd.weight, czczfx.weight, fs.weight])
        yyhj.get_grade()

        #  重新分配表观状况下属权重
        weight_re_average([xbjg, zl, zzznq, xlsxt, qmx, st])
        bgzk.delete_flag = min(xbjg.delete_flag, zl.delete_flag, zzznq.delete_flag, xlsxt.delete_flag, qmx.delete_flag,
                               st.delete_flag)
        bgzk.points = method.lishudu([xbjg.points, zl.points, zzznq.points, xlsxt.points, qmx.points, st.points],
                                     [xbjg.weight, zl.weight, zzznq.weight, xlsxt.weight, qmx.weight, st.weight])
        bgzk.get_grade()

        #  重新分配力学性能下属权重
        weight_re_average([jgpl, jhbw, xlssl, jgyl, sszzwy, zzwy])
        lxxn.delete_flag = min(xlssl.delete_flag, jhbw.delete_flag, jgyl.delete_flag, jgpl.delete_flag,
                               sszzwy.delete_flag, zzwy.delete_flag)
        lxxn.points = method.lishudu([xlssl.points, jhbw.points, jgyl.points, jgpl.points, sszzwy.points, zzwy.points],
                                     [xlssl.weight, jhbw.weight, jgyl.weight, jgpl.weight, sszzwy.weight, zzwy.weight])
        lxxn.get_grade()

        weight_re_average([lxxn, bgzk, yyhj])
        total.points = method.lishudu([lxxn.points, bgzk.points, yyhj.points], [lxxn.weight, bgzk.weight, yyhj.weight])
        total.get_grade()

        output = {'total': total, 'lxxn': lxxn, 'bgzk': bgzk, 'yyhj': yyhj, 'xlssl': xlssl, 'jhbw': jhbw, 'jgyl': jgyl,
                  'jgpl': jgpl, 'zlxx': zlxx, 'jcwy': jcwy, 'tdwy': tdwy, 'zzwy': zzwy, 'sszzwy': sszzwy,
                  'xbjg': xbjg, 'zl': zl, 'zzznq': zzznq, 'xlsxt': xlsxt, 'qmx': qmx, 'st': st, 'jcct': jcct,
                  'qd': qd, 'qt': qt,
                  'znq': znq, 'zz': zz, 'rxd': rxd, 'sszz': sszz, 'qmpz': qmpz, 'jtl': jtl, 'qmzjd': qmzjd, 'wd': wd,
                  'czczfx': czczfx, 'fs': fs}  # 定义结果输出列表

        return output

    def get_output_list_dj():  # 获得各层次输出得分数组
        total = Output('0', '0', 'TOTAL', '总体技术状况得分')  # 属性分别为父类编码，父类名称，编码，名称。权重自动数据库读取。下同
        # 总体技术状况下属
        lxxn = Output('TOTAL', '总体技术状况得分', 'LXXN', '力学性能')
        bgzk = Output('TOTAL', '总体技术状况得分', 'BGZK', '表观状况')
        yyhj = Output('TOTAL', '总体技术状况得分', 'YYHJ', '运营环境')

        # 力学性能下属
        # 计算结构频率得分
        jgpl = Output('LXXN', '总体技术状况得分-力学性能', 'JGPL', '结构频率')
        sql1 = 'select * from tb_bridge_dqjc_jgpl_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" '  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        if newdf.empty:
            jgpl.delete_flag = 1
        else:
            points = np.zeros(len(newdf.index))
            for i in range(len(newdf.index)):  # 遍历每条病害记录
                disease = newdf['disease'].values[i]  # disease为第i个病害json数组
                disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
                disease = json.loads(disease)  # json数组转化为python字典
                err = disease['频率'] / disease['标准值']
                if err > 1.1:
                    point = 100
                elif err > 1.0:
                    point = 85
                elif err > 0.9:
                    point = 65
                elif err > 0.75:
                    point = 40
                else:
                    point = 0
                points[i] = point
            jgpl.points = method.bianquan(points)
        jgpl.get_grade()

        jhbw = Output('LXXN', '总体技术状况得分-力学性能', 'JHBW', '结构几何变位')
        # 计算基础位移得分
        jcwy = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'JCWY', '基础沉降')
        sql1 = 'select * from tb_bridge_dqjc_jcwy_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" '  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        if newdf.empty:
            jcwy.delete_flag = 1
        else:
            df_sort = newdf.copy()
            df_sort.drop_duplicates(subset='facility_code', inplace=True)
            df_sort.drop(['id', 'measure_point_name', 'measure_point_height', 'disease'], axis=1, inplace=True)
            df_sort['points'] = 100.0
            df_sort['grade'] = 1
            write_data_to_db(df_sort, 'tb_bridge_lxxn_jhbw_jcwy_output')
            facility_code = df_sort['facility_code'].values
            for i in range(len(facility_code)):
                sql1 = 'select * from tb_bridge_dqjc_jcwy_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" and facility_code="' + \
                       facility_code[i] + '"'  # 根据任务号，项目号选择病害记录
                newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
                value = 0
                for j in range(len(newdf.index)):  # 遍历每条病害记录
                    disease = newdf['disease'].values[j]  # disease为第i个病害json数组
                    code = newdf['facility_code'].values[j]
                    disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
                    disease = json.loads(disease)  # json数组转化为python字典
                    value += float(disease['沉降值'])
                value = value / len(newdf.index)  # 同一个桥墩，取多个测点平均值
                if 'SSBSTT' in code:  # 如果是索塔
                    if value <= 10:
                        point = 100
                    elif 10 < value <= 30:
                        point = 65
                    elif 30 < value <= 50:
                        point = 40
                    else:
                        point = 0
                else:  # 如果是普通桥墩
                    if value <= 5:
                        point = 100
                    elif 5 < value <= 10:
                        point = 65
                    elif 10 < value <= 20:
                        point = 40
                    else:
                        point = 0
                sql2 = 'UPDATE  tb_bridge_lxxn_jhbw_jcwy_output SET points=' + str(
                    point) + ' WHERE facility_code=\'' + facility_code[
                           i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                cursor.execute(sql2)
                conn.commit()
                grade = method.point_to_grade(point)
                sql3 = 'UPDATE tb_bridge_lxxn_jhbw_jcwy_output SET grade=' + str(
                    grade) + ' WHERE facility_code=\'' + facility_code[
                           i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                cursor.execute(sql3)
                conn.commit()
            conn.commit()
            jcwy.points = facility_bianquan('tb_bridge_lxxn_jhbw_jcwy_output')

        jcwy.get_grade()

        # 计算塔顶位移得分
        tdwy = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'TDWY', '塔墩倾斜')
        sql1 = 'select * from tb_bridge_dqjc_tdwy_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" '  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        if newdf.empty:
            tdwy.delete_flag = 1
        else:
            df_sort = newdf.copy()
            df_sort.drop_duplicates(subset='facility_code', inplace=True)
            df_sort.drop(['id', 'direction', 'disease'], axis=1, inplace=True)
            write_data_to_db(df_sort, 'tb_bridge_lxxn_jhbw_tdwy_output')
            facility_code = df_sort['facility_code'].values
            for i in range(len(facility_code)):
                sql1 = 'select * from tb_bridge_dqjc_tdwy_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" and facility_code="' + \
                       facility_code[i] + '"'  # 根据任务号，项目号选择病害记录
                newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
                value = 0
                for j in range(len(newdf.index)):  # 遍历每条病害记录
                    disease = newdf['disease'].values[j]  # disease为第i个病害json数组
                    code = newdf['facility_code'].values[j]
                    disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
                    disease = json.loads(disease)  # json数组转化为python字典
                    value += abs(float(disease['倾斜率']))
                value = value / len(newdf.index)  # 同一个桥墩，取多个测点平均值
                if 'SSBSTT' in code:  # 如果是索塔
                    if value <= 2 / 15:
                        point = 100
                    elif 2 / 15 < value <= 1 / 5:
                        point = 85
                    elif 1 / 5 < value <= 4 / 15:
                        point = 65
                    elif 4 / 15 < value <= 1 / 3:
                        point = 40
                    else:
                        point = 0
                else:  # 如果是普通桥墩
                    if value <= 0.4:
                        point = 100
                    elif 0.4 < value <= 0.6:
                        point = 85
                    elif 0.6 < value <= 0.8:
                        point = 65
                    elif 0.8 < value <= 1.0:
                        point = 40
                    else:
                        point = 0
                sql2 = 'UPDATE  tb_bridge_lxxn_jhbw_tdwy_output SET points=' + str(
                    point) + ' WHERE facility_code=\'' + facility_code[
                           i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                cursor.execute(sql2)
                conn.commit()
                grade = method.point_to_grade(point)
                sql3 = 'UPDATE tb_bridge_lxxn_jhbw_tdwy_output SET grade=' + str(
                    grade) + ' WHERE facility_code=\'' + facility_code[
                           i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                cursor.execute(sql3)
                conn.commit()
            conn.commit()
            tdwy.points = facility_bianquan('tb_bridge_lxxn_jhbw_tdwy_output')

        tdwy.get_grade()

        # 计算主梁线形得分
        zlxx = Output('JHBW', '总体技术状况得分-力学性能-结构几何变位', 'ZLXX', '主梁线形')
        sql1 = 'select * from tb_bridge_dqjc_zlxx_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" '  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        if newdf.empty:
            zlxx.delete_flag = 1
        else:
            df_sort = newdf.copy()
            df_sort.drop_duplicates(subset='measure_point_direction', inplace=True)
            measure_point_direction = df_sort['measure_point_direction'].values
            points = np.zeros(len(measure_point_direction))
            for i in range(len(measure_point_direction)):
                sql1 = 'select * from tb_bridge_dqjc_zlxx_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" and measure_point_direction="' + \
                       measure_point_direction[i] + '"'  # 根据任务号，项目号选择病害记录
                newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
                newdf.sort_values(by='measure_point_dist', axis=0, ascending=True, inplace=True)
                std = []
                test = []
                for j in range(len(newdf.index)):  # 遍历每条病害记录
                    disease = newdf['disease'].values[j]  # disease为第i个病害json数组
                    disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
                    disease = json.loads(disease)  # json数组转化为python字典
                    std.append(disease['标准值'])
                    test.append(disease['高程'])
                points[i] = method.huise(test=test, std=std)
                test = np.array(test)
                std = np.array(std)
            zlxx.points = method.bianquan(points)

        zlxx.get_grade()
        conn.commit()

        points = []
        if jcwy.delete_flag == 0:
            points.append(jcwy.points)
        if tdwy.delete_flag == 0:
            points.append(tdwy.points)
        if zlxx.delete_flag == 0:
            points.append(zlxx.points)
        if len(points) == 0:
            jhbw.delete_flag = 1
        else:
            jhbw.points = min(points)  # 综合基础位移、塔顶位移、主梁线形得分，取最小值作为几何变位得分
        jhbw.get_grade()
        # jhbw.delete_flag += jcwy.delete_flag + tdwy.delete_flag + zlxx.delete_flag

        # 计算斜拉索索力得分
        xlssl = Output('LXXN', '总体技术状况得分-力学性能', 'XLSSL', '斜拉索索力')
        sql1 = 'select * from tb_bridge_dqjc_xlssl_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '" '  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        if newdf.empty:
            xlssl.delete_flag = 1
        else:
            df_sort = newdf.copy()
            df_sort.drop(['id', 'disease'], axis=1, inplace=True)
            df_sort['points'] = 100.0
            df_sort['grade'] = 1
            write_data_to_db(df_sort, 'tb_bridge_lxxn_xlssl_output')
            facility_code = df_sort['facility_code'].values
            std = []
            test = []
            for i in range(len(newdf.index)):  # 遍历每条病害记录
                disease = newdf['disease'].values[j]  # disease为第i个病害json数组
                disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads的要求
                disease = json.loads(disease)  # json数组转化为python字典
                std.append(disease['标准值'])
                test.append(disease['索力'])
                err = abs(float(disease['标准值'] - disease['索力'])) / float(disease['标准值'])
                if err > 0.1:
                    point = 40
                    if err > 0.15:
                        point = 0
                    sql2 = 'UPDATE  tb_bridge_lxxn_xlssl_output SET points=' + str(
                        point) + ' WHERE facility_code=\'' + facility_code[
                               i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                    cursor.execute(sql2)
                    conn.commit()
                    grade = method.point_to_grade(point)
                    sql3 = 'UPDATE tb_bridge_lxxn_xlssl_output SET grade=' + str(
                        grade) + ' WHERE facility_code=\'' + facility_code[
                               i] + '\' and project_code=\'' + project_code + '\' and task_no=\'' + task_no + '\''  # 修改output表中的输出得分
                    cursor.execute(sql3)
                    conn.commit()

            xlssl.points = method.huise(test=test, std=std)

        xlssl.get_grade()
        conn.commit()

        # 计算结构应力得分
        jgyl = Output('LXXN', '总体技术状况得分-力学性能', 'JGYL', '结构应力')
        jgyl.delete_flag = facility('SEW', 'tb_bridge_lxxn_jgyl_checkvalue', 'tb_bridge_lxxn_jgyl_output')
        jgyl.points = facility_bianquan('tb_bridge_lxxn_jgyl_output')
        jgyl.get_grade()

        # 计算伸缩缝位移得分
        sszzwy = Output('LXXN', '总体技术状况得分-力学性能', 'SSZZWY', '伸缩装置位移')
        sszzwy.delete_flag = facility('SDW', 'tb_bridge_lxxn_sszz_checkvalue', 'tb_bridge_lxxn_sszz_output')
        sszzwy.points = facility_bianquan('tb_bridge_lxxn_sszz_output')
        sszzwy.get_grade()

        # 计算支座位移得分
        zzwy = Output('LXXN', '总体技术状况得分-力学性能', 'ZZWY', '支座位移')
        zzwy.delete_flag = facility('SDW', 'tb_bridge_lxxn_zzwy_checkvalue', 'tb_bridge_lxxn_zzwy_output')
        zzwy.points = facility_bianquan('tb_bridge_lxxn_zzwy_output')
        zzwy.get_grade()

        # 表观状况下属
        # 计算索塔得分
        st = Output('BGZK', '总体技术状况得分-表观状况', 'ST', '索塔系统')
        st.delete_flag = facility('SSBSTT', 'tb_bridge_bgzk_stxt_st_checkvalue', 'tb_bridge_bgzk_stxt_st_output')
        st.points = facility_bianquan('tb_bridge_bgzk_stxt_st_output')
        st.get_grade()

        # 计算斜拉索系统得分
        xlsxt = Output('BGZK', '总体技术状况得分-表观状况', 'XLSXT', '斜拉索系统')
        xlsxt.points = facility_xls_total()
        xlsxt.get_grade()

        # 计算主梁系统得分
        zl = Output('BGZK', '总体技术状况得分-表观状况', 'ZL', '主梁系统')
        delete_flag1 = facility('SSBGZL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag2 = facility('SSBGXZ', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag3 = facility('SSBGHL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        delete_flag4 = facility('SSBYLL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')
        zl.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        zl.points = facility_bianquan('tb_bridge_bgzk_zlxt_zl_output')
        zl.get_grade()

        # 计算下部结构
        xbjg = Output('BGZK', '总体技术状况得分-表观状况', 'XBJG', '下部结构')

        # 计算基础承台得分
        jcct = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'JCCT', '基础承台')
        jcct.delete_flag = facility('SXBJCC', 'tb_bridge_bgzk_xbjg_jcct_checkvalue', 'tb_bridge_bgzk_xbjg_jcct_output')
        jcct.points = facility_bianquan('tb_bridge_bgzk_xbjg_jcct_output')
        jcct.get_grade()

        # 计算桥墩得分
        qd = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'QD', '桥墩')
        delete_flag1 = facility('SXBQGL', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 盖梁
        delete_flag2 = facility('SXBQDS', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 桥墩身
        qd.delete_flag = min(delete_flag2, delete_flag1)
        qd.points = facility_bianquan('tb_bridge_bgzk_xbjg_qd_output')
        qd.get_grade()

        # 计算桥台得分
        qt = Output('XBJG', '总体技术状况得分-表观状况-下部结构', 'QT', '桥台')
        delete_flag1 = facility('SXBQTS', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 台身
        delete_flag2 = facility('SXBQTM', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 台帽
        qt.delete_flag = min(delete_flag2, delete_flag1)
        qt.points = facility_bianquan('tb_bridge_bgzk_xbjg_qt_output')
        qt.get_grade()

        #  重新分配下部结构权重
        weight_re_average([jcct, qd, qt])
        xbjg.delete_flag = min(jcct.delete_flag, qd.delete_flag, qt.delete_flag)
        xbjg.points = method.lishudu([jcct.points, qd.points, qt.points], [jcct.weight, qd.weight, qt.weight])
        xbjg.get_grade()

        # 支座及限位装置下属
        zzznq = Output('BGZK', '总体技术状况得分-表观状况', 'ZZZNQ', '支座及限位装置')

        znq = Output('ZZZNQ', '总体技术状况得分-表观状况-支座与限位装置', 'ZNQ', '主梁阻尼器')
        delete_flag1 = facility('SSBZZQ', 'tb_bridge_bgzk_zzxt_znq_checkvalue', 'tb_bridge_bgzk_zzxt_znq_output')  # 阻尼器
        delete_flag2 = facility('SSBZXK', 'tb_bridge_bgzk_zzxt_znq_checkvalue', 'tb_bridge_bgzk_zzxt_znq_output')  # 限位块
        znq.delete_flag = min(delete_flag2, delete_flag1)
        znq.points = facility_bianquan('tb_bridge_bgzk_zzxt_znq_output')
        znq.get_grade()

        zz = Output('ZZZNQ', '总体技术状况得分-表观状况-支座与限位装置', 'ZZ', '支座')
        delete_flag1 = facility('SSBPXZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue', 'tb_bridge_bgzk_zzxt_zz_output')
        delete_flag2 = facility('SSBGZZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue', 'tb_bridge_bgzk_zzxt_zz_output')
        zz.delete_flag = min(delete_flag2, delete_flag1)
        zz.points = facility_bianquan('tb_bridge_bgzk_zzxt_zz_output')
        zz.get_grade()

        weight_re_average([znq, zz])
        zzznq.delete_flag = min(znq.delete_flag, zz.delete_flag)
        zzznq.points = method.lishudu([znq.points, zz.points], [znq.weight, zz.weight])
        zzznq.get_grade()

        # 桥面系下属
        qmx = Output('BGZK', '总体技术状况得分-表观状况', 'QMX', '桥面系')

        qmpz = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'QMPZ', '桥面铺装')
        qmpz.delete_flag = facility('SQMLQP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue', 'tb_bridge_bgzk_qmx_qmpz_output')
        qmpz.points = facility_bianquan('tb_bridge_bgzk_qmx_qmpz_output')
        qmpz.get_grade()

        rxd = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'RXD', '人行道')
        rxd.delete_flag = facility('SQMRXD', 'tb_bridge_bgzk_qmx_rxd_checkvalue', 'tb_bridge_bgzk_qmx_rxd_output')
        rxd.points = facility_bianquan('tb_bridge_bgzk_qmx_rxd_output')
        rxd.get_grade()

        sszz = Output('QMX', '总体技术状况得分-表观状况-桥面系', 'SSZZ', '伸缩装置')
        delete_flag1 = facility('SQMMSF', 'tb_bridge_bgzk_qmx_sszz_checkvalue', 'tb_bridge_bgzk_qmx_sszz_output')
        delete_flag2 = facility('SQMLXF', 'tb_bridge_bgzk_qmx_sszz_checkvalue', 'tb_bridge_bgzk_qmx_sszz_output')
        sszz.delete_flag = min(delete_flag2, delete_flag1)
        sszz.points = facility_bianquan('tb_bridge_bgzk_qmx_sszz_output')
        sszz.get_grade()

        weight_re_average([qmpz, rxd, sszz])
        qmx.delete_flag = min(qmpz.delete_flag, rxd.delete_flag, sszz.delete_flag)
        qmx.points = method.lishudu([rxd.points, sszz.points, qmpz.points],
                                    [rxd.weight, sszz.weight, qmpz.weight])  # 根据隶属度方法计算桥面系得分，下同
        qmx.get_grade()

        # 运营环境下属
        czczfx = Output('YYHJ', '总体技术状况得分-运营环境', 'CZCZFX', '船撞车撞风险')
        delete_flag1 = facility('SXBJCC', 'tb_bridge_bgzk_xbjg_jcct_checkvalue',
                                'tb_bridge_bgzk_xbjg_jcct_output')  # 基础承台防撞
        delete_flag2 = facility('SSBGZL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')  # 主梁防撞
        czczfx.delete_flag = min(delete_flag2, delete_flag1)
        czczfx.points = facility_bianquan('tb_bridge_yyhj_czczfx_output')
        czczfx.get_grade()

        fs = Output('YYHJ', '总体技术状况得分-运营环境', 'FS', '风速')
        fs.delete_flag = facility('SWST', 'tb_bridge_yyhj_fs_checkvalue', 'tb_bridge_yyhj_fs_output')
        fs.points = facility_bianquan('tb_bridge_yyhj_fs_output')
        fs.get_grade()

        jtl = Output('YYHJ', '总体技术状况得分-运营环境', 'JTL', '交通量')
        jtl.delete_flag = facility('SCS', 'tb_bridge_yyhj_jtl_checkvalue', 'tb_bridge_yyhj_jtl_output')
        jtl.points = facility_bianquan('tb_bridge_yyhj_jtl_output')
        jtl.get_grade()

        qmzjd = Output('YYHJ', '总体技术状况得分-运营环境', 'QMZJD', '桥面整洁度')
        qmzjd.delete_flag = facility('SQMLQP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue', 'tb_bridge_yyhj_qmzjd_output')
        qmzjd.points = facility_bianquan('tb_bridge_yyhj_qmzjd_output')
        qmzjd.get_grade()

        wd = Output('YYHJ', '总体技术状况得分-运营环境', 'WD', '温度')
        delete_flag1 = facility('STHT101', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        delete_flag2 = facility('STHT201', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        delete_flag3 = facility('STH0501', 'tb_bridge_yyhj_wd_checkvalue', 'tb_bridge_yyhj_wd_output')
        wd.delete_flag = min(delete_flag3, delete_flag2, delete_flag1)
        wd.points = facility_bianquan('tb_bridge_yyhj_wd_output')
        wd.get_grade()

        #  重新分配运营环境下属权重
        weight_re_average([czczfx, fs, jtl, qmzjd, wd])
        yyhj.delete_flag = min(jtl.delete_flag, qmzjd.delete_flag, wd.delete_flag, czczfx.delete_flag, fs.delete_flag)
        yyhj.points = method.lishudu([jtl.points, qmzjd.points, wd.points, czczfx.points, fs.points],
                                     [jtl.weight, qmzjd.weight, wd.weight, czczfx.weight, fs.weight])
        yyhj.get_grade()

        #  重新分配表观状况下属权重
        weight_re_average([xbjg, zl, zzznq, xlsxt, qmx, st])
        bgzk.delete_flag = min(xbjg.delete_flag, zl.delete_flag, zzznq.delete_flag, xlsxt.delete_flag, qmx.delete_flag,
                               st.delete_flag)
        bgzk.points = method.lishudu([xbjg.points, zl.points, zzznq.points, xlsxt.points, qmx.points, st.points],
                                     [xbjg.weight, zl.weight, zzznq.weight, xlsxt.weight, qmx.weight, st.weight])
        bgzk.get_grade()

        #  重新分配力学性能下属权重
        weight_re_average([jgpl, jhbw, xlssl, jgyl, sszzwy, zzwy])
        lxxn.delete_flag = min(xlssl.delete_flag, jhbw.delete_flag, jgyl.delete_flag, jgpl.delete_flag,
                               sszzwy.delete_flag, zzwy.delete_flag)
        lxxn.points = method.lishudu([xlssl.points, jhbw.points, jgyl.points, jgpl.points, sszzwy.points, zzwy.points],
                                     [xlssl.weight, jhbw.weight, jgyl.weight, jgpl.weight, sszzwy.weight, zzwy.weight])
        lxxn.get_grade()

        weight_re_average([lxxn, bgzk, yyhj])
        total.points = method.lishudu([lxxn.points, bgzk.points, yyhj.points], [lxxn.weight, bgzk.weight, yyhj.weight])
        total.get_grade()

        output = {'total': total, 'lxxn': lxxn, 'bgzk': bgzk, 'yyhj': yyhj, 'xlssl': xlssl, 'jhbw': jhbw, 'jgyl': jgyl,
                  'jgpl': jgpl, 'zlxx': zlxx, 'jcwy': jcwy, 'tdwy': tdwy, 'zzwy': zzwy, 'sszzwy': sszzwy,
                  'xbjg': xbjg, 'zl': zl, 'zzznq': zzznq, 'xlsxt': xlsxt, 'qmx': qmx, 'st': st, 'jcct': jcct,
                  'qd': qd, 'qt': qt,
                  'znq': znq, 'zz': zz, 'rxd': rxd, 'sszz': sszz, 'qmpz': qmpz, 'jtl': jtl, 'qmzjd': qmzjd, 'wd': wd,
                  'czczfx': czczfx, 'fs': fs}  # 定义结果输出列表

        return output

    # 主函数，调用上述函数
    sql1 = 'select * from tb_bridge_lxxn_xlssl_checkvalue where task_no="' + task_no + '" and project_code="' + project_code + '"'  # 提取索力监测推送数据，判断是否空，来判断是监测推送还是定检推送
    newdf = get_data_from_db(sql1)
    if newdf.empty:
        output_list = get_output_list_dj()
    else:
        output_list = get_output_list_jc()

    data = pd.DataFrame(
        columns=['project_code', 'task_no', 'parent_code', 'parent_name', 'code', 'name', 'weight', 'datapushdate',
                 'points'])
    for key in output_list:
        add_data = pd.Series(
            {'project_code': project_code, 'task_no': task_no, 'parent_code': output_list[key].parent_code,
             'parent_name': output_list[key].parent_name, 'code': output_list[key].code,
             'name': output_list[key].name,
             'weight': output_list[key].weight, 'datapushdate': datetime.now(), 'points': output_list[key].points,
             'grade': output_list[key].grade})
        data = data.append(add_data, ignore_index=True)
    write_data_to_db(data, 'tb_bridge_assessment_output')

    """
    # 删除设施清单信息
    sql = 'delete from tb_bridge_assessment_facilitylist where project_code ="' + str(
        project_code) + '"'  # 根据project_code提取设施清单信息
    cursor.execute(sql)
    """
    conn.commit()
