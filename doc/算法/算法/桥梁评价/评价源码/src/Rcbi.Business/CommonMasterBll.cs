using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Linq;

using FluentValidation.Results;

using Rcbi.Entity;
using Rcbi.Core.Attributes;
using Rcbi.Core.Extensions;
using Rcbi.Entity.Domain;
using Rcbi.Repository;
using Rcbi.Core;
using Rcbi.Business.FluentValidator;

namespace Rcbi.Business
{
    /// <summary>
    /// 公共master业务操作
    /// </summary>
    public class CommonMasterBll
    {
        private static Assembly assembly = Assembly.Load("Rcbi.Business");

        /// <summary>
        /// 获得实体类型对应实体目标方法
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="repositoryType">数据库操作类型</param>
        /// <param name="invokerTarget">目标</param>
        private static void InstanceInvokerTarget(Type entityType, ref Type repositoryType, ref object invokerTarget)
        {
            repositoryType = typeof(CommonMasterRepository<>);
            repositoryType = repositoryType.MakeGenericType(entityType);
            invokerTarget = Activator.CreateInstance(repositoryType);
        }
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="entityType">实体类型</param>
        /// <returns>分页的数据列表</returns>
        public static IPagedList<object> GetPagedList(BaseQueryEntity query, Type entityType)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                int total = 0;//总记录条数
                object[] args = new object[] { query, total };

                //调用数据库操作类型的通用方法：GetList，根据实体类
                var result = repositoryType.InvokeMember("GetList",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    args);

                var dt = result as DataTable;
                IList<object> items = null;
                if (dt != null)
                {
                    items = dt.ToList(entityType);//datatable转实体类
                }

                return new PagedList<object>(items,
                    query.PageIndex,
                    query.PageSize,
                    (int)args[1]);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 根据查询条件查询列表数据
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="query">查询条件</param>
        /// <returns>分页的列表数据</returns>
        public static IPagedList<T> GetPagedList<T>(BaseQueryEntity query)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(typeof(T), ref repositoryType, ref target);

                int total = 0;//总记录条数
                object[] args = new object[] { query, total };
                //调用数据库操作类型的通用方法：GetList，根据实体类
                var result = repositoryType.InvokeMember("GetList",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    args);

                var dt = result as DataTable;
                IList<T> items = null;
                if (dt != null)
                {
                    items = dt.ToList<T>();//datatable转实体类
                }

                return new PagedList<T>(items,
                    query.PageIndex,
                    query.PageSize,
                    (int)args[1]);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 返回不分页的数据列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="entityType">实体类型</param>
        /// <returns></returns>
        public static IList<object> GetList(BaseQueryEntity query, Type entityType)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                object[] args = new object[] { query };

                var result = repositoryType.InvokeMember("GetList",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    args);

                var dt = result as DataTable;
                IList<object> items = null;
                if (dt != null)
                {
                    items = dt.ToList(entityType);
                }

                return new List<object>(items);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 返回不分页的数据列表
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public static IList<T> GetList<T>(BaseQueryEntity query)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(typeof(T), ref repositoryType, ref target);

                object[] args = new object[] { query };

                var result = repositoryType.InvokeMember("GetList",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    args);

                var dt = result as DataTable;
                IList<T> items = null;
                if (dt != null)
                {
                    items = dt.ToList<T>();
                }

                return items;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 通过id获取实体
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static object GetById(Type entityType, object id)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                return repositoryType.InvokeMember("GetById",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    new object[] { id });
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 通过key获取实体
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="id">key</param>
        /// <returns></returns>
        public static object GetByKey(Type entityType, object id)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                //反射创建对应实体和方法
                InstanceInvokerTarget(entityType, ref repositoryType, ref target);
                object o =
                 repositoryType.InvokeMember("GetByKey",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    new object[] { id });
                return o;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 通过实体插入到对应表
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public static OpreationResult<string> Insert(Type entityType, object entity, User user)
        {
            int primaryId;
            return Insert(entityType, entity, user, out primaryId);
        }
        
        /// <summary>
        /// 通过实体插入相关表，并返回自增id
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="entity">实体</param>
        /// <param name="primaryId">主键自增id</param>
        /// <returns></returns>
        public static OpreationResult<string> Insert(Type entityType, object entity, User user, out int primaryId)
        {
            Type repositoryType = null;
            object target = null;
            primaryId = -1;

            try
            {
                var optresult = new OpreationResult<string>();
                //反射创建对应实体和方法
                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                //业务验证
                Type validatorType = null;

                try
                {
                    validatorType = assembly.GetType("Rcbi.Business.Validators." + entityType.Name + "Validator");
                }
                catch
                {

                }
                //调用验证方法
                if (validatorType != null)
                {
                    var validResult = validatorType.InvokeMember("Validate",
                         BindingFlags.Default | BindingFlags.InvokeMethod,
                         null,
                         Activator.CreateInstance(validatorType),
                         new object[] { entity }) as ValidationResult;

                    if (validResult != null && !validResult.IsValid)
                    {
                        optresult.AddRange(validResult.Errors.AsStrings());
                        return optresult;
                    }
                }
                //新增操作实体默认信息加载
                BusinessHelper<BaseModelEntity>.BuildInserMust((BaseModelEntity)entity, user);

                //调用数据操作类通用方法：Insert
                primaryId = (int)repositoryType.InvokeMember("Insert",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    new object[] { entity });

                //返回的自增id判断
                if (!(primaryId > 0))
                {
                    optresult.Add(FluentValidationResource.InsertToDatabaseFail);
                }

                return optresult;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }

        /// <summary>
        /// 根据实体做更新操作
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public static OpreationResult<string> Update(Type entityType, object entity, User user)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                var optresult = new OpreationResult<string>();

                //反射创建对应实体和方法

                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                //更新默认值加载

                BusinessHelper<BaseModelEntity>.BuildUpdateMust((BaseModelEntity)entity, user);

                //更新验证

                Type validatorType = null;

                try
                {
                    validatorType = assembly.GetType("Rcbi.Business.Validators." + entityType.Name + "Validator");
                }
                catch
                {

                }
                //调用验证方法
                if (validatorType != null)
                {
                    var validResult = validatorType.InvokeMember("Validate",
                         BindingFlags.Default | BindingFlags.InvokeMethod,
                         null,
                         Activator.CreateInstance(validatorType),
                         new object[] { entity }) as ValidationResult;

                    if (validResult != null && !validResult.IsValid)
                    {
                        optresult.AddRange(validResult.Errors.AsStrings());
                        return optresult;
                    }
                }
                //调用数据操作类的方法：Update
                var result = (int)repositoryType.InvokeMember("Update",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    new object[] { entity });

                //更新操作是否成功判断
                if (!(result > 0))
                {
                    optresult.Add(FluentValidationResource.UpdateToDatabaseFail);
                }

                return optresult;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 批量删除才做
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="ids">主键id列表</param>
        /// <returns></returns>
        public static OpreationResult<string> Delete(Type entityType, IList<string> ids)
        {
            Type repositoryType = null;
            object target = null;

            try
            {
                var optresult = new OpreationResult<string>();

                //删除对应的主键不能为空

                if (ids == null || ids.Count == 0)
                {
                    optresult.Add(FluentValidationResource.DeleteItemIsEmpty);
                    return optresult;
                }

                //反射创建对应实体和方法

                InstanceInvokerTarget(entityType, ref repositoryType, ref target);

                //循环做删除操作

                foreach (var id in ids)
                {
                    var entity = Activator.CreateInstance(entityType);

                    (entity as BaseEntity).uuid = id;
                    //SetPrimaryKey(entityType, entity, id);

                    //调用数据操作冷的删除方法：Delete,一般都是逻辑删除。

                    var result = (int)repositoryType.InvokeMember("Delete",
                            BindingFlags.Default | BindingFlags.InvokeMethod,
                            null,
                            target,
                            new object[] { entity });

                    if (!(result > 0))
                    {
                        optresult.Add(FluentValidationResource.DeleteFail.Replace("{id}", id.ToString()));
                    }
                }

                return optresult;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }

        /// <summary>
        /// 批量插入操作
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="items">实体泛型的list</param>
        /// <returns></returns>
        public static OpreationResult<string> BatchInsert<T>(IList<T> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentNullException("batch insert items is null");

            Type repositoryType = null;
            object target = null;

            try
            {
                //获取实体对应的表名
                TableInfo tableInfo = PocoData.ForType(typeof(T));

                var optresult = new OpreationResult<string>();
                //表名不能为空
                if (tableInfo == null || tableInfo.TabelName.IsNullOrEmpty())
                    throw new InvalidOperationException("not find table attribute for type of " + typeof(T).FullName);

                var tableName = tableInfo.TabelName;
                var dataTable = new DataTable();
                //实体类的列转换为datatable的列
                foreach (var column in tableInfo.ColumnInfos)
                {
                    if (column.IsPrimaryKey ||
                        column.PropertyInfo.IsDefined(typeof(NotInsertAttribute), false))
                        continue;
                    var fieldType = (column.PropertyInfo.PropertyType.IsGenericType &&
                                column.PropertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ?
                                Nullable.GetUnderlyingType(column.PropertyInfo.PropertyType) : column.PropertyInfo.PropertyType;
                    dataTable.Columns.Add(new DataColumn(column.ColumnName, fieldType));
                }
                //实体列表内容转换为datatable的行
                foreach (var item in items)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (var column in tableInfo.ColumnInfos)
                    {
                        if (column.IsPrimaryKey ||
                            column.PropertyInfo.IsDefined(typeof(NotInsertAttribute), false))
                            continue;
                        if(column.PropertyInfo.GetValue(item)==null)
                            row[column.ColumnName] = DBNull.Value;
                        else
                            row[column.ColumnName] = column.PropertyInfo.GetValue(item);

                        //if (row[column.ColumnName] == null)
                        //    row[column.ColumnName] = DBNull.Value;
                    }

                    dataTable.Rows.Add(row);
                }

                //反射创建对应实体和方法
                InstanceInvokerTarget(typeof(T), ref repositoryType, ref target);

                //调用数据操作类的方法：BatchInsert批量插入数据

                var result = (int)repositoryType.InvokeMember("BatchInsert",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    target,
                    new object[] { dataTable, tableName });

                if (!(result > 0))
                {
                    optresult.Add(FluentValidationResource.InsertToDatabaseFail);
                }

                return optresult;

            }
            catch
            {
                throw;
            }
            finally
            {
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }
        }
        /// <summary>
        /// 设置实体的主键
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="entity">实体</param>
        /// <param name="id">主键id</param>
        private static void SetPrimaryKey(Type entityType, object entity, int id)
        {
            TableInfo tableInfo = PocoData.ForType(entityType);

            var primaryKeyColumnInfo = tableInfo.ColumnInfos.Where((c) =>
                c.IsPrimaryKey)
                .FirstOrDefault();

            if (primaryKeyColumnInfo == null)
                throw new InvalidOperationException("not find the Primary key");

            primaryKeyColumnInfo.PropertyInfo.SetValue(entity, id);
        }
    }
}
