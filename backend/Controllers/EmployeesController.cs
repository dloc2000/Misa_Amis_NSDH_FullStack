using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.API.Entities;
using System.Reflection;

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
            return StatusCode(StatusCodes.Status200OK, new List<Employee>
            {
                new Employee
                {
                    EmployeeID = Guid.NewGuid(),
                    EmployeeCode = "NV0001",
                    EmployeeName = "Dương Xuân Lộc",
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
                    ModifiedBy  = "Nguyễn Văn Mạnh"
                },
               new Employee {
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
                    ModifiedBy  = "Nguyễn Văn Mạnh"
                }
            });

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
            return StatusCode(StatusCodes.Status201Created, employee.EmployeeID);
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
        /// API xóa một nhân viên 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpPost]
        [Route("{employeeID}")]
        public IActionResult UpdateEmployee([FromBody] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status200OK);
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
