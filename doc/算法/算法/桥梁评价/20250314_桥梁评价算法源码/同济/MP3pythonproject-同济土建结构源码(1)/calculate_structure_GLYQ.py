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
        project_code) + '" and task_no = "' + task_no + '"'  # 根据project_code提取设施清单信息
    df_facilitylist = pd.read_sql(sql=sql, con=engine)
    # df_facilitylist.insert(2, 'task_no', task_no)  # 插入任务号
    df_facilitylist = df_facilitylist.drop('id', axis=1)  # 去掉id列
    df_facilitylist = df_facilitylist.drop('delete_flag', axis=1)  # 去掉delete_flag列

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

    def get_weight_from_db(parent_code, code_list):  # 从权重表格中提取权重数据
        sql4 = 'select * from ' + 'tb_bridge_assessment_weights' + ' where code=\'' + code_list + '\' and project_code=\'GLYQ\''
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
        sql = 'select * from tb_bridge_yq_gl_disease where facility_code =\'' + code + '\''
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

    def facility_get_DP(facility_code, disease_name, disease_grade):  # 根据公路规范计算DP扣分值
        sql = 'select * from tb_bridge_yq_gl_disease where facility_code =\'' + facility_code + '\' and disease_name=\'' + disease_name + '\''
        df_disease = pd.read_sql(sql=sql, con=engine)
        disease_maxgrade = df_disease['disease_maxgrade'].values[0]
        DP = method.yq_grade_dp(disease_grade, disease_maxgrade)  # 输入参数为病害等级、病害能达到的最高等级
        return DP

    def facility_points(code, checkvaluetable, outputtable):  # 根据checkvalue记录，计算构件得分，并写入output表
        sql1 = 'select * from ' + checkvaluetable + ' where task_no=\'' + task_no + '\' and project_code=\'' + project_code + '\' and facility_code like \'%%' + code + '%%\''  # 根据任务号，项目号选择病害记录
        newdf = get_data_from_db(sql1)  # newdf为选出的病害记录表
        newdf = newdf.drop('id', axis=1)  # 去掉id列
        disease_list = facility_disease(code)  # 根据code去构件病害表中提取构件对应的病害
        for i in newdf.index:  # 遍历每条病害记录
            disease = newdf['disease'].values[i]  # disease为第i个病害json数组
            disease = disease.replace('\'', '"')  # 单引号更换为双引号，以符合json.loads得到要求
            disease = json.loads(disease)  # json数组转化为python字典

            DP = []

            for j in range(len(disease_list)):  # 对于构件对应的disease_list，遍历病害，添加等级
                try:
                    a = disease_list[j]
                    b = disease[disease_list[j]]
                    c = facility_get_DP(code, disease_list[j], disease[disease_list[j]])
                    DP.append(facility_get_DP(code, disease_list[j], disease[disease_list[j]]))
                except:
                    continue
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

    def facility_bujian_values(outputtable):  # 规范中t值表，计算部件得分
        sql = 'select points from ' + outputtable + ' where task_no=\'' + task_no + '\' and project_code=\'' + project_code + '\''
        df = pd.read_sql(sql=sql, con=engine)
        points = df['points'].values
        if len(points) != 0:
            if len(points) <= 200:
                sql = 'select t_values from tb_bridge_yq_tvalues  where facility_numbers=\'' + str(len(points)) + '\''
                t = pd.read_sql(sql=sql, con=engine)
                t = t['t_values'].values[0]
            else:
                t = 2.3
            point = method.bujian_values(points, t)
        else:
            point = 100
        return point

    def facility(code, checkvaluetable, outputtable):  # 普通构件运行该函数
        delete_flag = facility_classification(code, outputtable)  # 根据编码，从设施清单表中提出对应设施，写入输出表中
        facility_points(code, checkvaluetable, outputtable)  # 根据checkvaluetable中的病害，计算各构件得分
        return delete_flag

    def get_output_list():  # 获得各层次输出得分数组
        total = Output('0', '0', 'TOTAL', '总体技术状况得分')  # 属性分别为父类编码，父类名称，编码，名称。权重自动数据库读取。下同
        # 总体技术状况下属
        sbjg = Output('TOTAL', '总体技术状况得分', 'SBJG', '上部结构')
        xbjg = Output('TOTAL', '总体技术状况得分', 'XBJG', '下部结构')
        qmx = Output('TOTAL', '总体技术状况得分', 'QMX', '桥面系')

        # 上部结构下属
        czgj = Output('SBJG', '总体技术状况得分-上部结构', 'CZGJ', '上部承重构件（主梁、挂梁）')
        delete_flag1 = facility('SSBGGL', 'tb_bridge_bgzk_zlxt_zl_checkvalue',
                                'tb_bridge_bgzk_zlxt_zl_output')  # 钢筋混凝土主梁
        delete_flag2 = facility('SSBYLL', 'tb_bridge_bgzk_zlxt_zl_checkvalue',
                                'tb_bridge_bgzk_zlxt_zl_output')  # 预应力混凝土主梁
        delete_flag3 = facility('SSBGHL', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')  # 钢桁梁主梁
        delete_flag4 = facility('SSBGXZ', 'tb_bridge_bgzk_zlxt_zl_checkvalue', 'tb_bridge_bgzk_zlxt_zl_output')  # 钢箱梁主梁
        czgj.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        czgj.points = facility_bujian_values('tb_bridge_bgzk_zlxt_zl_output')
        czgj.get_grade()

        ybgj = Output('SBJG', '总体技术状况得分-上部结构', 'YBGJ', '上部一般构件（湿接缝、横隔板等）')  # 存在阻尼器的结果表内
        delete_flag1 = facility('SSBHGB', 'tb_bridge_bgzk_zzxt_znq_checkvalue', 'tb_bridge_bgzk_zzxt_znq_output')  # 横隔板
        delete_flag2 = facility('SSBHLL', 'tb_bridge_bgzk_zzxt_znq_checkvalue',
                                'tb_bridge_bgzk_zzxt_znq_output')  # 横梁含连接件
        delete_flag3 = facility('SSBSJF', 'tb_bridge_bgzk_zzxt_znq_checkvalue',
                                'tb_bridge_bgzk_zzxt_znq_output')  # 湿接缝横向
        delete_flag4 = facility('SSBSJT', 'tb_bridge_bgzk_zzxt_znq_checkvalue',
                                'tb_bridge_bgzk_zzxt_znq_output')  # 湿接头纵向
        ybgj.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        ybgj.points = facility_bujian_values('tb_bridge_bgzk_zzxt_znq_output')
        ybgj.get_grade()

        zz = Output('SBJG', '总体技术状况得分-上部结构', 'ZZ', '支座')
        delete_flag1 = facility('SSBBXZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue',
                                'tb_bridge_bgzk_zzxt_zz_output')  # 板式橡胶支座
        delete_flag2 = facility('SSBPXZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue',
                                'tb_bridge_bgzk_zzxt_zz_output')  # 盆式橡胶支座
        delete_flag3 = facility('SSBGZZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue', 'tb_bridge_bgzk_zzxt_zz_output')  # 钢支座
        delete_flag4 = facility('SSBHBZ', 'tb_bridge_bgzk_zzxt_zz_checkvalue',
                                'tb_bridge_bgzk_zzxt_zz_output')  # 混凝土摆式支座
        zz.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        zz.points = facility_bujian_values('tb_bridge_bgzk_zzxt_zz_output')
        zz.get_grade()
        weight_re_average([czgj, ybgj, zz])

        # 下部结构下属
        qd = Output('XBJG', '总体技术状况得分-下部结构', 'QD', '桥墩')
        delete_flag1 = facility('SXBQDS', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 桥墩墩身
        delete_flag2 = facility('SXBQGL', 'tb_bridge_bgzk_xbjg_qd_checkvalue', 'tb_bridge_bgzk_xbjg_qd_output')  # 盖梁系梁
        qd.delete_flag = min(delete_flag2, delete_flag1)
        qd.points = facility_bujian_values('tb_bridge_bgzk_xbjg_qd_output')
        qd.get_grade()

        qt = Output('XBJG', '总体技术状况得分-下部结构', 'QT', '桥台')
        delete_flag1 = facility('SXBQTS', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 桥台台身
        delete_flag2 = facility('SXBQTM', 'tb_bridge_bgzk_xbjg_qt_checkvalue', 'tb_bridge_bgzk_xbjg_qt_output')  # 台帽
        qt.delete_flag = min(delete_flag2, delete_flag1)
        qt.points = facility_bujian_values('tb_bridge_bgzk_xbjg_qt_output')
        qt.get_grade()

        dtjc = Output('XBJG', '总体技术状况得分-下部结构', 'DTJC', '墩台基础')
        dtjc.delete_flag = facility('SXBJCC', 'tb_bridge_bgzk_xbjg_jcct_checkvalue',
                                    'tb_bridge_bgzk_xbjg_jcct_output')  # 墩台基础
        dtjc.points = facility_bujian_values('tb_bridge_bgzk_xbjg_jcct_output')
        dtjc.get_grade()

        weight_re_average([qd, qt, dtjc])

        # 桥面系下属
        qmpz = Output('QMX', '总体技术状况得分-桥面系', 'QMPZ', '桥面铺装')
        delete_flag1 = facility('SQMSNP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue',
                                'tb_bridge_bgzk_qmx_qmpz_output')  # 水泥混凝土铺装层
        delete_flag2 = facility('SQMLQP', 'tb_bridge_bgzk_qmx_qmpz_checkvalue',
                                'tb_bridge_bgzk_qmx_qmpz_output')  # 沥青混凝土铺装层
        qmpz.delete_flag = min(delete_flag2, delete_flag1)
        qmpz.points = facility_bujian_values('tb_bridge_bgzk_qmx_qmpz_output')
        qmpz.get_grade()

        sszz = Output('QMX', '总体技术状况得分-桥面系', 'SSZZ', '伸缩装置')
        delete_flag1 = facility('SQMXGF', 'tb_bridge_bgzk_qmx_sszz_checkvalue',
                                'tb_bridge_bgzk_qmx_sszz_output')  # 型钢伸缩装置
        delete_flag2 = facility('SQMLXF', 'tb_bridge_bgzk_qmx_sszz_checkvalue',
                                'tb_bridge_bgzk_qmx_sszz_output')  # 梳齿板伸缩装置
        delete_flag3 = facility('SQMMSF', 'tb_bridge_bgzk_qmx_sszz_checkvalue',
                                'tb_bridge_bgzk_qmx_sszz_output')  # 模数式伸缩装置 (大位移伸缩装置)
        delete_flag4 = facility('SQMXJF', 'tb_bridge_bgzk_qmx_sszz_checkvalue', 'tb_bridge_bgzk_qmx_sszz_output')  # 连续缝
        sszz.delete_flag = min(delete_flag4, delete_flag3, delete_flag2, delete_flag1)
        sszz.points = facility_bujian_values('tb_bridge_bgzk_qmx_sszz_output')
        sszz.get_grade()

        rxd = Output('QMX', '总体技术状况得分-桥面系', 'RXD', '人行道')
        rxd.delete_flag = facility('SQMRXD', 'tb_bridge_bgzk_qmx_rxd_checkvalue',
                                   'tb_bridge_bgzk_qmx_rxd_output')  # 人行道
        rxd.points = facility_bujian_values('tb_bridge_bgzk_qmx_rxd_output')
        rxd.get_grade()

        weight_re_average([qmpz, sszz, rxd])

        sbjg.points = method.weighted_avg([czgj, ybgj, zz])  # 根据规范，加权平均计算上部结构得分
        sbjg.get_grade()
        xbjg.points = method.weighted_avg([qd, qt, dtjc])
        xbjg.get_grade()
        qmx.points = method.weighted_avg([qmpz, sszz, rxd])
        qmx.get_grade()

        total.points = method.weighted_avg([sbjg, xbjg, qmx])
        total.get_grade()

        output = {'total': total, 'sbjg': sbjg, 'xbjg': xbjg, 'qmx': qmx, 'czgj': czgj, 'ybgj': ybgj, 'zz': zz,
                  'qd': qd, 'qt': qt, 'dtjc': dtjc, 'qmpz': qmpz, 'sszz': sszz, 'rxd': rxd}

        return output

    # 主函数，调用上述函数
    output_list = get_output_list()

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
    conn.commit()


"""
    # 删除设施清单信息
    sql = 'delete from tb_bridge_assessment_facilitylist where project_code ="' + str(
        project_code) + '"'  # 根据project_code提取设施清单信息
    cursor.execute(sql)
    conn.commit()
"""