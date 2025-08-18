import mysql
import calculate_机电
#本代码功能测试机电设施评价内容
#本代码暂支持读取消息队列数据
if __name__ == '__main__':
    # 1.获取任务号 navicat 执行
    # SELECT TaskNO,ProjectID,DataSource_StartDate,DataSource_EndDate from tb_model_result_main
    # where Model_Type='JDEVA' and Facility_Type='Bridge'
    # order by ID desc
    # 选取任务号（TaskNO字段）：SHSMP3-20240122060415
    # 选择项目ID (ProjectID字段) SHSMP3
    # 选取开始时间(DataSource_StartDate 字段) 2024-01-15 00:00:00
    # 选取结束时间（DataSource_EndDate 字段   2024-01-21 00:00:00
    task_no = "SHSDH1-20240304082817"
    project_code = "SHSMP3"
    start="2024-02-26 00:00:00"
    end="2024-03-03 00:00:00"

    # 2.进行机电评价 函数传入任务号和项目ID
    # task_no, start, end, project_code
    calculate_机电.cal(task_no=task_no,start=start,end=end,project_code=project_code)

    # 3 .更新评价状态success 函数传入任务号
    mysql.update_mq_success(task_no)

    # 4. navicat 查看结果表
    # 设备级：SELECT * from tb_model_mes_result_equipment where task_no='SHSMP3-20240122060415';
    # 子设备：SELECT * from tb_model_mes_result_subsystem where task_no='SHSMP3-20240122060415';
    # 分设备：SELECT * from tb_model_mes_result_midsystem where task_no='SHSMP3-20240122060415';
    # 机电总体：SELECT * from tb_model_mes_result_mesystem where task_no='SHSMP3-20240122060415';
