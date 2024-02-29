using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Config;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context
{
    public class DbContextMigrationsFactory : IDesignTimeDbContextFactory<ResellDbContext>
    {
        public ResellDbContext CreateDbContext(string[] args)
        {
            AppConfig.MigrationsInit();
            return new ResellDbContext();
        }
    }
}
