namespace MISA.Web08.Amis.API.Entities
{
    public class Employee
    {
        /// <summary>
        /// Thông tin chi tiết nhân viên
        /// Created by : DXLOC (18/09/2022)
        /// </summary>
        /// Ctrl + M + O : đóng comment
        /// Ctril + M + L : mở comment

        public Guid EmployeeID { get; set; }

        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth;

        public string IdentityNumber { get; set; }
        public DateTime IdentityDate { get; set; }
        public string IdentityPlace { get; set; }

        public Guid DepartmentID { get; set; }
        public Department DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public Guid PositionID { get; set; }
        public Position PositionCode { get; set; }
        public string PositionName { get; set; }

        public int Salary { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
