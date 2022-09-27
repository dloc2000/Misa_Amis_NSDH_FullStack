using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        #region Field

        private  IEmployeeDL _employeeDL;



        #endregion

        #region Contrucstor

        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Created by: DXLOC(27/09/2022)
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeDL.GetAllEmployees();
        }
        #endregion
    }
}
