using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.DL
{
    public interface IBaseDL<T>
    {

        #region GetAll
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public IEnumerable<T> GetAllRecords();
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public IEnumerable<T> InsertRecord();
        #endregion

        #region Delete
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public IEnumerable<T> DeleteRecord();
        #endregion

        #region Update
        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public IEnumerable<T> UpdateRecord(); 
        #endregion

    }
}
