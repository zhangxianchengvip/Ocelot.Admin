using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Admin.Auths;
public class AuthViewModel
{
    public string Token { get; set; }
    public long Expire { get; set; }
}
