using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.DL
{
    public interface IBaseDL<T>
    {

        #region Get
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách records</returns>
        /// CreatedBy: DXLOC 28/09/2022
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
        public Guid InsertRecord(T obj);
        #endregion

        #region Delete
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public Guid DeleteRecord(Guid id);
        #endregion

        #region Update
        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public Guid UpdateRecord(Guid id , T obj);
        #endregion

    }
}
