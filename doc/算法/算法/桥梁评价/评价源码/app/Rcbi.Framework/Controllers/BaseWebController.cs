/*
using System;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Web.Routing;
using System.Web.Security;
using System.ComponentModel.DataAnnotations.Schema;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json.Linq;

using Rcbi.Core;
using Rcbi.Core.Data;
using Rcbi.Core.Infrastructure;
using Rcbi.Common.Caching;
using Rcbi.Business;
using Rcbi.Framework.Resource;
using Rcbi.Entity.Enums;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Query;
using Rcbi.Entity.Extensions;

namespace Rcbi.Framework.Controllers
{
    public abstract class BaseWebController : BaseAuthController
    {
        private const string SESSION_PROJECT_LIST = "project-list";
        private const string SESSION_PROJECT = "project";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public override bool AllowAccess(AuthorizationContext filterContext)
        {
            return base.AllowAccess(filterContext);
        }

        public Project CurrentProject
        {
            get
            {
                var project = this.Session[SESSION_PROJECT] as Project;
        
                if (project == null) {
                    project = this.AllProjects.FirstOrDefault();
                    this.Session[SESSION_PROJECT] = project;
                }
                return project;
            }
            set
            {
                this.Session[SESSION_PROJECT] = value;
            }
        }

        public IList<Project> ProjectList
        {
            get
            {
                var projects = this.AllProjects;

                var current = this.CurrentProject;

                if (projects != null && current != null)
                {
                    var items = new List<Project>();

                    foreach (var p1 in projects)
                    {
                        if (p1.ProjectIdParent == current.ProjectId) {

                            items.Add(p1);

                            foreach (var p2 in projects)
                            {
                                if (p2.ProjectIdParent == p1.ProjectId)
                                {
                                    items.Add(p2);
                                }
                            }
                        }
                    }

                    items.Add(current);

                    projects = items;
                }

                return projects;
            }
        }

        public IList<Project> AllProjects
        {
            get {
                var projects = this.Session[SESSION_PROJECT_LIST] as IList<Project>;

                if (projects == null)
                {
                    projects = ProjectBll.GetProjects(this.WorkContext.CurrentUser.UserId);
                    this.Session[SESSION_PROJECT_LIST] = projects;
                }
                return projects;
            }
        }

        protected IList<Project> GetProjectList(int level)
        {
            var projects = this.ProjectList.Where(x => x.TreeLevel == level).ToList();

            if (level == 3 && (projects == null || projects.Count == 0))
                projects = this.ProjectList.Where(x => x.TreeLevel == 2).ToList();

            if (level == 3 && (projects == null || projects.Count == 0))
                projects = new List<Project>() { this.CurrentProject };

            return projects;
        }

        protected byte[] BuildExportData(IList<object> items, JArray colNames, Type targetType)
        {
            var colsDic = new Dictionary<string, int>();
            var i = 0;

            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet();
            IRow titelRow = sheet.CreateRow(0);
            ICellStyle style = book.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = book.CreateFont();
            font.FontName = "Microsoft YaHei";
            font.FontHeightInPoints = 10;
            style.SetFont(font);

            foreach (var col in colNames)
            {
                if (!colsDic.ContainsKey(col["code"].ToString()))
                {
                    titelRow.CreateCell(i).SetCellValue(col["name"].ToString());
                    titelRow.GetCell(i).CellStyle = style;
                    colsDic.Add(col["code"].ToString(), i++);
                }
            }

            var propertys = targetType.GetProperties();
            var rowIndex = 1;
            IRow dataRow = null;
            foreach (var item in items) 
            {
                dataRow = sheet.CreateRow(rowIndex);

                foreach (var property in propertys)
                {
                    if (colsDic.ContainsKey(property.Name))
                    {
                        var value = property.GetValue(item);
                        dataRow.CreateCell(colsDic[property.Name]).SetCellValue(value == null ? string.Empty : value.ToString());
                        dataRow.GetCell(colsDic[property.Name]).CellStyle = style;
                    }
                }

                rowIndex++;
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);

            return ms.ToArray();
        }
    }
}
*/