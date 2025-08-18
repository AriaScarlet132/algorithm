using System.Text;
using System.Collections.Generic;

using Rcbi.Entity.Framework;
using System;

namespace Rcbi.Framework.UI.Menu
{
    public class LayuiMenuModel : BaseMenuModel
    {
        public LayuiMenuModel(IList<MenuEntity> menuList, string pageUrl) :
            base(menuList, pageUrl) 
        {
        }

        protected override void GenerateNode(MenuEntity node, StringBuilder builder)
        {
            if (node.Level == 1)
            {
                builder.AppendFormat("<li data-name='{0}' class='layui-nav-item'>", node.MenuCode);
                builder.AppendFormat(@"<a href='javascript:;' lay-tips='{0}' lay-direction='2'>
                                           <i class='layui-icon {1}'></i>
                                           <cite>{0}</cite>", node.MenuName, node.Icon);
                if (node.Childrens != null && node.Childrens.Count > 0)
                    builder.Append("<span class='layui-nav-more'></span>");
                builder.Append("</a>");

                if (node.Childrens != null && node.Childrens.Count > 0)
                {
                    builder.Append("<dl class='layui-nav-child'>");
                    foreach (var menu in node.Childrens)
                    {
                        GenerateNode(menu, builder);
                    }
                    builder.Append("</dl>");
                }
                builder.Append("</li>");
            }
            else {
                if (node.IsLeaf)
                {
                    builder.AppendFormat("<dd><a lay-href='{0}'>{1}</a></dd>", node.Url, node.MenuName);
                }
                else {
                    builder.AppendFormat("<dd data-name='{0}'>", node.MenuCode);
                    builder.AppendFormat("<a href='javascript:;'>{0}<span class='layui-nav-more'></span></a>", node.MenuName);
                    builder.Append("<dl class='layui-nav-child'>");
                    foreach (var menu in node.Childrens)
                    {
                        GenerateNode(menu, builder);
                    }
                    builder.Append("</dl>");
                    builder.Append("</dd>");
                }
            }
        }
    }
}
