using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ocelot.Admin.Users;
public interface IUserRepository: IRepository<User, Guid>
{
    Task<User> GetById(string loginNmae);
}
