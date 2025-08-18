using System;
using System.Collections;
using System.Collections.Generic;

using Rcbi.Entity.Framework;

namespace Rcbi.Framework.UI.Menu
{
    public interface IMenuModel : IEnumerable
    {
        /// <summary>
        /// the page url
        /// </summary>
        string PageUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int PageId { get; set; }

        /// <summary>
        /// covert to html
        /// </summary>
        /// <returns></returns>
        string ToHtml();

        /// <summary>
        /// convert to json
        /// </summary>
        /// <returns></returns>
        string ToJson();

        /// <summary>
        /// menu path
        /// </summary>
        IList<MenuEntity> GetMenuPath();
    }
}
