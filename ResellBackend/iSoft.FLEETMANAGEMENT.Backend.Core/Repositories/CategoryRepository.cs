using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Repositories
{
    public class CategoryRepository :BaseRepository<Category>
    {
        public ResellDbContext _resellDbContext { get; set; }
        public CategoryRepository(ResellDbContext resellDbContext) : base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
        }
    }
}
