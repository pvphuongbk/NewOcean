﻿using NewOcean.Data.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.SqlServer.EF
{
    public abstract class PDataContext : DbContext, IDBContext
    {
        protected PDataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
