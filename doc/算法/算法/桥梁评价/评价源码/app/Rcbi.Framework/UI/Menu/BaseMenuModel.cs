using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Rcbi.Entity.Framework;
using Rcbi.Core.Extensions;

namespace Rcbi.Framework.UI.Menu
{
    public abstract class BaseMenuModel : IMenuModel
    {
        private IList<MenuEntity> _menuList;
        private string _pageUrl;
        private int _pageId;
        private IList<MenuEntity> _roots;
        private Dictionary<int, MenuEntity> dic = new Dictionary<int,MenuEntity>();
        private const int UnKnowMenuId = 0;

        public BaseMenuModel(IList<MenuEntity> menuList, string pageUrl) 
        {
            if (menuList == null)
                throw new ArgumentNullException("menuList");
            if (pageUrl.IsNullOrEmpty())
                throw new ArgumentNullException("pageUrl");

            this._menuList = menuList;
            this._pageUrl = pageUrl;
            foreach (var item in this._menuList) 
            {
                if (item.Childrens != null)
                    item.Childrens.Clear();
                item.IsOpen = false;
                item.Level = 1;
                this.dic.Add(item.MenuId, item);
            }

            this.GenerateTreeStruct();
        }

        public string PageUrl
        {
            get { return this._pageUrl; }
            set { this._pageUrl = value; }
        }

        public int PageId 
        {
            get { return this._pageId; }
            set { this._pageId = value; }
        }

        public IList<MenuEntity> Roots
        {
            get { return this._roots; }
            private set { }
        }

        protected abstract void GenerateNode(MenuEntity node, StringBuilder builder);

        public string ToHtml()
        {
            if (this._roots.Count == 0)
                return string.Empty;

            StringBuilder builder = new StringBuilder();

            Array.ForEach<MenuEntity>(
                this._roots.ToArray(), (root) => GenerateNode(root, builder));

            return builder.ToString();
        }

        public string ToJson()
        {
            return this.ToJson(this._roots);
        }

        public string ToJson(IList<MenuEntity> roots)
        {
            if (roots == null || roots.Count == 0)
                return "[]";

            StringBuilder builder = new StringBuilder();

            builder.Append("[");

            for (var i = 0; i < roots.Count; i++)
            {
                GenerateNode(roots[i], builder);

                if (i < roots.Count - 1)
                {
                    builder.Append(",");
                }
            }

            builder.Append("]");

            return builder.ToString();
        }

        public virtual IList<MenuEntity> GetMenuPath() 
        {
            var list = new List<MenuEntity>();

            var currentMenu = this._menuList.FirstOrDefault((item) => {
                return string.Compare(item.Url, this._pageUrl) == 0;
            });

            if (currentMenu == null)
                return list;

            while (true) 
            {
                list.Add(currentMenu);

                if (!currentMenu.ParentId.HasValue ||
                    currentMenu.ParentId.Value == 0)
                    break;

                currentMenu = this.dic[currentMenu.ParentId.Value];
            }

            list.Reverse();

            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return (this._menuList ?? new List<MenuEntity>()).GetEnumerator();
        }

        private void GenerateTreeStruct()
        {
            this._roots = new List<MenuEntity>();
            MenuEntity node = null;
            int currentMenuId = UnKnowMenuId;

            foreach (var menu in this._menuList)
            {
                if (menu.HasAuth)
                {
                    node = menu;
                    while (node.ParentId.HasValue &&
                        this.dic.ContainsKey(node.ParentId.Value))
                    {
                        node = this.dic[node.ParentId.Value];
                        node.HasAuth = true;
                    }
                }
            }

            foreach (var menu in this._menuList)
            {
                if (!menu.HasAuth)
                    continue;

                if (!menu.ParentId.HasValue ||
                    menu.ParentId.Value == 0)
                {
                    menu.Level = 1;
                    this._roots.Add(menu);
                }
                else
                {
                    if (this.dic.ContainsKey(menu.ParentId.Value))
                    {
                        node = this.dic[menu.ParentId.Value];
                        if (node.Childrens == null)
                            node.Childrens = new List<MenuEntity>();
                        node.Childrens.Add(menu);
                        menu.Level = node.Level + 1;
                        if (string.Compare(menu.Url, this.PageUrl, true) == 0)
                        {
                            currentMenuId = menu.MenuId;
                        }
                    }
                }
            }

            if (currentMenuId != UnKnowMenuId)
            {
                node = this.dic[currentMenuId];
                while (true)
                {
                    node.IsOpen = true;
                    if (!node.ParentId.HasValue ||
                       node.ParentId.Value == 0)
                        break;

                    node = this.dic[node.ParentId.Value];
                }
            }

            this._pageId = currentMenuId;
        }
    }
}
