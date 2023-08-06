using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Admin.Users;
public class UserInput
{
    public string LoginName { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}

