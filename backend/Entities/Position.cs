namespace MISA.Web08.Amis.API.Entities
{
    public class Position
    {
        /// <summary>
        /// Thông tin chi tiết chức vụ
        /// Created by : DXLOC (18/09/2022)
        /// </summary>

        public Guid PositionID { get; set; }

        public string PositionCode { get; set; }

        public string PositionName { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
