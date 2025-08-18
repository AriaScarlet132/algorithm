import mysql
import pandas as pd
import datetime
import warnings
from pymysql import connect
warnings.filterwarnings("ignore")
#计算交通能力类指标
def cal_TSI(basicinfo,dsidata,dtidata,apidata,rating_mark,weight):
    tsi={}
    #计算DSI 日均行驶速率
    '''
    DSI/DTI需要变权重
    '''
    dsiData=dsidata.copy()
    dtiData=dtidata.copy()
    apiData=apidata.copy()
    if dsiData.empty:
        tsi['dsi_value'] = None
        tsi['dsi_mark'] = None
        tsi['dsi_grade_desp'] = None
        tsi['dsi_grade'] = None
    else:
        DSI = dsiData['running_speed'].mean()
        dsiRating = rating_mark[rating_mark['index_code'] == 'DSI']
        limitspeed=float(basicinfo['limit_speed'].values[0])
        dsiRating['lower_value']=dsiRating['lower_value'].apply(lambda x:x * limitspeed)
        dsiRating['upper_value'] = dsiRating['upper_value'].apply(lambda x: x * limitspeed)
        temp=dsiRating[(dsiRating['lower_value']<=DSI) & (DSI<dsiRating['upper_value'])]
        temp.reset_index(inplace=True)
        tsi['dsi_value'] = DSI
        tsi['dsi_mark'] = temp.loc[0, 'rate_mark']
        tsi['dsi_grade_desp'] = temp.loc[0, 'rate_desp']
        tsi['dsi_grade'] = temp.loc[0, 'rate_value']
    #计算DTI 高峰期饱和度
    if dtiData.empty:
        tsi['dti_value'] = None
        tsi['dti_mark'] = None
        tsi['dti_grade_desp'] = None
        tsi['dti_grade'] = None
    else:
        #修改
        #考虑高峰期 7，8 ，17，18
        dti=dtiData[dtiData['monitor_hour'].isin ([7,8,17,18])]
        q=dti['traffic_flow'].mean()
        l_n=basicinfo['lane_number'].values[0]
        r_c=basicinfo['basic_road_capacity'].values[0]
        DTI=q/l_n/r_c
        dtiRating = rating_mark[rating_mark['index_code'] == 'DTI']
        temp_dti = dtiRating[(dtiRating['lower_value'] <= DTI) & (DTI < dtiRating['upper_value'])]
        temp_dti.reset_index(inplace=True)
        tsi['dti_value'] = DTI
        tsi['dti_mark'] = temp_dti.loc[0, 'rate_mark']
        tsi['dti_grade_desp'] = temp_dti.loc[0, 'rate_desp']
        tsi['dti_grade'] = temp_dti.loc[0, 'rate_value']
    #计算API 月度交通封闭期交通影响量
    if apiData.empty:
        API=0
    else:
        col = ['traffick%d_value' % x for x in range(1, 8)]
        apiData['age7Days'] = apiData[col].mean(axis=1)
        API = apiData['age7Days'].mean()
    apiRating = rating_mark[rating_mark['index_code'] == 'API']
    temp_api = apiRating[(apiRating['lower_value'] <= API) & (API < apiRating['upper_value'])]
    temp_api.reset_index(inplace=True)
    tsi['api_value'] = API
    tsi['api_mark'] = temp_api.loc[0, 'rate_mark']
    tsi['api_grade_desp'] = temp_api.loc[0, 'rate_desp']
    tsi['api_grade'] = temp_api.loc[0, 'rate_value']
    '''
    添加权重信息，并根据DTI和DSI进行变权重
    '''
    w=weight[weight['parent_op_service']=='交通能力'][['op_service_code','op_service_weights_value']]
    tsiw={}
    tsiw['DSI']=tsi['dsi_value']
    tsiw['DTI']=tsi['dti_value']
    tsiw['API']=tsi['api_value']
    tsiw=pd.DataFrame.from_dict(tsiw,orient='index').reset_index().rename(columns={'index':'op_service_code',0:'value'})
    tsiw=pd.merge(tsiw,w,on='op_service_code')
    tsiw['weight']=tsiw.apply(lambda x: x.op_service_weights_value if pd.notnull(x.value) else 0,axis=1)
    def newweight(x):
        nw=[]
        sumw=x.weight.sum()
        for i ,row in x.iterrows():
            nw.append(row['weight']/sumw)
        return nw
    tsiw['nw']=newweight(tsiw)
    tsi['dsi_weight']=tsiw[tsiw['op_service_code']=='DSI']['nw'].values[0]
    tsi['dti_weight']=tsiw[tsiw['op_service_code'] == 'DTI']['nw'].values[0]
    tsi['api_weight']=tsiw[tsiw['op_service_code'] == 'API']['nw'].values[0]
    TSI = pd.DataFrame(tsi, index=[0])
    return TSI

# 计算安全能力类指标
def cal_SSI(accidentdata,dtidata,basicinfo,rating,caldays,weight):
    ssi={}
    accidentData=accidentdata.copy()
    if accidentData.empty:
        AAI=0
    else:
        # 计算AAI	 年度重大交通事故数     除以天数再乘30
        AAI = accidentData.groupby(['monitor_year'])['major_traffic_accident'].sum().mean()
        AAI=AAI/caldays*30
    aaiRating = rating[rating['index_code'] == 'AAI']
    temp_aai = aaiRating[(aaiRating['lower_value'] <= AAI) & (AAI < aaiRating['upper_value'])]
    temp_aai.reset_index(inplace=True)
    ssi['aai_value'] = AAI
    ssi['aai_mark'] = temp_aai.loc[0, 'rate_mark']
    ssi['aai_grade_desp'] = temp_aai.loc[0, 'rate_desp']
    ssi['aai_grade'] = temp_aai.loc[0, 'rate_value']
    if accidentData.empty or dtidata.empty:
       TIR=0
    else:
         #计算TIR	 事故率
        length = basicinfo['bridge_length'].values[0]
        D = accidentData.groupby(['monitor_year'])['normal_traffic_accident'].sum().mean()
        avgFlow = dtidata.traffic_flow.mean()
        #统计天数
        days=(dtidata['monitor_date'].max()-dtidata['monitor_date'].min()).days+1
        '''
        ！！！！ days 根据交通流量表计算时间数据算  求天数 桥梁长度是length
        '''
        #####除以 30
        TIR = D / (length * avgFlow * days) * (10 ** 6)
    tirRating = rating[rating['index_code'] == 'TIR']
    temp_tir = tirRating[(tirRating['lower_value'] <= TIR) & (TIR < tirRating['upper_value'])]
    temp_tir.reset_index(inplace=True)
    ssi['tir_value'] = TIR
    ssi['tir_mark'] = temp_tir.loc[0, 'rate_mark']
    ssi['tir_grade_desp'] = temp_tir.loc[0, 'rate_desp']
    ssi['tir_grade'] = temp_tir.loc[0, 'rate_value']


    '''
       添加权重信息
       '''
    w = weight[weight['parent_op_service'] == '安全能力'][['op_service_code', 'op_service_weights_value']]
    ssiw = {}
    ssiw['AAI'] = ssi['aai_value']
    ssiw['TIR'] = ssi['tir_value']
    ssiw = pd.DataFrame.from_dict(ssiw, orient='index').reset_index().rename(
        columns={'index': 'op_service_code', 0: 'value'})
    ssiw = pd.merge(ssiw, w, on='op_service_code')
    ssi['aai_weight'] = ssiw[ssiw['op_service_code'] == 'AAI']['op_service_weights_value'].values[0]
    ssi['tir_weight'] = ssiw[ssiw['op_service_code'] == 'TIR']['op_service_weights_value'].values[0]
    SSI = pd.DataFrame(ssi, index=[0])
    return SSI


# 计算应急能力类指标
def cal_ESI(epidata,rtidata,rating,weight):
    esi={}
    #计算EPI 月度应急设备和材料完备性
    epiData = epidata.copy()
    if epiData.empty:
        EPI=1
    else:
        epiData['EPI'] = epiData['actual_material'] / epiData['agreed_material']
        epiData['EPI'].fillna(1,inplace=True)
        EPI = epiData['EPI'].mean()
    epiRating = rating[rating['index_code'] == 'EPI']
    temp_epi = epiRating[(epiRating['lower_value'] <= EPI) & (EPI < epiRating['upper_value'])]
    temp_epi.reset_index(inplace=True)
    esi['epi_value'] = EPI
    esi['epi_mark'] = temp_epi.loc[0, 'rate_mark']
    esi['epi_grade_desp'] = temp_epi.loc[0, 'rate_desp']
    esi['epi_grade'] = temp_epi.loc[0, 'rate_value']
    # 计算RTI 月均救援响应时间
    if rtidata.empty:
        RTI=0
    else:
        rtiData = rtidata.copy()
        rtiData['rescue_end_time'] = pd.to_datetime(rtiData['rescue_end_time'], format='%Y-%m-%d %H:%M:%S',errors='coerce')
        rtiData['rescue_start_time'] = pd.to_datetime(rtiData['rescue_start_time'],format='%Y-%m-%d %H:%M:%S',errors='coerce')
        rtiData['time'] = (rtiData['rescue_end_time'] - rtiData['rescue_start_time']).dt.seconds / 60
        RTI=rtiData.groupby(['monitor_year','monitor_month'])['time'].mean().mean()
    rtiRating = rating[rating['index_code'] == 'RTI']
    temp_rti = rtiRating[(rtiRating['lower_value'] <= RTI) & (RTI < rtiRating['upper_value'])]
    temp_rti.reset_index(inplace=True)
    esi['rti_value'] = RTI
    esi['rti_mark'] = temp_rti.loc[0, 'rate_mark']
    esi['rti_grade_desp'] = temp_rti.loc[0, 'rate_desp']
    esi['rti_grade'] = temp_rti.loc[0, 'rate_value']
    ESI=pd.DataFrame(esi,index=[0])
    '''
           添加权重信息
           '''
    w = weight[weight['parent_op_service'] == '应急能力'][['op_service_code', 'op_service_weights_value']]
    esiw = {}
    esiw['EPI'] = esi['epi_value']
    esiw['RTI'] = esi['rti_value']
    esiw = pd.DataFrame.from_dict(esiw, orient='index').reset_index().rename(
        columns={'index': 'op_service_code', 0: 'value'})
    esiw = pd.merge(esiw, w, on='op_service_code')
    esi['epi_weight'] = esiw[esiw['op_service_code'] == 'EPI']['op_service_weights_value'].values[0]
    esi['rti_weight'] = esiw[esiw['op_service_code'] == 'RTI']['op_service_weights_value'].values[0]
    ESI = pd.DataFrame(esi, index=[0])
    return ESI

#计算用户体验状况指数
def cal_USI(xtidata,ttidata,iaidata,iridata,ecidata,rating,days,weight):
    usi={}
    #计算XTI 月均单件投诉及时响应时间
    if xtidata.empty:
        XTI=0
    else:
       ### 看一下时间
        xtiData = xtidata.copy()
        xtiData['complaint_finish_time'] = pd.to_datetime(xtiData['complaint_finish_time'], format='%Y-%m-%d %H:%M:%S',errors='coerce')
        xtiData['complaint_acceptance_time'] = pd.to_datetime(xtiData['complaint_acceptance_time'], format='%Y-%m-%d %H:%M:%S',errors='coerce')
        xtiData['time'] = (xtiData['complaint_finish_time'] - xtiData['complaint_acceptance_time']).dt.days
        XTI = xtiData.groupby(['monitor_year', 'monitor_month'])['time'].mean().mean()
    xtiRating = rating[rating['index_code'] == 'XTI']
    temp_xti = xtiRating[(xtiRating['lower_value'] <= XTI) & (XTI < xtiRating['upper_value'])]
    temp_xti.reset_index(inplace=True)
    usi['xti_value'] = XTI
    usi['xti_mark'] = temp_xti.loc[0, 'rate_mark']
    usi['xti_grade_desp'] = temp_xti.loc[0, 'rate_desp']
    usi['xti_grade'] = temp_xti.loc[0, 'rate_value']
    #计算TTI 月均投诉次数
    if ttidata.empty:
        TTI=0
    else:
        ttiData = ttidata.copy()
        #除以天数再乘30
        TTI = (ttiData.groupby(['monitor_year'])['real_complaint_number'].sum().mean()/days)*30
    ttiRating = rating[rating['index_code'] == 'TTI']
    temp_tti = ttiRating[(ttiRating['lower_value'] <= TTI) & (TTI < ttiRating['upper_value'])]
    temp_tti.reset_index(inplace=True)
    usi['tti_value'] = TTI
    usi['tti_mark'] = temp_tti.loc[0, 'rate_mark']
    usi['tti_grade_desp'] = temp_tti.loc[0, 'rate_desp']
    usi['tti_grade'] = temp_tti.loc[0, 'rate_value']
    #计算IAI 月度信息发布平均准确率
    if iaidata.empty:
        IAI=1
    else:
        iaiData = iaidata.copy()
        iaiData['IAI'] = iaiData['accurate_traffic_information_number'] / iaiData['traffic_information_total_number']
        iaiData['IAI'].fillna(1,inplace=True)
        IAI=iaiData.groupby(['monitor_year'])['IAI'].mean().mean()
    iaiRating = rating[rating['index_code'] == 'IAI']
    temp_iai = iaiRating[(iaiRating['lower_value'] <= IAI) & (IAI < iaiRating['upper_value'])]
    temp_iai.reset_index(inplace=True)
    usi['iai_value'] = IAI
    usi['iai_mark'] = temp_iai.loc[0, 'rate_mark']
    usi['iai_grade_desp'] = temp_iai.loc[0, 'rate_desp']
    usi['iai_grade'] = temp_iai.loc[0, 'rate_value']
    # 计算IRI月度信息发布平均及时率
    if iridata.empty:
        IRI=1
    else:
        iriData = iridata.copy()
        iriData['IRI'] = iriData['msg_timely_num'] / iriData['msg_total_num']
        iriData['IRI'].fillna(1,inplace=True)
        IRI = iriData.groupby(['monitor_year'])['IRI'].mean().mean()
    iriRating = rating[rating['index_code'] == 'IRI']
    temp_iri = iriRating[(iriRating['lower_value'] <= IRI) & (IRI < iriRating['upper_value'])]
    temp_iri.reset_index(inplace=True)
    usi['iri_value'] = IRI
    usi['iri_mark'] = temp_iri.loc[0, 'rate_mark']
    usi['iri_grade_desp'] = temp_iri.loc[0, 'rate_desp']
    usi['iri_grade'] = temp_iri.loc[0, 'rate_value']
    #计算ECI 月度投诉完成率
    if ecidata.empty:
        ECI=1
    else:
        eciData = ecidata.copy()
        eciData['effective_complaint_number']=eciData.apply(lambda x: x.effective_complaint_success_number if x.effective_complaint_number==0 else x.effective_complaint_number,axis=1)
        ecidata['ECI']=ecidata.apply(lambda x: x.effective_complaint_success_number/x.effective_complaint_number if x.effective_complaint_number !=0 else 1,axis=1)
        # print(ecidata['ECI'])
        # exit(1)
        # eciData = eciData.effective_complaint_number.map(lambda x:int(x))
        # if  eciData==0:
        #     ECI=0
        # else:
        #     eciData['ECI'] = eciData['effective_complaint_success_number'] / eciData['effective_complaint_number']
        ECI=pd.pivot_table(ecidata,index=['monitor_year'],values='ECI',aggfunc='mean')['ECI'].values[0]
    eciRating = rating[rating['index_code'] == 'ECI']
    temp_eci = eciRating[(eciRating['lower_value'] <= ECI) & (ECI < eciRating['upper_value'])]
    temp_eci.reset_index(inplace=True)
    usi['eci_value'] = ECI
    usi['eci_mark'] = temp_eci.loc[0, 'rate_mark']
    usi['eci_grade_desp'] = temp_eci.loc[0, 'rate_desp']
    usi['eci_grade'] = temp_eci.loc[0, 'rate_value']

    '''
            添加权重信息          
            '''
    w = weight[weight['parent_op_service'] == '用户体验'][['op_service_code', 'op_service_weights_value']]
    usiw = {}
    usiw ['XTI'] = usi['xti_value']
    usiw ['TTI'] = usi['tti_value']
    usiw ['IAI'] = usi['iai_value']
    usiw ['IRI'] = usi['iri_value']
    usiw ['ECI'] = usi['eci_value']
    usiw = pd.DataFrame.from_dict(usiw, orient='index').reset_index().rename(
        columns={'index': 'op_service_code', 0: 'value'})
    usiw = pd.merge(usiw, w, on='op_service_code')
    usi['xti_weight'] = usiw[usiw['op_service_code'] == 'XTI']['op_service_weights_value'].values[0]
    usi['tti_weight'] = usiw[usiw['op_service_code'] == 'TTI']['op_service_weights_value'].values[0]
    usi['iai_weight'] = usiw[usiw['op_service_code'] == 'IAI']['op_service_weights_value'].values[0]
    usi['iri_weight'] = usiw[usiw['op_service_code'] == 'IRI']['op_service_weights_value'].values[0]
    usi['eci_weight'] = usiw[usiw['op_service_code'] == 'ECI']['op_service_weights_value'].values[0]
    USI = pd.DataFrame(usi, index=[0])
    return USI

def cal_midEvaluation(TSI,SSI,ESI,USI,weight,level):
    value = {}
    value['DSI'] = TSI['dsi_mark'][0]
    value['DTI'] = TSI['dti_mark'][0]
    value['API'] = TSI['api_mark'][0]
    value['AAI'] = SSI['aai_mark'][0]
    value['TIR'] = SSI['tir_mark'][0]
    value['EPI'] = ESI['epi_mark'][0]
    value['RTI'] = ESI['rti_mark'][0]
    value['XTI'] = USI['xti_mark'][0]
    value['TTI'] = USI['tti_mark'][0]
    value['IAI'] = USI['iai_mark'][0]
    value['IRI'] = USI['iri_mark'][0]
    value['ECI'] = USI['eci_mark'][0]
    allValue = pd.DataFrame.from_dict(value, orient='index', columns=['Value'])
    allValue = allValue.reset_index().rename(columns={'index': 'op_service_code'})
    w = weight[['op_service_code', 'op_service_name', 'op_service_weights_value', 'parent_op_service']]
    parentCode=weight['parent_op_service'].dropna().unique()
    midResult = {}
    for i in parentCode:
        tempWeight = w[w['parent_op_service'] == i]
        temp = pd.merge(allValue, tempWeight, how='left')
        temp.dropna(subset=['Value', 'op_service_weights_value'], inplace=True)
        if temp.empty:
            midResult[i] = None
        else:
            midResult[i] = (temp['op_service_weights_value'] * temp['Value']).sum() / (
                temp['op_service_weights_value'].sum())
    midResult = pd.DataFrame.from_dict(midResult, orient='index', columns=['value'])
    midResult = midResult.reset_index().rename(columns={'index': 'op_service_name'})
    result = pd.merge(midResult, w, how='left')
    # result.dropna(subset=['value'], inplace=True)
    result['op_service_name'] = result['op_service_name'] + '指数'
    result['level'] = None

    def judgeLevel(data):
        rank = level[level['operation_service_name'] == data['op_service_name']]
        temp = rank[(rank['lower_value'] <= data['value']) & (data['value'] < rank['upper_value'])]
        if temp.empty:
            return None
        else:
            return temp['level_value'].values[0]
    result['level'] = result.apply(func=judgeLevel, axis=1)
    mid = {}
    mid['tsi_value'] = result.loc[result['op_service_code'] == 'TSI', 'value'].values[0]
    mid['tsi_level'] = result.loc[result['op_service_code'] == 'TSI', 'level'].values[0]
    mid['ssi_value'] = result.loc[result['op_service_code'] == 'SSI', 'value'].values[0]
    mid['ssi_level'] = result.loc[result['op_service_code'] == 'SSI', 'level'].values[0]
    mid['esi_value'] = result.loc[result['op_service_code'] == 'ESI', 'value'].values[0]
    mid['esi_level'] = result.loc[result['op_service_code'] == 'ESI', 'level'].values[0]
    mid['usi_value'] = result.loc[result['op_service_code'] == 'USI', 'value'].values[0]
    mid['usi_level'] = result.loc[result['op_service_code'] == 'USI', 'level'].values[0]
    '''
    添加权重信息
    '''
    mid['tsi_weight'] = result.loc[result['op_service_code'] == 'TSI', 'op_service_weights_value'].values[0]
    mid['ssi_weight'] = result.loc[result['op_service_code'] == 'SSI', 'op_service_weights_value'].values[0]
    mid['esi_weight'] = result.loc[result['op_service_code'] == 'ESI', 'op_service_weights_value'].values[0]
    mid['usi_weight'] = result.loc[result['op_service_code'] == 'USI', 'op_service_weights_value'].values[0]
    midEvaluation = pd.DataFrame(mid, index=[0])
    return midEvaluation,result

def cal_FWCI(result,level):
    fwci = {}
    result=result[result['value'].notnull()]
    FWCI = ((result['value'] * result['op_service_weights_value']).sum()) / (result['op_service_weights_value'].sum())
    criteria = level[level['operation_service_code'] == 'FWCI']
    temp = criteria[(criteria['lower_value'] <= FWCI) & (FWCI < criteria['upper_value']+1)]
    fwci['fwci_value'] = FWCI
    fwci['fwci_level'] = temp['level_value'].values[0]
    FWCI = pd.DataFrame(fwci, index=[0])
    return FWCI



def cal(task_no,start,end,project_code,is_insert=True):
    dt= datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    start = datetime.datetime.strptime(start, '%Y-%m-%d %H:%M:%S')
    end = datetime.datetime.strptime(end, '%Y-%m-%d %H:%M:%S')
    days=(end-start).days+1
    print('评价周期： ',days)
    conn=mysql.setconn()
    print('正在读取数据')
    #基础表
    basicinfo = pd.read_sql(
        "select * from tb_model_op_bridge_bridge_basicinfo where project_code='" + project_code + " ' ", conn)
    #peak_time=str(basicinfo['peak_time_desc'].values[0])
    #已修改
    dsiData = pd.read_sql(
        "select * from tb_model_op_bridge_traffic_drivespeed  where monitor_hour in (7,8,17,18) and project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    #已修改
    dtidata = pd.read_sql(
        "select * from tb_model_op_bridge_traffic_flow where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    apidata = pd.read_sql(
        "select * from tb_model_op_bridge_traffic_fence_influence where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    accidentData = pd.read_sql(
        "select * from tb_model_op_bridge_traffic_accident  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    epidata = pd.read_sql(
        "select * from tb_model_op_bridge_device_material_complete  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    rtidata = pd.read_sql(
        "select * from tb_model_op_bridge_emergency_response  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    xtidata = pd.read_sql(
        "select * from tb_model_op_bridge_complaint_response  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    ttidata = pd.read_sql(
        "select * from tb_model_op_bridge_valid_complaint  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    iaidata = pd.read_sql(
        "select * from tb_model_op_bridge_release_info_accuracy where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    iridata = pd.read_sql(
        "select * from tb_model_op_bridge_release_info_timeliness where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    ecidata = pd.read_sql(
        "select * from tb_model_op_bridge_valid_complaint_handle where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    #配置表
    # 远程
    rating = pd.read_sql('select * from tb_model_op_bridge_evaluation_rating_mark', conn)
    rating['lower_value'].fillna(float('-inf'), inplace=True)
    rating['upper_value'].fillna(float('inf'), inplace=True)
    weight = pd.read_sql('select * from tb_model_op_bridge_service_weight', conn)
    level = pd.read_sql('select * from tb_model_op_bridge_criteria_level', conn)
    level['upper_value'] = level['upper_value'].fillna(float('inf'))
    print('读取数据成功')
    start=str(start)
    end=str(end)
    print('正在计算和插入TSI,SSI,ESI,USI结果')
    TSI = cal_TSI(basicinfo,dsiData, dtidata, apidata, rating,weight)
    TSI['project_code'] = project_code
    TSI['task_no'] = task_no
    TSI['Start'] = start
    TSI['End'] = end
    TSI['create_date'] = dt
    if is_insert == True:
        TSIsql = 'insert into tb_model_op_bridge_result_tsi (project_code,task_no,Start,End,dsi_value,dsi_mark,dsi_grade_desp,dsi_grade,dti_value,dti_mark,' \
                'dti_grade_desp,dti_grade,api_value,api_mark,api_grade_desp,api_grade,dsi_weight,dti_weight,api_weight,create_date) values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(TSI,TSIsql,conn)
    SSI = cal_SSI(accidentData, dtidata, basicinfo, rating,days,weight)
    SSI['project_code'] = project_code
    SSI['task_no'] = task_no
    SSI['Start'] = start
    SSI['End'] = end
    SSI['create_date'] = dt
    if is_insert == True:
        SSIsql='insert into tb_model_op_bridge_result_ssi (project_code,task_no,Start,End,aai_value,aai_mark,aai_grade_desp,aai_grade,tir_value,tir_mark,tir_grade_desp,tir_grade,aai_weight,tir_weight,create_date)' \
            ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(SSI,SSIsql,conn)
    ESI = cal_ESI(epidata, rtidata, rating,weight)
    ESI['project_code'] = project_code
    ESI['task_no'] = task_no
    ESI['Start'] = start
    ESI['End'] = end
    ESI['create_date'] = dt
    if is_insert == True:
        ESIsql='insert into tb_model_op_bridge_result_esi (project_code,task_no,Start,End,epi_value,epi_mark,epi_grade_desp,epi_grade,rti_value,rti_mark,rti_grade_desp,rti_grade,epi_weight,rti_weight,create_date)' \
            ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(ESI,ESIsql,conn)
    USI = cal_USI(xtidata, ttidata, iaidata, iridata, ecidata, rating,days,weight)
    USI['project_code']=project_code
    USI['task_no']=task_no
    USI['Start']=start
    USI['End']=end
    USI['create_date']=dt
    if is_insert == True:
        UIsql= 'insert into tb_model_op_bridge_result_usi (project_code,task_no,Start,End,xti_value,xti_mark,xti_grade_desp,xti_grade,tti_value,tti_mark,tti_grade_desp,tti_grade,iai_value' \
            ',iai_mark,iai_grade_desp,iai_grade,iri_value,iri_mark,iri_grade_desp,iri_grade,eci_value,eci_mark,eci_grade_desp,eci_grade,xti_weight,tti_weight,iai_weight,iri_weight,eci_weight,create_date) values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(USI,UIsql,conn)

    print('正在计算和插入中间评价结果')
    midResult, finalResult = cal_midEvaluation(TSI, SSI, ESI, USI, weight, level)
    midResult['project_code'] = project_code
    midResult['task_no'] = task_no
    midResult['Start'] = start
    midResult['End'] = end
    midResult['create_date'] = dt
    midResult=midResult.astype(object).where(pd.notnull(midResult),None)
    if is_insert == True:
        midResultsql='insert into tb_model_op_bridge_result_mid_evaluation (project_code,task_no,Start,End,tsi_value,tsi_level,ssi_value,ssi_level,esi_value,esi_level,usi_value,usi_level,tsi_weight,ssi_weight,esi_weight,usi_weight,create_date)' \
            ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(midResult,midResultsql,conn)
    print('正在计算和插入总体运营评价结果')
    FWCI = cal_FWCI(finalResult, level)
    FWCI['project_code'] = project_code
    FWCI['task_no'] = task_no
    FWCI['Start'] = start
    FWCI['End'] = end
    FWCI['create_date'] = dt
    score = FWCI['fwci_value'].to_string()[5:15]
    grade = FWCI['fwci_level'].to_string()[5:8]
    if is_insert == True:
        FWCIsql = 'insert into tb_model_op_bridge_result_all_evaluation (project_code,task_no,Start,End,fwci_value,fwci_level,create_date)' \
                                ' values (%s,%s,%s,%s,%s,%s,%s)'

        mysql.insert(FWCI,FWCIsql,conn)

    if is_insert == True:
        conn.commit()
    conn.close()
    return score, grade
