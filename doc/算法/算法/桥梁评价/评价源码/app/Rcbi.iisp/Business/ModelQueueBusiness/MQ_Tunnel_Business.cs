using Newtonsoft.Json;
using Rcbi.AspNetCore.Helper;
using Rcbi.iisp.Business.ModelMsgEntity;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.iisp.Business.ModelQueueBusiness
{
    public class MQ_Tunnel_Business
    {
        public static void Execute(string msg)
        {

            if (string.IsNullOrEmpty(msg))
            {
                return;
            }
            try
            {
                MsgBase msgBaseModel = JsonConvert.DeserializeObject<MsgBase>(msg);
                LogHelper.TaskInfo(msgBaseModel.TaskNO, "", "分析过程", msg);
                using (IispRepository db = new IispRepository())
                {
                    //update
                    bool result = db.UpdateModelStatus(msgBaseModel.TaskNO, msgBaseModel.ModelStatus);
                    if (!result)
                    {
                        return;
                    }

                    //last status
                    if (msgBaseModel.ModelStatus == ModelRunState.Success.ToString())
                    {
                        var mainModel = db.GetModelResultMain(msgBaseModel.TaskNO);
                        LogHelper.TaskInfo(msgBaseModel.TaskNO, mainModel.model_type, "分析完成", JsonConvert.SerializeObject(mainModel));
                        if (mainModel == null)
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(mainModel.callback_url))
                        {
                            return;
                        }
                        //callbacks asyn
                        Task.Run(() =>
                        {
                            string callbackResult = new HttpHelper().DoPost(mainModel.callback_url, new Dictionary<string, string>());
                            LogHelper.TaskInfo(msgBaseModel.TaskNO, mainModel.model_type, "分析回调", callbackResult);
                        });
                    }
                }

            }
            catch (Exception ex) {
                LogHelper.Error(ex.ToString());
            }
        }
    }
}
