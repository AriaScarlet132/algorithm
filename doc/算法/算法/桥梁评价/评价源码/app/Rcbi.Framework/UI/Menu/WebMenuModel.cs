using System;
using System.Text;
using System.Collections.Generic;

using Rcbi.Entity.Framework;

namespace Rcbi.Framework.UI.Menu
{
    public class WebMenuModel : BaseMenuModel
    {
        public WebMenuModel(IList<MenuEntity> menuList, string pageUrl) :
            base(menuList, pageUrl) 
        {
        }

        protected override void GenerateNode(MenuEntity node, StringBuilder builder)
        {
            if (!node.IsLeaf)
            {
                builder.AppendFormat("     <li class=\"inc-left-order {0}\">", node.IsOpen ? "cur" : string.Empty).AppendLine();
                builder.AppendFormat("        <div class=\"clb nac-ic\">").AppendLine();
                builder.AppendFormat("           <i class=\"{0} iconfont color666\"></i>", node.Icon).AppendLine();
                builder.AppendFormat("           <span class=\"nav-ico\">{0}</span>", node.MenuName).AppendLine();
                builder.AppendFormat("           <b></b>").AppendLine();
                builder.AppendFormat("           <label class=\"fr mr10 f14 zksq-left-menu\">{0}</label>", node.IsOpen ? "-" : "+").AppendLine();
                builder.AppendFormat("         </div>").AppendLine();
                builder.AppendFormat("         <ul class=\"sec-nav {0}\">", node.IsOpen ? string.Empty : "none").AppendLine();
                foreach (var menu in node.Childrens)
                {
                    GenerateNode(menu, builder);
                }
                builder.AppendFormat("         </ul>").AppendLine();
                builder.AppendFormat("     </li>").AppendLine();
            }
            else {
                builder.AppendFormat("           <li><a href=\"{0}\" class=\"clb {1}\">{2}</a></li>", node.Url, node.IsOpen ? "cur" : string.Empty, node.MenuName).AppendLine();
            }
        }
    }
}
