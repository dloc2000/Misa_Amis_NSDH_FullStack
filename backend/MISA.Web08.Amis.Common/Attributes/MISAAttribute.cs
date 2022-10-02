using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web08.Amis.Common
{
    /// <summary>
    /// Class định nghĩa 1 Attr là khóa chính
    /// </summary>
    /// CreatedBy: DXLOC (30/09/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
    }

    /// <summary>
    /// Class định nghĩa 1 Attr là trường không được bỏ trống
    /// </summary>
    /// CreatedBy: DXLOC (30/09/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmptyAttribute : Attribute
    {
        public string Msg;

        public NotEmptyAttribute(string msg)
        {
            Msg = msg;
        }
    }

    /// <summary>
    /// Class định nghĩa 1 Attr là Mã Nhân Viên
    /// </summary>
    /// Created by : DXLOC (30/09/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class HaveCodeAttribute : Attribute
    {

    }


}
