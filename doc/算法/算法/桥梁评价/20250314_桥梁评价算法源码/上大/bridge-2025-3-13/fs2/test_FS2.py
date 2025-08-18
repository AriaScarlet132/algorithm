import calculate_附属2
import mysql
#本代码功能测试附属设施评价内容
#本代码暂支持读取消息队列数据
if __name__ == '__main__':
    # 1.获取任务号 navicat 执行
        # SELECT TaskNO,ProjectID from tb_model_result_main
        #where Model_Type='AFEVA' and Facility_Type='Bridge'
        # order by ID desc
    #选取任务号（TaskNO字段）：SHSMP3-20240226134357
    #选择项目ID (ProjectID字段) SHSMP3
    task_no="SHSMP3-20240226134357"
    project_code="SHSMP3"

    # 2.进行附属评价 函数传入任务号和项目ID
    calculate_附属2.cal(task_no,project_code)

    #3 .更新评价状态success 函数传入任务号
    mysql.update_mq_success(task_no)

    #4. navicat 查看结果表
    # 子设施： SELECT * from tb_model_af_result_category where task_no='SHSMP3-20240226134357';
    # 分设施：SELECT * from tb_model_af_result_type where task_no='SHSMP3-20240226134357';
    # 附属设施总体：SELECT * from tb_model_af_result where task_no='SHSMP3-20240226134357';


