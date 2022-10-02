using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.Common.Entities
{
    /// <summary>
    /// Model phản hồi người dùng
    /// </summary>
    /// CreatedBy : DXLOC (28/09/2022)
    public class ServiceResponse
    {
        /// <summary>
        /// Thành công hoặc thất bại
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Data response khi thành công hoặc thất bại
        /// </summary>
        public object Data { get; set; }

    }
}
