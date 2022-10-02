using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.BL
{
    public interface IBaseBL<T>
    {

        #region Get

        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Created by: DXLOC(27/09/2022)
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy ra bản ghi theo id
        /// </summary>
        /// <returns>Bản ghi theo id</returns>
        /// CreatedBy: DXLOC 28/09/2022
        public T GetRecordByID(Guid id);

        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <returns>Bản ghi có mã nhân viên trùng</returns>
        /// CreatedBy: DXLOC 28/09/2022
        public T GetDuplicateCode(string recordCode, Guid? id);
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse InsertRecord(T obj);
        #endregion

        #region Update
        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse UpdateRecord(Guid id , T obj);
        #endregion

        #region Delete
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse DeleteRecord(Guid id);
        #endregion
    }
}
