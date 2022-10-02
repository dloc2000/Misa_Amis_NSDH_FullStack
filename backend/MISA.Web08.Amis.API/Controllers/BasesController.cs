using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.BL;
using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Resources;
using Ubiety.Dns.Core.Records;

namespace MISA.Web08.Amis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {

        #region Field
        private IBaseBL<T> _baseBL;
        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion
        #region Method GetAll
        /// <summary>
        /// API lấy danh sách toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        /// Created by: DXLOC (28/09/2022)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {   // khai báo biến hứng record
                var records = _baseBL.GetAllRecords();

                // Trả về status code và record
                return StatusCode(StatusCodes.Status200OK, records);
            }
            catch (Exception)
            {
                // Trả về status code và thông báo nếu lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                    AmisErrorCode.Exception,
                    MISAResources.DevMsg_Exception,
                    MISAResources.UserMsg_Exception,
                    MISAResources.MoreInfo_Exception,
                    HttpContext.TraceIdentifier
                    ));
            }
        }

        /// <summary>
        /// API lấy thông tin chi tiết của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Thông tin của bản ghi theo ID</returns>
        /// Created by : DXLOC (29/09/2022)
        [HttpGet("{id}")]
        public IActionResult GetRecordByID([FromRoute] Guid id)
        {
            try
            {
                // khai báo biến hứng record
                var record =_baseBL.GetRecordByID(id);

                // Trả về status code và record
                return StatusCode(StatusCodes.Status200OK , record);
            }
            catch(ErrorResult err)
            {
                var reponse = new
                {
                    devMsg = err.DevMsg,
                    userMsg = err.UserMsg,
                    data = err.Data
                };
                return StatusCode(StatusCodes.Status400BadRequest, reponse);
            }
            catch (Exception)
            {
                // Trả về status code và thông báo nếu lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                    AmisErrorCode.Exception,
                    MISAResources.DevMsg_Exception,
                    MISAResources.UserMsg_Exception,
                    MISAResources.MoreInfo_Exception,
                    HttpContext.TraceIdentifier
                    ));
            }
        }

        /// <summary>
        /// Check trùng mã Code
        /// </summary>
        /// <param name = "recordCode" > mã code bản ghi</param>
        /// <returns>bản ghi</returns>
        /// CreatedBy: DXLOC (29/09/2022)
        //[HttpGet("duplicate-code")]
        //public IActionResult CheckDuplicateCode(string recordCode)
        //{
        //    try
        //    {
        //        khai báo biến
        //       var response = _baseBL.GetDuplicateCode(recordCode,);

        //        Trả về status code và check : true là ko trùng , false là trùng
        //        return StatusCode(StatusCodes.Status200OK, response);
        //    }
        //    catch (Exception)
        //    {
        //        Trả về status code và thông báo nếu lỗi
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
        //            AmisErrorCode.Exception,
        //            MISAResources.DevMsg_Exception,
        //            MISAResources.UserMsg_Exception,
        //            MISAResources.MoreInfo_Exception,
        //            HttpContext.TraceIdentifier
        //            ));
        //    }
        //}
        #endregion

        #region Method Delete
        /// <summary>
        /// API xóa một bản ghi
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Created by : DXLOC (28/09/2022)
        [HttpDelete]
        [Route("{employeeID}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeID)
        {
            try
            {
               var response =  _baseBL.DeleteRecord(employeeID);
                if(response.Success == true)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                } 
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        #region Method Insert
        /// <summary>
        /// API thêm 1 bản ghi vào bảng
        /// </summary>
        /// <returns></returns>
        /// Created by: DXLOC (28/09/2022)
        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] T obj)
        {
            try
            {
               var response =  _baseBL.InsertRecord(obj);
               if(response.Success)
                {
                    return StatusCode(StatusCodes.Status201Created, response);
                }
               else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response.Data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
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

        #region Update
        /// <summary>
        /// API sửa một bản ghi
        /// </summary>
        /// <param name="idRecord"></param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Created by : DXLOC (18/09/2022)
        [HttpPut]
        [Route("{idRecord}")]
        public IActionResult Update([FromRoute] Guid idRecord, [FromBody] T obj)
        {
            try
            {
                var response = _baseBL.UpdateRecord(idRecord, obj);
                if (response.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response.Data);
                }
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
