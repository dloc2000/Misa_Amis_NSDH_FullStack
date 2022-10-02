using Microsoft.AspNetCore.Mvc;
using MISA.Web08.Amis.BL;
using MISA.Web08.Amis.Common;

namespace MISA.Web08.Amis.API.Controllers
{
    /// <summary>
    /// Phòng ban
    /// </summary>
    /// CreatedBy : DXLOC (27/09/2022)
    public class DepartmentsController : BasesController<Department>
    {
        private IBaseBL<Department> _baseBL ;

        public DepartmentsController(IBaseBL<Department> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }
    }
}
