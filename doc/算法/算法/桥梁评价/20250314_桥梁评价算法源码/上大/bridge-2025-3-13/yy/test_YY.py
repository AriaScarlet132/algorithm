import calculate_运营
import mysql
#本代码功能测试运营服务评价内容
#本代码暂支持读取消息队列数据

if __name__ == '__main__':
    # 1.获取任务号 navicat 执行
    # SELECT TaskNO,ProjectID,DataSource_StartDate,DataSource_EndDate from tb_model_result_main
    # where Model_Type='OSEVA' and Facility_Type='Bridge'
    # order by ID desc
    # 选取任务号（TaskNO字段）：SHSMP3-20240226203827
    # 选择项目ID (ProjectID字段) SHSMP3
    # 选取开始时间(DataSource_StartDate 字段) 2024-01-01 00:00:00
    # 选取结束时间（DataSource_EndDate 字段   2024-01-31 00:00:00

    task_no = "SHSMP3-20240304061408"
    project_code = "SHSMP3"
    start = "2024-01-01 00:00:00"
    end = "2024-01-31 00:00:00"

    # 2.进行运营评价 函数传入任务号和项目ID
    # task_no,start,end,project_code
    calculate_运营.cal(task_no=task_no, start=start, end=end, project_code=project_code)

    # 3 .更新评价状态success 函数传入任务号
    mysql.update_mq_success(task_no)

    # 4. navicat 查看结果表
    # ESI结果：SELECT * from tb_model_op_bridge_result_esi where task_no='SHSMP3-20240226203827';
    # SSI结果：SELECT * from tb_model_op_bridge_result_ssi where task_no='SHSMP3-20240226203827';
    # TSI结果：SELECT * from tb_model_op_bridge_result_tsi where task_no='SHSMP3-20240226203827';
    # USI结果：SELECT * from tb_model_op_bridge_result_usi where task_no='SHSMP3-20240226203827';

    # 运营分指标结果: SELECT * from tb_model_op_bridge_result_mid_evaluation where task_no='SHSMP3-20240226203827';
    # 运营总体评价：SELECT * from tb_model_op_bridge_result_all_evaluation where task_no='SHSMP3-20240226203827';