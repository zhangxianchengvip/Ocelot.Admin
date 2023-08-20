using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Ocelots.Routes;
public class QosOptions : Entity<Guid>
{
    public int ExceptionsAllowedBeforeBreaking { get; set; }
    public int DurationOfBreak { get; set; }
    public int TimeoutValue { get; set; }
    private QosOptions() { }
}
