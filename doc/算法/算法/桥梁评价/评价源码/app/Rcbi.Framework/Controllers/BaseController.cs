using System;
using System.IO;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using Rcbi.Entity.Enums;
using Rcbi.Business;
using Rcbi.Core;
using Rcbi.Core.Extensions;
using Rcbi.Framework.Response;
using Rcbi.Entity.Domain;

namespace Rcbi.Framework.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private const string PROJECT_KEY = "project";
        private const string PROJECT_LIST_KEY = "project_list";

        protected User GetUser()
        {
            var userClaims = (ClaimsIdentity)User.Identity;

            if (userClaims == null || userClaims.Claims == null || userClaims.Claims.Count() <= 0)
                return null;

            return JsonConvert.DeserializeObject<User>(userClaims.Claims.First().Value);
        }

        protected Project CurrentProject
        {
            get
            {
                var jsonString = this.HttpContext.Session.GetString(PROJECT_KEY);

                if (!jsonString.IsNullOrEmpty())
                    return JsonConvert.DeserializeObject<Project>(jsonString);

                return this.ProjectsList.FirstOrDefault();
            }
            set
            {
                if (value == null)
                    throw new InvalidOperationException();

                this.HttpContext.Session.SetString(PROJECT_KEY, JsonConvert.SerializeObject(value));
            }
        }

        protected IList<Project> ProjectsList
        {
            get
            {
                var jsonArrayString = this.HttpContext.Session.GetString(PROJECT_LIST_KEY);

                if (!jsonArrayString.IsNullOrEmpty())
                    return JsonConvert.DeserializeObject<IList<Project>>(jsonArrayString);

                var projects = ProjectBll.GetProjects(this.GetUser());

                this.HttpContext.Session.SetString(PROJECT_LIST_KEY, JsonConvert.SerializeObject(projects));

                return projects;
            }
        }

        protected string GetProjectNameByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }
            return ProjectsList.Where(a => a.ProjectCode == code).FirstOrDefault().ShortName;
        }
    }
}
