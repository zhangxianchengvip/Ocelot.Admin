using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Ocelots.Routes;
public class HttpHandlerOptions : Entity<Guid>
{
    public bool UseTracing { get; set; }
}
