using NewOcean.Data.SqlServer.EF;
using NewOcean.Data.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.SqlServer.Repositories
{
    public class CommonRepository<T> : Repository<CommonDBContext, T>, ICommonRepository<T> where T : class
    {
        public CommonRepository(CommonDBContext context) : base(context)
        {

        }
    }
}
