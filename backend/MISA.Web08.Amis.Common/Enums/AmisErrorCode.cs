using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.Common.Enums
{
    /// <summary>
    /// Danh sách mã lỗi khi gọi API
    /// </summary>
    public enum AmisErrorCode
    {

        /// <summary>
        /// Lỗi do Exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi do trùng mã
        /// </summary>
        DuplicateCode = 2,

        /// <summary>
        /// Lỗi do mã bị để trống
        /// </summary>
        EmptyCode = 3,

        /// <summary>
        /// Gọi vào DB nếu insert thất bại
        /// </summary>
        InsertFailed = 4,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        InvalidInput = 5,

    }
}
