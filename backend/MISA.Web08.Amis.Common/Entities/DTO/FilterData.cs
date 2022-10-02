using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.Common.Entities
{
    /// <summary>
    /// Kiểu trả về khi lọc
    /// </summary>
    public class FilterData
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int? TotalRecord { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int? TotalPage { get; set; }

        /// <summary>
        /// Số bản ghi mỗi trang
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int? CurrentPage { get; set; }

        /// <summary>
        /// Danh sách lọc trả về
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}
