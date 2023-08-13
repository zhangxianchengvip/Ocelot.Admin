using Microsoft.EntityFrameworkCore;
using Ocelot.Admin.EntityFrameworkCore;
using Ocelot.Admin.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ocelot.Admin.Repositorys;
public class UserRepository : EfCoreRepository<AdminDbContext, User, Guid>, IUserRepository
{
    public UserRepository(IDbContextProvider<AdminDbContext> dbContextProvider)
    : base(dbContextProvider)
    {
    }
    public async Task<User> GetById(string loginNmae)
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Users.Include(s => s.UserRoles).FirstOrDefault(u => u.LoginName == loginNmae);
    }
}
