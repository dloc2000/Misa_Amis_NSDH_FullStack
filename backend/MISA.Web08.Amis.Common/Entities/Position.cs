namespace MISA.Web08.Amis.Common
{
        /// <summary>
        /// Thông tin chi tiết chức vụ
        /// Created by : DXLOC (18/09/2022)
        /// </summary>
    public class Position : BaseEntity
    {

        /// <summary>
        /// ID chức vụ
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string? PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string? PositionName { get; set; }

    }
}
