using MISA.Web08.Amis.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.Common
{
    /// <summary>
    /// Thực thể chung chứa các properties mà các bảng khác đều phải có trong database
    /// </summary>
    /// Created by : DXLOC (28/09/2022)
    public class BaseEntity
    {
        #region Properties

        /// <summary>
        /// Ngày tạo 
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người tạo 
        /// </summary>
        public string CreatedBy { get; set; } = MISAResources.Default_CreatedBy_User;

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; } = MISAResources.Default_ModifiedBy_User;

        #endregion
    }
}
