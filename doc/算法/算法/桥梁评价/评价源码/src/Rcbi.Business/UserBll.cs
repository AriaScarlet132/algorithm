using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Newtonsoft.Json.Linq;

using Rcbi.Entity;
using Rcbi.Entity.Enums;
using Rcbi.Core.Extensions;
using Rcbi.Entity.Domain;
using Rcbi.Repository;
using Rcbi.Core;
using Rcbi.Entity.Query;
using Rcbi.AspNetCore.Helper;
using Rcbi.Business.FluentValidator;
using Rcbi.Business.Validators;
using Rcbi.AspNetCore;

namespace Rcbi.Business
{
    public class UserBll
    {
        /// <summary>
        /// 获取用户，根据用户ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUser(long userId)
        {
            if (userId <= 0)
                return null;

            using (UserRepository db = new UserRepository())
            {
                return db.GetUser(userId);
            }
        }

        /// <summary>
        /// 获取用户，根据用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User GetUser(string userName)
        {
            if (userName.IsNullOrEmpty())
                return null;

            using (UserRepository db = new UserRepository())
            {
                return db.GetUser(userName);
            }
        }

        /// <summary>
        /// 获取用户，根据用户名和密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetUser(string userName, string password)
        {
            if (userName.IsNullOrEmpty() ||
               password.IsNullOrEmpty())
            {
                return null;
            }

            password = AesHelper.Encrypt(password);

            using (UserRepository db = new UserRepository())
            {
                return db.GetUser(userName, password);
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OpreationResult<string> Registe(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var vresult = new OpreationResult<string>();

            var result = (new UserValidator()).Validate(entity);
            if (!result.IsValid)
            {
                vresult.AddRange(result.Errors.AsStrings());
                return vresult;
            }

            entity.Password = AesHelper.Encrypt(entity.Password);

            using (UserRepository db = new UserRepository())
            {
                if (db.GetUser(entity.UserName) != null)
                {
                    vresult.Add(FluentValidationResource.UserExists);
                    return vresult;
                }

                db.Insert(entity);

                return vresult;
            }
        }

        /// <summary>
        /// 用户新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OpreationResult<string> Insert(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var vresult = new OpreationResult<string>();

            var result = (new UserValidator()).Validate(entity);
            if (!result.IsValid)
            {
                vresult.AddRange(result.Errors.AsStrings());
                return vresult;
            }

            entity.Password = AesHelper.Encrypt(entity.Password);

            using (UserRepository db = new UserRepository())
            {
                if (db.GetUser(entity.UserName) != null)
                {
                    vresult.Add(FluentValidationResource.UserExists);
                    return vresult;
                }

                BusinessHelper<User>.BuildInserMust(entity, entity);

                db.Insert(entity);

                return vresult;
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OpreationResult<string> Update(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var vresult = new OpreationResult<string>();

            using (var db = new UserRepository())
            {
                var _user = db.GetUser(entity.UserName);
                if (_user == null)
                    throw new InvalidOperationException("not exists user");


                var result = (new UserValidator()).Validate(_user);
                if (!result.IsValid)
                {
                    vresult.AddRange(result.Errors.AsStrings());
                    return vresult;
                }

                BusinessHelper<User>.BuildUpdateMust(_user, _user);

                db.Modify(entity);

                return vresult;
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool MyUserUpdate(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = Convert.ToString(entity.UserId);
            using (var db = new UserRepository())
            {
                var result = db.MyUserUpdate(entity);
                return result;
            }
        }

        /// <summary>
        /// 获取用户，分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IPagedList<User> GetPagedList(CommonQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            using (UserRepository db = new UserRepository())
            {
                int total;
                var dt = db.GetList(query, out total);

                return new PagedList<User>(
                    dt.ToList<User>(),
                    query.PageIndex,
                    query.PageSize,
                    total);
            }
        }

        /// <summary>
        /// 获取系统用户，不分页
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<JObject> GetList()
        {
            using (UserRepository db = new UserRepository())
            {
                return db.GetList().ToJObjects();
            }
        }

        /// <summary>
        /// 获取施工人员，不分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTable GetWsList()
        {
            using (UserRepository db = new UserRepository())
            {
                return db.GetWsList();
            }
        }

        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<Role> GetRoles(long userId)
        {
            using (UserRepository db = new UserRepository())
            {
                return db.GetRoles(userId).ToList<Role>();
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ChangePassword(long userId, string password)
        {
            if (userId < 0 ||
                password.IsNullOrEmpty())
                return false;

            password = AesHelper.Encrypt(password);

            using (var db = new UserRepository())
            {
                return db.SetPassword(userId, password) > 0;
            }
        }

        /// <summary>
        /// 设置用户审核通过
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool SetEnable(long userId)
        {
            if (userId < 0)
                return false;

            using (var db = new UserRepository())
            {
                return db.UpdateState(userId, UserState.Enable) > 0;
            }
        }

        /// <summary>
        ///  根据OpenId 获取用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static User GetUserByOpenId(string openId)
        {
            if (openId.IsNullOrEmpty())
                return null;

            using (UserRepository db = new UserRepository())
            {
                return db.GetUserByopenId(openId);
            }
        }

        /// <summary>
        /// 微信用户绑定
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="wxOpenId"></param>
        /// <returns></returns>
        public static bool UpdateUserBinding(long userid, string openid)
        {
            using (var db = new UserRepository())
            {
                return db.UpdateUserBind(userid, openid) > 0;
            }

        }

        /// <summary>
        /// 微信用户解绑
        /// </summary>
        /// <param name="wxOpenId"></param>
        /// <returns></returns>
        public static bool UpdateUserUnBinding(string openid)
        {
            //wxOpenId = "oS3IVv3DhQ2V9zu9OHeNCXSjwOLA";
            using (var db = new UserRepository())
            {
                return db.UpdateUserUnBind(openid) > 0;
            }
        }

        public static IPagedList<ProjectUser> GetPagedList(CommonQuery query, long projectId)
        {
            using (var db = new UserRepository())
            {
                int total = 0;
                var dt = db.GetPagedList(query, projectId, out total);

                return new PagedList<ProjectUser>(dt.ToList<ProjectUser>(),
                  query.PageIndex,
                  query.PageSize,
                  total);
            }
        }

        public static IList<ProjectUser> GetUserProject(string openid, int project_id)
        {
            using (var db = new UserRepository())
            {
                return db.GetUserProject(openid, project_id).ToList<ProjectUser>();
            }
        }

    }
}
