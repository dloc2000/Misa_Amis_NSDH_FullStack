using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.BL;
using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Entities;
using MISA.Web08.Amis.DL;
using MySqlConnector;
using AmisErrorCode = MISA.Web08.Amis.Common.Enums.AmisErrorCode;

namespace MISA.Web08.Amis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Field
        private IEmployeeBL _employeeBL;

        private IEmployeeDL _employeeDL;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeBL employeeBL , IEmployeeDL employeeDL)
        {
            _employeeBL = employeeBL;
            _employeeDL = employeeDL;
        }

        #endregion

        #region API Get
        /// <summary>
        /// API Lấy thông tin các nhân viên 
        /// </summary>
        /// <returns>Thông tin các nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                // Thực hiện gọi vào hàm ở EmployeeBL
        
    
                    var employees = _employeeBL.GetAllEmployees();

                    return StatusCode(StatusCodes.Status200OK, employees);
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                        AmisErrorCode.Exception,
                          "It was not possible to connect to the redis server(s)",
                          "Có lỗi xảy ra! Vui lòng liên hệ với MISA",
                          "https://openapi.misa.com.vn/errorcode/e001",
                           HttpContext.TraceIdentifier
                    ));
                throw;
            }
        }
       

        /// <summary>
        /// API Lấy thông tin chi tiết một nhân viên 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        //[HttpGet("{employeeID}")]
        //public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        //{
        //    try
        //    {
        //        // Khởi tạo kết nối tới DB 
        //        string connectionString = "Server=localhost;Port=3306;Database=misa.web08.amis.api;Uid=root;Pwd=root";
        //        var mysqlConnection = new MySqlConnection(connectionString);

        //        // Chuẩn bị câu lệnh procedure
        //        string storedProcedureName = "Proc_employee_GetByID";

        //        // Chuẩn bị tham số đầu vào cho câu lệnh
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmployeeID", employeeID);
        //        // Thực hiện gọi vào DB  để chạy câu lệnh SQL với tham số đầu vào ở trên
        //        var employee = mysqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //        // Xử lý kết quả trả về từ DB
        //        if (employee != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, employee);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        //return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
        //        //    AmisErrorCode.Exception,
        //        //    "Có lỗi xảy ra",
        //        //    "http://openapi.misa.com.vn/errorcode/e001"
        //        //    ));
        //    }
        //}
        #endregion

        #region API Insert
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
                parameters.Add("v_EmployeeName", employee.EmployeeName);
                parameters.Add("v_DateOfBirth", employee?.DateOfBirth);
                parameters.Add("v_Gender", employee?.Gender);
                parameters.Add("v_PhoneNumber", employee?.PhoneNumber);
                parameters.Add("v_IdentityNumber", employee?.IdentityNumber);
                parameters.Add("v_IdentityDate", employee?.IdentityDate);
                parameters.Add("v_IdentityPlace", employee?.IdentityPlace);
                parameters.Add("v_DepartmentID", employee?.DepartmentID);
                parameters.Add("v_DepartmentName", employee?.DepartmentName);
                parameters.Add("v_PositionID", employee?.PositionID);
                parameters.Add("v_PositionName", employee?.PositionName);
                parameters.Add("v_CreateDate", DateTime.Now);
                parameters.Add("v_CreateBy", employee?.CreateBy);
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", employee?.CreateBy);
                // Thực hiện gọi vào DB  để chạy procedure
                var numberOfAffectedRows = mysqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý dữ liệu trả về
                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, employee?.EmployeeID);

                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,new ErrorResult(
                           AmisErrorCode.InsertFailed,
                          "It was not possible to connect to the redis server(s)",
                          "Có lỗi xảy ra! Vui lòng liên hệ với MISA",
                          "https://openapi.misa.com.vn/errorcode/e001",
                           HttpContext.TraceIdentifier)
                    );
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                        AmisErrorCode.Exception,
                          "It was not possible to connect to the redis server(s)",
                          "Có lỗi xảy ra! Vui lòng liên hệ với MISA",
                          "https://openapi.misa.com.vn/errorcode/e001",
                           HttpContext.TraceIdentifier
                    ));
                throw;
            }
        }
        #endregion

        #region API Update
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
        #endregion

        #region API Delete
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

        [HttpPost("batch-delete")]
        public IActionResult DeleteMultipleEmployees([FromBody] List<string> employeeIDs)
        {
            return StatusCode(StatusCodes.Status200OK);
        }
        #endregion

        #region API Filter
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
        #endregion

        #region API ID max
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
        #endregion
    }
}
