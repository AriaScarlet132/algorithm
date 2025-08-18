import pandas as pd
def get_model_result_main(conn,task_no):
    result = pd.read_sql("select DataSource_StartDate, DataSource_EndDate,ProjectID FROM tb_model_result_main where TaskNO = '" + task_no + "' ", conn)
    start=result['DataSource_StartDate']
    end=result['DataSource_EndDate']
    project_code=result['ProjectID']
    start = start.to_string()[5:15]+" 00:00:00"
    end = end.to_string()[5:15]+" 00:00:00"
    project_code = project_code.to_string()[5:8]
    return start,end,project_code