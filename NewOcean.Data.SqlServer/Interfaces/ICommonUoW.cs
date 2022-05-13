using NewOcean.Data.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.SqlServer.Interfaces
{
    public interface ICommonUoW : IUnitOfWork<CommonDBContext>
    {

    }
}
