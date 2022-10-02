using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.BL;
using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Resources;

namespace MISA.Web08.Amis.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BasesController<Employee>
    {
        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Constructor
        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL= employeeBL;    
        }

        #endregion


        #region API ID max
        /// <summary>
        /// API lấy ra Nhân viên có ID lớn nhất
        /// </summary>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        [HttpGet("max-code")]
        public IActionResult GetEmployeeOfIDMax()
        {
            try
            {
                var employee = _employeeBL.GetEmployeeCodeMax();
                return StatusCode(StatusCodes.Status200OK, employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                                AmisErrorCode.Exception,
                                MISAResources.DevMsg_Exception,
                                MISAResources.UserMsg_Exception,
                                MISAResources.MoreInfo_Exception,
                                HttpContext.TraceIdentifier
                                   ));
            }
        }
        #endregion

        #region API Filter
        /// <summary>
        /// API Lọc danh sách nhân viên có điều kiện tìm kiếm và phân trang
        /// </summary>
        /// <param name="limit">Số bản ghi trong 1 trang</param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy dữ liệu</param>
        /// <param name="keyword">Tìm kiếm theo ( Mã nhân viên , tên nhân viên,...)</param>
        /// <returns>Danh sách nhân viên</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpGet]
        [Route("filter")]
        public IActionResult FilterEmployees(
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize,
            [FromQuery] string? keyword
            )
        {
            try
            {
                // Lấy ra dữ liệu lọc trả về
                var dataPaging = _employeeBL.FilterEmployees(pageNumber, pageSize, keyword);
                // Kết quả trả về
                return StatusCode(StatusCodes.Status200OK, dataPaging);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                    AmisErrorCode.Exception,
                    MISAResources.DevMsg_Exception,
                    MISAResources.UserMsg_Exception,
                    MISAResources.MoreInfo_Exception,
                    HttpContext.TraceIdentifier
                    ));
            }
        }
        #endregion
    }
}
