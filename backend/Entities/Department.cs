namespace MISA.Web08.Amis.API.Entities
{
    public class Department
    {
        /// <summary>
        /// Thông tin chi tiết phòng ban
        /// Created by : DXLOC (18/09/2022)
        /// </summary>

        public Guid DepartmentID { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
