using System;
using System.Text;
using System.Collections.Generic;

using Rcbi.Entity.Framework;

namespace Rcbi.Framework.UI.Menu
{
    public class AdminMenuModel : BaseMenuModel
    {
        public AdminMenuModel(IList<MenuEntity> menuList, string pageUrl) :
            base(menuList, pageUrl) 
        { 
        }

        protected override void GenerateNode(MenuEntity node, StringBuilder builder)
        {
            builder.AppendFormat("<li class=\"{0}\">", node.IsOpen ? (node.IsLeaf ? "active" : "open active") : string.Empty).AppendLine();
            if (node.IsLeaf)
            {
                builder.AppendFormat("  <a href=\"{0}\">", node.Url).AppendLine();
                builder.AppendFormat("    <i class=\"{0}\"></i>", node.Icon ?? string.Empty).AppendLine();
                builder.AppendFormat("    {0}", node.MenuName).AppendLine();
                builder.Append("  </a>").AppendLine();
            }
            else 
            {
                builder.Append("  <a href=\"javascript:void(0)\" class=\"dropdown-toggle\">").AppendLine();
                builder.AppendFormat("    <i class=\"{0}\"></i>", node.Icon ?? string.Empty).AppendLine();
                builder.AppendFormat("    <span class=\"menu-text\">{0}</span>", node.MenuName).AppendLine();
                builder.Append("    <b class=\"arrow icon-angle-down\"></b>").AppendLine();
                builder.Append("  </a>").AppendLine();
                builder.Append("  <ul class=\"submenu\">").AppendLine();
                foreach (var n in node.Childrens) 
                {
                    GenerateNode(n, builder);
                }
                builder.Append("  </ul>").AppendLine();
            }
            builder.Append("</li>").AppendLine();
        }
    }
}
