using NewOcean.Data.SqlServer.EF;
using NewOcean.Data.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.SqlServer.UnitOfWork
{
    public class CommonUoW : UnitOfWork<CommonDBContext>, ICommonUoW
    {
        public CommonUoW(CommonDBContext context) : base(context)
        {
        }

    }
}
