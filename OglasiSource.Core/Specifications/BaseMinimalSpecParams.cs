using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Specifications
{
    public class BaseMinimalSpecParams
    {
        private const int MaxPageSize = 25;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 25;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? CompanyId { get; set; }

        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower();

        }
    }
}
