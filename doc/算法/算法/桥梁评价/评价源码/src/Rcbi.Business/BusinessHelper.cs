using System;

using Rcbi.Entity;
using Rcbi.Core.Extensions;
using Rcbi.Entity.Domain;
using Rcbi.Repository;
using Rcbi.Core;
using Rcbi.Entity.Query;

namespace Rcbi.Business
{
    /// <summary>
    /// 业务助手类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessHelper<T> where T : BaseModelEntity
    {
        /// <summary>
        /// 创建实体类的插入必须内容默认值
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static T BuildInserMust(T entity, User user) 
        {
            if (entity == null) return default(T);

            try
            {
                entity.CreateDate = DateTime.Now;//创建时间默认当前时间
                entity.uuid = Guid.NewGuid().ToString("N");//uuid默认值
                entity.CreateUser = (user == null ? null : user.UserName);

                return entity;
            }
            catch {
                return entity;
            }
        }
        /// <summary>
        /// 创建实体类的更新必须内容默认值
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static T BuildUpdateMust(T entity, User user) 
        {
            if (entity == null) return null;

            entity.UpdateDate = DateTime.Now;//更新时间默认当前时间
            entity.UpdateUser = (user == null ? null : user.UserName);//更新用户名人当前登录人

            return entity;
        }
    }
}
