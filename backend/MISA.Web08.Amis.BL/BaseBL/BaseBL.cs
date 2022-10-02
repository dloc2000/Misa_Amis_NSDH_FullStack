using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Entities;
using MISA.Web08.Amis.Common.Resources;
using MISA.Web08.Amis.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {

        #region Field
        private IBaseDL<T> _baseDL;
        #endregion

        #region Constructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region GetMethods
        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// CreatedBy: DXLOC 28/09/2022
        public IEnumerable<T> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Lấy ra bản ghi theo id
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>bản ghi</returns>
        /// CreatedBy: DXLOC (28/09/2022)
        public T GetRecordByID(Guid id)
        {
           return _baseDL.GetRecordByID(id);
        }

        /// <summary>
        /// Check trùng mã Code
        /// </summary>
        /// <param name="recordCode">mã code bản ghi</param>
        /// <returns>bản ghi</returns>
        /// CreatedBy: DXLOC (29/09/2022)
        public T GetDuplicateCode(string recordCode, Guid? id)
        {
            return _baseDL.GetDuplicateCode(recordCode, id);
        } 
        #endregion

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse InsertRecord(T obj)
        {
            // Validate dữ liệu đầu vào
            var validateResult = ValidateRequestData(obj); // ko đc để trống
            var checkDuplicateCode = CheckDuplicateCodeEmployee(obj); // mã bị trùng

            // Nếu trùng mã trả về lỗi luôn
            if(checkDuplicateCode.Success == false)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = checkDuplicateCode?.Data
                };
            }

            // Tiếp theo là validate ko đc bỏ trống
            if(validateResult != null && validateResult.Success)
            {
                var idRecord = _baseDL.InsertRecord(obj);
                if(idRecord != Guid.Empty)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Data = idRecord
                    };
                } 
                else
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                       AmisErrorCode.InsertFailed,
                       MISAResources.DevMsg_InsertFailed,
                       MISAResources.UserMsg_InsertFailed,
                       MISAResources.MoreInfo_InsertFailed)
                    };
                }
            } else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = validateResult?.Data
                };
            }
        }

        /// <summary>
        /// Lấy ra mã nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: DXLoc(30/09/2022)
        public string GetRecordCode(T obj)
        {
            // Lấy ra tất cả props trong obj
            var props = typeof(T).GetProperties();
            string recordCode = "";

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(obj);
                var haveCode = (HaveCodeAttribute?)Attribute.GetCustomAttribute(prop, typeof(HaveCodeAttribute));
                if(haveCode != null)
                {
                    recordCode = propValue.ToString();
                }
            }
            return recordCode;
        }
        /// <summary>
        /// Validate Check mã nhân viên trùng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Kiểu trả về ServiceReponse</returns>
        /// CreatedBy: DXLOC(30/09/2022)
        public ServiceResponse CheckDuplicateCodeEmployee(T obj)
        {
            // Lấy ra trường EmployeeCode 
            string recordCode = GetRecordCode(obj);
            // Check xem mã bị trùng chưa
            var checkDuplicateCode = GetDuplicateCode(recordCode, null);

            if(checkDuplicateCode != null)
            {
                return new ServiceResponse { Success = false,
                    Data = new ErrorResult(
                        AmisErrorCode.DuplicateCode,
                        MISAResources.DevMsg_DuplicateCode,
                        MISAResources.UserMsg_DuplicateCode,
                        MISAResources.MoreInfo_DuplicateCode
                        ) };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = true,
                    Data = ""
                };
            }

        }

        /// <summary>
        /// Validate dữ liệu truyền lên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Kiểu trả về ServiceReponse</returns>
        /// CreatedBy: DXLOC(30/09/2022)
        public ServiceResponse ValidateRequestData(T obj)
        {
            // Lấy ra các property của T
            var props = typeof(T).GetProperties();

            List<string> validateFailed = new();

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(obj);
                var notEmpty = (NotEmptyAttribute?)Attribute.GetCustomAttribute(prop, typeof(NotEmptyAttribute));
                if (notEmpty != null && string.IsNullOrEmpty(propValue?.ToString()))
                {
                    validateFailed.Add(notEmpty.Msg);
                }
            }
            // Check xem nếu đã có lỗi rồi thì trả về lỗi luôn
            if(validateFailed.Count > 0)
            {
                return new ServiceResponse { 
                    Success = false,
                    Data = new ErrorResult(
                    AmisErrorCode.EmptyCode,
                    MISAResources.DevMsg_ValidateFailed,
                    MISAResources.UserMsg_ValidateFailed,
                    validateFailed
                    ) };
            }
            return new ServiceResponse
            {
                Success = true,
            };
        }

        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse UpdateRecord(Guid id , T obj)
        {
            // Lấy ra mã code sau khi sửa
            string codeUpdate = GetRecordCode(obj);
            // Check xem mã code đó có bị trùng ko
            var checkDuplicateCode = GetDuplicateCode(codeUpdate, id);

            if(checkDuplicateCode != null)
            {
                return new ServiceResponse {
                    Success = false,
                     Data =  new ErrorResult(
                        AmisErrorCode.UpdateFailed,
                        MISAResources.DevMsg_UpdatedFailed,
                        MISAResources.UserMsg_UpdatedFailed,
                        MISAResources.MoreInfo_UpdatedFailed
                        )
                };
            } 
                Guid reponse = _baseDL.UpdateRecord(id, obj);
                return new ServiceResponse
                {
                    Success = true,
                    Data = reponse
                };
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DXLOC 28/09/2022
        public ServiceResponse DeleteRecord(Guid id)
        {
            var idRecord =  _baseDL.DeleteRecord(id);
            if(idRecord != Guid.Empty)
            {
                return new ServiceResponse {
                    Success = true,
                    Data = idRecord
                };
            } else
            {
                return new ServiceResponse { 
                    Success=false,
                    Data = "Lỗi ko xóa được"
                };
            }
        }

      
    }
}
