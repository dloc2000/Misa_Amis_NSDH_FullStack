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
    public class Employee : BaseEntity
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [NotEmpty("Mã nhân viên không được phép để trống")]
        [HaveCode]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [NotEmpty("Tên nhân viên không được phép để trống")]
        public string? FullName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ nhà
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

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
        //[NotEmpty("Phòng ban không được phép để trống")]
        public Guid? DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string? DepartmentCode { get; set; }
       
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// ID chức vụ
        /// </summary>
        public Guid? PositionID { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string? PositionCode { get; set; }

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
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankBranch {get; set; }

    }
}
