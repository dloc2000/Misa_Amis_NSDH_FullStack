using MISA.Web08.Amis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using MISA.Web08.Amis.Common.Resources;
using System.Data;

namespace MISA.Web08.Amis.DL
{
    /// <summary>
    /// Tầng Repository
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
    /// CreatedBy: DXLOC 28/09/2022
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Methods Get
        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: DXLOC (28/09/2022)   
        public IEnumerable<T> GetAllRecords()
        {
            // Khai báo tên stored procedure
            string storedProcedureName = string.Format(MISAResources.Proc_GetAll, typeof(T).Name.ToLower());

            // Khởi tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Thực hiện gọi vào DB
                var records = mysqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }

        /// <summary>
        /// Lấy ra bản ghi theo id
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>bản ghi</returns>
        /// CreatedBy: DXLOC (28/09/2022)
        public T GetRecordByID(Guid id)
        {
            // Khai báo Procedure name
            string storeProcedureName = string.Format(MISAResources.Proc_GetRecordByID, typeof(T).Name.ToLower());
            // Tạo kết quả trả về
            T record;
            // Tạo connection
            string connectionString = DataContext.MySQLConnectionString;
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                // Khởi tạo các parameters 
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("v_id", id);
                // Thực hiện câu lệnh Database
                record = sqlConnection.QueryFirstOrDefault<T>(
                    storeProcedureName,
                    paramaters ,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            // Kết quả trả về
            return record;
        }

        /// <summary>
        /// Check trùng mã Code
        /// </summary>
        /// <param name="recordCode">mã code bản ghi</param>
        /// <returns>bản ghi</returns>
        /// CreatedBy: DXLOC (29/09/2022)
        public T GetDuplicateCode(string recordCode, Guid? id)
        {
            // Khai báo Procedure name
            string storeProcedureName = string.Format(MISAResources.ProGetDuplicateCode, typeof(Employee).Name.ToLower());

            // Tạo kết quả trả về
            T obj;
            // Tạo connection
            string connectionString = DataContext.MySQLConnectionString;
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                // Khởi tạo các parameters 
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add($"v_{typeof(T).Name}Code", recordCode);
                paramaters.Add($"v_{typeof(T).Name}Id", id);
                // Thực hiện câu lệnh Database
                obj = sqlConnection.QueryFirstOrDefault<T>(
                    storeProcedureName,
                    paramaters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
          
            // Kết quả trả về
            return obj;
        }
        #endregion

        #region Methods Delete
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public Guid DeleteRecord(Guid id)
        {
            // Khai báo tên stored procedure
            string storedProcedureName = string.Format(MISAResources.Proc_DeleteOne);
            // Khởi tạo kết nối tới DB MySQL
            int numberOfAffectedRows;
            using (var mysqlConnection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Chuẩn bị tham số đầu vào cho procedure
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("v_employeeId", id);

                // Thực hiện gọi vào DB
                 numberOfAffectedRows = mysqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
                if (numberOfAffectedRows > 0)
                {
                    return id;
                }
                else
                {
                    return Guid.Empty;
                }
        }
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public Guid InsertRecord(T obj)
        {
            // Khai báo tên storeed procedure
            string storedProcedureName = string.Format(MISAResources.Proc_InsertOne, typeof(T).Name.ToLower());

            // Chuẩn bị tham số đầu vào cho procedure
            var parameters = new DynamicParameters();
            // Tạo Guid mới
            Guid newRecordID = Guid.NewGuid();
            // Lấy ra mảng prop của T
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // Lấy ra tên của property
                string propertyName = property.Name;
                // Khai báo giá trị property
                object propertyValue;
                // Lấy ra khóa chính
                var primaryKeyAttribute = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                // Check xem có khóa chính hay ko
                if (primaryKeyAttribute != null)
                {
                    propertyValue = newRecordID;
                }
                else
                {
                    propertyValue = property.GetValue(obj, null);
                }
                parameters.Add($"v_{propertyName}", propertyValue);
            }
            // Khởi tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Thực hiện gọi vào DB
                var numberOfAffectedRows = mysqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (numberOfAffectedRows > 0)
                {
                    return newRecordID;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public Guid UpdateRecord(Guid id , T obj)
        {
            // Khai báo tên storeed procedure
            string storedProcedureName = string.Format(MISAResources.Proc_UpdateOne, typeof(T).Name);
            // Truyền tham số vào procedure
            DynamicParameters parameters = new DynamicParameters();

            // Lấy ra các props
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                // Lấy ra tên các prop
                string propName = prop.Name;
                object propValue;
                var primaryKeyAttribute = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(prop, typeof(PrimaryKeyAttribute));

                if (primaryKeyAttribute != null)
                {
                    propValue = id;
                }
                else
                {
                    propValue = prop.GetValue(obj, null);
                }
                parameters.Add($"v_{propName}", propValue);

            }
            // Số bản ghi bị ảnh hưởng
            int nunmberOfAffectedRows = 0;

            // Tạo connection
            using (var sqlConnection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Thực hiện chèn dữ liệu vào trong database
                nunmberOfAffectedRows = sqlConnection.Execute(
                    storedProcedureName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            };

            // Trả về kết quả
            if (nunmberOfAffectedRows > 0)
            {
                return id;
            }
            else
            {
                return Guid.Empty;
            }
        }
        #endregion
    }
}
