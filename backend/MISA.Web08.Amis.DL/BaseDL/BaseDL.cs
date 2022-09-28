using MISA.Web08.Amis.Common.Resources;
using MISA.Web08.Amis.Common;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MISA.Web08.Amis.DL
{
    /// <summary>
    /// Lấy danh sách toàn bộ bản ghi trong 1 bảng
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// CreatedBy: DXLOC 28/09/2022
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Field
        private IBaseDL<T> _baseDL;
        #endregion

        #region Constructor

        public BaseDL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region GetAll
        public IEnumerable<T> GetAllRecords()
        {
            // Khai báo tên stored procedure
            string storedProcedureName = string.Format(MISAResources.Proc_GetAll, typeof(T).Name.ToLower());

            // Khởi tạo kết nối tới DB MySQL
            var mysqlConnection = new MySqlConnection(DataContext.MySQLConnectionString);

            // Thực hiện gọi vào DB
            var records = mysqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

            return records; ;
        }
        #endregion

        #region Delete
        public IEnumerable<T> DeleteRecord()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Insert
        public IEnumerable<T> InsertRecord()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public IEnumerable<T> UpdateRecord()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
