using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.API.Entities;
using MySqlConnector;

namespace MISA.Web08.Amis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        /// <summary>
        /// API Lấy thông tin chi tiết một nhân viên 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpGet]
        [Route("{employeeID}")]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status200OK, new Employee
            {
                EmployeeID = Guid.NewGuid(),
                EmployeeCode = "NV0002",
                EmployeeName = "Dương",
                DateOfBirth = DateTime.Now,
                Email = "xuanloc176@gmail.com",
                PhoneNumber = "0921849978",
                Gender = 0,
                IdentityNumber = "001200023232",
                IdentityPlace = "CA Hà Nội",
                IdentityDate = DateTime.Now,
                PositionID = Guid.NewGuid(),
                PositionName = "Lập trình viên",
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Phòng dự án",
                Salary = 10000,
                CreateDate = DateTime.Now,
                CreateBy = "Nguyễn Văn Mạnh",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "Nguyễn Văn Mạnh"
            });
        }
        /// <summary>
        /// API Lấy thông tin các nhân viên 
        /// </summary>
        /// <returns>Thông tin các nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpGet]
        [Route("")]
        public IActionResult GetAllEmployees()
        {


            try
            {
                // Khởi tạo kết nối đến DB
                string connectionString = "Server=localhost;Port=3306;Database=misa.web08.amis.api;Uid=root;Pwd=root";
                var mysqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh SQL
                string getAllEmployeeCommand = "SELECT * FROM employee";
                string storedProcedureName = "Proc_employee_GetAll";
                // Chuẩn bị tham số đầu vào cho câu lệnh

                // Thực hiện gọi vào DB  để chạy câu lệnh SQL với tham số đầu vào ở trên
                var employees = mysqlConnection.Query(getAllEmployeeCommand);

                // Xử lý kết quả trả về từ DB
                // Trả về dữ liệu cho client nếu thành công
                // Trả về lỗi nếu thất bại
                // Try catch để bắt exception

                return StatusCode(StatusCodes.Status200OK, employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                    CukCukErrorCode.Exception,
                    "Có lỗi xảy ra",
                    "http://openapi.misa.com.vn/errorcode/e001"
                    )) ;
            }
        }

        /// <summary>
        /// API thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                // Khởi tạo kết nối đến DB
                string connectionString = "Server=localhost;Port=3306;Database=misa.web08.amis.api;Uid=root;Pwd=root";
                var mysqlConnection = new MySqlConnection(connectionString);
                // Khai báo tên procedure Insert
                var storedProcedureName = "Proc_employee_InsertOne";

                // Chuẩn bị tham số đầu vào cho procedure

                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", Guid.NewGuid());
                parameters.Add("v_EmployeeCode", employee.EmployeeCode);
                parameters.Add("v_EmployeeName", employee.EmployeeCode);
                parameters.Add("v_DateOfBirth", employee.DateOfBirth);
                parameters.Add("v_Gender", employee.Gender);
                parameters.Add("v_PhoneNumber", employee.PhoneNumber);
                parameters.Add("v_EmployeeID", employee.IdentityNumber);
                parameters.Add("v_EmployeeID", employee.IdentityDate);
                parameters.Add("v_EmployeeID", employee.IdentityPlace);
                parameters.Add("v_EmployeeID", employee.DepartmentID);
                parameters.Add("v_EmployeeID", employee.DepartmentName);
                parameters.Add("v_EmployeeID", employee.PositionID);
                parameters.Add("v_EmployeeID", employee.PositionName);
                parameters.Add("v_CreateDate", DateTime.Now);
                parameters.Add("v_CreateBy", employee.CreateBy);
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", employee.CreateBy);
                // Thực hiện gọi vào DB  để chạy procedure
                var numberOfAffectedRows = mysqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý dữ liệu trả về
                if(numberOfAffectedRows > 0)
                {
                return StatusCode(StatusCodes.Status201Created, employee.EmployeeID);

                }
                 else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    CukCukErrorCode.Exception,
                    "Có lỗi xảy ra",
                    "http://openapi.misa.com.vn/errorcode/e001"
                    ));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                    CukCukErrorCode.Exception,
                    "Có lỗi xảy ra",
                    "http://openapi.misa.com.vn/errorcode/e001"
                    ));
                throw;
            }
        }

        /// <summary>
        /// API xóa một nhân viên 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpDelete]
        [Route("{employeeID}")]
        public IActionResult DeleteEmployee([FromBody] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        /// API sửa một nhân viên 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpPost]
        [Route("{employeeID}")]
        public IActionResult UpdateEmployee([FromBody] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status200OK, employeeID);
        }

        /// <summary>
        /// API Lọc danh sách nhân viên có điều kiện tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Tìm kiếm theo ( Mã nhân viên , tên nhân viên,...)</param>
        /// <param name="departmentID">ID vị trí</param>
        /// <param name="posititonID">ID phòng ban</param>
        /// <param name="limit">Số bản ghi trong 1 trang</param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy dữ liệu</param>
        /// <returns>Danh sách nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpGet]
        [Route("filter")]
        public IActionResult FilterEmployees(
            [FromQuery] string keyword,
            [FromQuery] Guid departmentID,
            [FromQuery] Guid posititonID,
            [FromQuery] int limit,
            [FromQuery] int offset
            )
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        /// API lấy ra Nhân viên có ID lớn nhất
        /// </summary>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        [HttpGet]
        [Route("{employeeID}")]
        public IActionResult GetEmployeeOfIDMax(
            [FromQuery] DateTime modifiedDate
            )
        {
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
