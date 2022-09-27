using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Web08.Amis.Common
{
    /// <summary>
    /// Thông tin chi tiết nhân viên
    /// Created by : DXLOC (18/09/2022)
    /// </summary>
    /// Ctrl + M + O : đóng comment
    /// Ctril + M + L : mở comment
    [Table("employee")]
    public class Employee
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [Key]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// [Required(ErrorMessage = "e005")
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth;

        /// <summary>
        /// Số CCCD
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp CCCD
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CCCD
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Department? DepartmentCode { get; set; }
       
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// ID chức vụ
        /// </summary>
        public Guid PositionID { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public Position? PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// Lương nhân viên
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Tên tài khoản ngân hàng
        /// </summary>
        public string? BankAccountName { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Ngày tạo nhân viên
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Người tạo nhân viên
        /// </summary>
        public string? CreateBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
