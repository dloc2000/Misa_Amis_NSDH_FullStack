using MISA.Web08.Amis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.DL
{
    public interface IEmployeeDL
    {
        #region GetAll
        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Created by: DXLOC(27/09/2022)
        public IEnumerable<Employee> GetAllEmployees();
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới 1 nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần thêm mới</param>
        /// <returns>Return 1 nếu thêm mới thành công . Return 0 nếu thất bại</returns>
        /// Created by: DXLOC(27/09/2022)
        public int InsertEmployee(Employee employee);
        #endregion

        #region Update
        /// <summary>
        /// Sửa 1 nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần sửa</param>
        /// <returns></returns>
        /// Created by: DXLOC(27/09/2022)
        public List<Employee> UpdateEmployee(Employee employee);
        #endregion

        #region Delete
        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="employeeId">Xóa theo ID nhân viên</param>
        /// <returns>1: Nếu xóa thành công, 0: Nếu xóa thất bại</returns>
        /// Created by: DXLOC(27/09/2022)
        public int DeleteEmployee(Employee employeeId); 
        #endregion

        public Employee GetEmployeeById(int employeeId);
    }
}
