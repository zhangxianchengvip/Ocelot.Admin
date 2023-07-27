using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Configurations.Routes;
public class QoSOptions
{
    public int ExceptionsAllowedBeforeBreaking { get; set; }
    public int DurationOfBreak { get; set; }
    public int TimeoutValue { get; set; }
}
