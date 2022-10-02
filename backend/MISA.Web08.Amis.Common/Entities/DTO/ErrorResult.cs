using MISA.Web08.Amis.Common;

namespace MISA.Web08.Amis.Common
{
    public class ErrorResult : Exception
    {
        /// <summary>
        /// Kết quả trả về 1 object lỗi
        /// </summary>
        /// CreatedBy: DXLOC (28/09/2022)
       public AmisErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Thông báo lỗi cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông báo lỗi cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Link viết chi tiết lỗi
        /// </summary>
        public dynamic? MoreInfo { get; set; }

        /// <summary>
        /// ID trace
        /// </summary>
        public string? TraceId { get; set; }

        public ErrorResult(AmisErrorCode errorCode, string devMsg, string userMsg, dynamic? moreInfo, string? traceId = null)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }
    }
}
