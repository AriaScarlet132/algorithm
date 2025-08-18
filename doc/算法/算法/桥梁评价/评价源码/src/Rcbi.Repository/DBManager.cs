using System;
using System.Collections.Concurrent;

using Rcbi.Core;
using Rcbi.AspNetCore.Helper;

namespace Rcbi.Repository
{
    public class DBManager
    {
        /// <summary>
        /// 基础的数据库连接
        /// </summary>
        public static readonly string connectionString = ConfigHelper.GetConfig("ConnectionStrings.RcbiDb");

        [ThreadStatic]
        static DbHelper core_helper;

        [ThreadStatic]
        static ConcurrentDictionary<string, DbHelper> dynamic_helpers;

        private static ConcurrentDictionary<string, DbHelper> DynamicHelper 
        {
            get 
            {
                if (dynamic_helpers == null) {
                    dynamic_helpers = new ConcurrentDictionary<string, DbHelper>();
                }
                return dynamic_helpers;
            }
        }

        /// <summary>
        /// 基础的数据库访问类
        /// </summary>
        /// <returns></returns>
        public  static DbHelper CoreHelper
        {
            get
            {
                if (core_helper == null)
                {
                    core_helper = new DbHelper(connectionString, "MySql.Data.MySqlClient");
                }
                return core_helper;
            }
            
        }
        /// <summary>
        /// 获取DB配置中的数据库访问类
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static DbHelper CreateDBHelper(string configName) 
        {
            if (DynamicHelper.ContainsKey(configName))
                return DynamicHelper[configName];

            
            return null;
        }
        /// <summary>
        /// 动态创建数据库访问类
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderName"></param>
        /// <returns></returns>
        public static DbHelper CreateDBHelper(string connectionString, string dbProviderName) 
        {
            if (DynamicHelper.ContainsKey(connectionString))
                return DynamicHelper[connectionString];

            var helper = new DbHelper(connectionString, dbProviderName);

            return DynamicHelper.GetOrAdd(connectionString, helper);
        }
    }
}
