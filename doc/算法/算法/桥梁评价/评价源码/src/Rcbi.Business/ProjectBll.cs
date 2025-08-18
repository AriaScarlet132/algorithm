using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Rcbi.Entity;
using Rcbi.Core.Extensions;
using Rcbi.Entity.Domain;
using Rcbi.Repository;
using Rcbi.Core;
using Rcbi.Entity.Query;

namespace Rcbi.Business
{
    public class ProjectBll
    {
        /// <summary>
        /// 根据人员获取所属项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<Project> GetProjects(long? userId = null)
        {
            using (var db = new ProjectRepository())
            {
                return (userId.HasValue ? db.GetProjects(userId.Value) : db.GetProjects()).ToList<Project>();
            }
        }

        /// <summary>
        /// 根据人员获取所属项目
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<Project> GetProjects(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            using (var db = new ProjectRepository())
            {
                return (user.IsAdmin ? db.GetProjects() : db.GetProjects(user.UserId)).ToList<Project>();
            }
        }

        /// <summary>
        /// 根据人员/项目名称获取所属项目
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IPagedList<Project> GetProjects(ProjectQuery query)
        {
            using (var db = new ProjectRepository())
            {
                int total;
                var dt =db.GetProjects(query, out total);
                return new PagedList<Project>(
                    dt.ToList<Project>(),
                    query.Page,
                    query.Limit,
                    total);
            }
        }

        /// <summary>
        /// 根据项目ID获取项目
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static Project GetProject(long projectId)
        {
            using (var db = new ProjectRepository())
            {
                return db.GetProject(projectId).ToDefaultOrFristEntity<Project>();
            }
        }

        /// <summary>
        /// 根据项目编码获取项目
        /// </summary>
        /// <param name="projectCode"></param>
        /// <returns></returns>
        public static Project GetProject(string projectCode)
        {
            using (var db = new ProjectRepository())
            {
                return db.GetProject(projectCode).ToDefaultOrFristEntity<Project>();
            }
        }

        /// <summary>
        /// 根据人员删除项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int RemoveProjects(long userId)
        {
            using (var db = new ProjectRepository())
            {
                return db.RemoveProjects(userId);
            }
        }

        /// <summary>
        /// 是否存在指定项目
        /// </summary>
        /// <param name="projectCode"></param>
        /// <returns></returns>
        public static bool IsExists(string projectCode)
        {
            using (var db = new ProjectRepository())
            {
                return db.IsExists(projectCode);
            }
        }

        public static bool IsExistsOrg(ProjectOrg model)
        {
            using (var db = new ProjectRepository())
            {
                return db.IsExistsOrg(model);
            }
        }
        /// <summary>
        /// 根据项目uuid获取项目
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static Project GetProjectByUuid(string uuid)
        {
            using (var db = new ProjectRepository())
            {
                return db.GetProjectByUuid(uuid).ToDefaultOrFristEntity<Project>();
            }
        }

        /// <summary>
        /// 项目修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Update(Project entity,string userName)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var vresult = new OpreationResult<string>();

            using (var db = new ProjectRepository())
            {
                var project = db.GetProjectByUuid(entity.uuid);
                if (project == null)
                    throw new InvalidOperationException("not exists user");


                return db.Update(entity, userName); 
            }
        }

        /// <summary>
        /// 根据人员获取所属项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IPagedList<ProjectSetUser> GetUserByProjectCode(string projectCode)
        {
            using (var db = new ProjectRepository())
            {
                var list = db.GetUserByProjectCode(projectCode).ToList<ProjectSetUser>();
                return new PagedList<ProjectSetUser>(list, 1, list.Count, list.Count);
            }
        }
        /// <summary>
        /// 项目人员新增或删除 opt为true是新增否则删除
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="userCode"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public static bool ProjectSetUser(string projectCode, string userCode, string opt)
        {
            using (var db = new ProjectRepository())
            {
                return opt.Equals("true")? db.ProjectSetUserAdd(projectCode, userCode): db.ProjectSetUserDel(projectCode, userCode);
            }
        }
    }
}
