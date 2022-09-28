using MISA.Web08.Amis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.BL
{
    public interface IBaseBL<T>
    {

        #region Methods

        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Created by: DXLOC(27/09/2022)
        public IEnumerable<T> GetAllRecords();
        #endregion
    }
}
