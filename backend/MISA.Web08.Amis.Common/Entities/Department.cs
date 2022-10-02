namespace MISA.Web08.Amis.Common
{
        /// <summary>
        /// Thông tin chi tiết phòng ban
        /// Created by : DXLOC (18/09/2022)
        /// </summary>
    public class Department : BaseEntity
    {

        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid DepartmenId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string? DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

    }
}
