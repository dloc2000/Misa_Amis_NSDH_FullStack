using Dapper;
using MISA.Web08.Amis.Common;
using MISA.Web08.Amis.Common.Resources;
using MySqlConnector;

namespace MISA.Web08.Amis.DL
{
    public class EmployeeDL : BaseDL<Employee> 
    {

        #region Field
        private IBaseDL<Employee> _baseDL;   
        #endregion

        #region Constructor
        public EmployeeDL(IBaseDL<Employee> baseDL) : base(baseDL)
        {
            _baseDL = baseDL;
        } 
        #endregion

    }
}
