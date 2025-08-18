using System;

namespace Rcbi.Entity
{
    /// <summary>
    /// 基本查询实体类
    /// </summary>
    public abstract partial class BaseQueryEntity
    {
        private int _pageIndex = 1;
        private int _pageSize = 10;
        private string _sortField;
        private string _customOrderBy;
        private SortDir _sortDir;

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        public virtual int PageIndex {
            get 
            {
                return this._pageIndex;
            }
            set 
            {
                this._pageIndex = value;
            }
        }
        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public virtual int PageSize
        {
            get 
            {
                return this._pageSize;
            }
            set 
            {
                this._pageSize = value;
            }
        }
        /// <summary>
        /// Gets or sets the sort field.
        /// </summary>
        public virtual string SortField
        {
            get 
            {
                return this._sortField;
            }
            set 
            {
                this._sortField = value;
            }
        }
        /// <summary>
        /// Gets or sets the sort dir.
        /// </summary>
        public virtual SortDir SortDir
        {
            get 
            {
                return this._sortDir;
            }
            set 
            {
                this._sortDir = value;
            }
        }
        /// <summary>
        /// Gets the order by string
        /// </summary>
        public virtual string OrderBy
        {
            get {
                if (!string.IsNullOrWhiteSpace(this._customOrderBy))
                    return this._customOrderBy;
                if (string.IsNullOrWhiteSpace(this.SortField))
                    return string.Empty;
                return string.Format("{0} {1}", this.SortField, this.SortDir.ToString());
            }
            set {
                this._customOrderBy = value;
            }
        }
        /// <summary>
        /// Gets the start item index.
        /// </summary>
        public virtual int StartIndex 
        {
            get {
                var index = ((this.PageIndex - 1) * this.PageSize);

                if (index < 0) {
                    index = 0;
                }
                return index; 
            }
        }
        /// <summary>
        /// Gets  the end item index.
        /// </summary>
        public virtual int EndIndex 
        {
            get {
                return this.PageIndex * this.PageSize;
            }
        }
    }

    public enum SortDir 
    {
        /// <summary>
        /// Asc sort.
        /// </summary>
        Asc,

        /// <summary>
        /// Desc sort.
        /// </summary>
        Desc
    }

}
