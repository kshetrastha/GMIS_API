namespace gmis.Application.Common.Helper
{
    public class PaginationSetting
    {
        int _pageSize = Int32.MaxValue, _pageNum = 1;
        int _totalRows;
        string _orderBy;
        bool _orderByAscending = false;

        public PaginationSetting()
        {
        }

        public int TotalPage
        {
            get
            {
                if (_totalRows == 0)
                    return 1;

                return _totalRows % _pageSize == 0 ? (_totalRows / _pageSize) : (_totalRows / _pageSize + 1);
            }
        }

        public int TotalRows
        {
            get { return _totalRows; }
            set { _totalRows = value; }
        }

        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public string? OrderBy
        {
            get { return _orderBy; }
            set
            {
                if (StringHelper.ContainsSQLDangerousString(value))
                    throw new ArgumentException("The specified order by property contains potentially dangerous characters.");

                _orderBy = value;
            }
        }

        public bool OrderByAscending
        {
            get { return _orderByAscending; }
            set { _orderByAscending = value; }
        }

    }
}
