using Dapper;
using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Entities;
using MISA.Web08.Amis.Common.Resources;
using MySqlConnector;

namespace MISA.Web08.Amis.DL
{
    public class EmployeeDL : BaseDL<Employee> , IEmployeeDL
    {

        #region EmployeeCodeMax
        /// <summary>
        /// lấy ra nhân viên có mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        public IEnumerable<Employee> GetEmployeeCodeMax()
        {

            // Khai báo Procedure name
            string storeProcedureName = string.Format(MISAResources.ProcGetMaxEmployeeCode);
            // Tạo kết quả trả về
            // Tạo connection
            string connectionString = DataContext.MySQLConnectionString;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {

                // Thực hiện câu lệnh Databases
                var employee =  mysqlConnection.Query<Employee>(storeProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                // Kết quả trả về
                return employee;
            }
        }
        #endregion

        #region EmployeeFilter
        /// <summary>
        /// Lọc danh sách nhân viên có điều kiện tìm kiếm và phân trang
        /// </summary>
        /// <param name="pageNumber">Số bản ghi trong 1 trang</param>
        /// <param name="pageSize">Vị trí bản ghi bắt đầu lấy dữ liệu</param>
        /// <param name="keyword">Tìm kiếm theo ( Mã nhân viên , tên nhân viên,...)</param>
        /// <returns>Danh sách nhân viên</returns>
        /// Created by : DXLOC (28/09/2022)
        public FilterData FilterEmployees(int? pageNumber, int? pageSize, string? keyword)
        {
            // Tạo connection
            string connectionString = DataContext.MySQLConnectionString;
            var sqlConnection = new MySqlConnection(connectionString);

            // Chuẩn bị câu lệnh MySQL
            string storeProcedureName = MISAResources.ProcGetEmployeeFilter;

            // Gán parameter
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("v_pagenumber", pageNumber);
            parameters.Add("v_pagesize", pageSize);
            parameters.Add("v_search", keyword);

            // Thực hiện gọi vào trong Database
            var employeesFilter = sqlConnection.QueryMultiple(
                    storeProcedureName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            // Chuyển về dạng List 
            var employees = employeesFilter.Read<Employee>().ToList();
            // Đọc bản ghi có dạng int (TotalRecord)
            var totalRecord = (int)employeesFilter.ReadSingle().TotalCount;

            // Tổng số trang
            int? totalPage = totalRecord / pageSize;
            // Phần dư
            int? phanDu = totalRecord % pageSize;
            if(totalPage == 0)
            {
                totalPage = 1;
            } else if(totalPage != 0 && phanDu != 0)
            {
                totalPage++;
            }
            // Trả về status code kèm theo object kết quả
            return new FilterData()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = totalPage,
                Data = employees,
                TotalRecord = totalRecord,
            };

        } 
        #endregion

    }
}
