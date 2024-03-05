using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using ResellBackendCore.Database.Dtos.UserDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public ResellDbContext _resellDbContext { get; set; }
        public UserRepository(ResellDbContext resellDbContext):base(resellDbContext)
        {
            _resellDbContext = resellDbContext;
        }


        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _resellDbContext.Users
                .SingleOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);
        }
    }
}
