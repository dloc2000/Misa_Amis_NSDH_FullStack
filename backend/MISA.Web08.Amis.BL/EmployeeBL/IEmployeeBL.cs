using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Entities;
using MISA.Web08.Amis.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.BL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        #region EmployeeCodeMax
        /// <summary>
        /// lấy ra Nhân viên có mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Thông tin chi tiết một nhân viên</returns>
        /// Created by: DXLOC(27/09/2022)
        public IEnumerable<Employee> GetEmployeeCodeMax();
        #endregion

        #region FilterEmployee
        /// <summary>
        /// Lọc danh sách nhân viên có điều kiện tìm kiếm và phân trang
        /// </summary>
        /// <param name="pageNumber">Số bản ghi trong 1 trang</param>
        /// <param name="pageSize">Vị trí bản ghi bắt đầu lấy dữ liệu</param>
        /// <param name="keyword">Tìm kiếm theo ( Mã nhân viên , tên nhân viên,...)</param>
        /// <returns>Danh sách nhân viên</returns>
        /// Created by : DXLOC (28/09/2022)
        public FilterData FilterEmployees(int? pageNumber, int? pageSize, string? keyword);
        #endregion
    }
}
