using Auto.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Settings;
[AutoOptions(Node = "Jwt")]
public class JwtOptions
{
    public string key { get; set; }
    public int Expire { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
