using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork
{
    public class EfUnitOfWork
    {
        private ResellDbContext _context;

        

        public EfUnitOfWork()
        {
           
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
