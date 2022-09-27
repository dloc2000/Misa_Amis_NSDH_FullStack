using Dapper;
using MISA.Web08.Amis.Common;
using MySqlConnector;

namespace MISA.Web08.Amis.DL
{
    public class EmployeeDL : IEmployeeDL
    {

        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên     
        /// </summary>
        /// <returns>Danh sách toàn bộ nhân viên</returns>
        /// Created by : DXLOC (27/09/2022)
        public IEnumerable<Employee> GetAllEmployees()
        {
            // Khởi tạo kết nối tới DB MySQL
            //string connectionStringLaptop = "Server=localhost;Port=3306;Database=misa.web08.nsdh.dxloc;Uid=root;Pwd=root";

            string connectionStringPC = "Server=localhost;Port=3306;Database=misa.web08.nsdh.dxloc;User Id=root;Password=root";
            var mysqlConnection = new MySqlConnection(connectionStringPC);

            // Khai báo tên stored procedure
            string storedProcedureName = "Proc_employee_All";
            //storedProcedureName , commandType: System.Data.CommandType.StoredProcedure
            // Thực hiện gọi vào DB
            var employees = mysqlConnection.Query<Employee>("SELECT * FROM Employee");

                return employees;
        }

        public int DeleteEmployee(Employee employeeId)
        {
            throw new NotImplementedException();
        }

        public int InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
