using System.Text;
using System.Collections.Generic;

using Rcbi.Entity.Framework;

namespace Rcbi.Framework.UI.Menu
{
    public class JsonMenuModel : BaseMenuModel
    {
        public JsonMenuModel(IList<MenuEntity> menuList, string pageUrl) :
            base(menuList, pageUrl) 
        {
        }

        protected override void GenerateNode(MenuEntity node, StringBuilder builder)
        {
            builder.Append("{").AppendFormat("\"name\":\"{0}\",", node.MenuName);
            if (!node.IsLeaf)
            {
                builder.AppendFormat("\"id\":{0},\"open\":true,", node.MenuId);
                builder.Append("\"children\":[");
                if (node.Childrens != null)
                {
                    for (var i = 0; i < node.Childrens.Count; i++)
                    {
                        GenerateNode(node.Childrens[i], builder);
                        if (i < node.Childrens.Count - 1)
                        {
                            builder.Append(",");
                        }
                    }
                }
                builder.Append("]");
            }
            else
            {
                builder.AppendFormat("\"id\":\"{0}\",\"open\":true",
                    node.MenuId);
            }
            builder.Append("}");
        }
    }
}
