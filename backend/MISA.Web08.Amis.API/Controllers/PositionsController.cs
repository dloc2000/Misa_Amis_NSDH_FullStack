using MISA.Web08.Amis.BL;
using MISA.Web08.Amis.Common;

namespace MISA.Web08.Amis.API.Controllers
{
    /// <summary>
    /// Chức vụ
    /// </summary>
    /// CreatedBy : DXLOC (27/09/2022)
    public class PositionsController : BasesController<Position>
    {
        private IBaseBL<Position> _baseBL;

        public PositionsController(IBaseBL<Position> baseBL) : base(baseBL)
        {   
            _baseBL = baseBL;
        }
    }
}
