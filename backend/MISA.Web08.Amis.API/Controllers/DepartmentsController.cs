using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.Common;

namespace MISA.Web08.Amis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllDepartment()
        {
            return StatusCode(StatusCodes.Status200OK, new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Phòng Bảo Vệ",
                DepartmentCode = "D001"
            });
        }
    }
}
