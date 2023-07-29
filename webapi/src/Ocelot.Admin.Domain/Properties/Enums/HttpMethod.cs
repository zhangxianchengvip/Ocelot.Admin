using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Properties.Enums;
public class HttpMethod : SmartEnum<HttpMethod>
{
    public static readonly HttpMethod GET = new HttpMethod(nameof(GET), 1);
    public static readonly HttpMethod POST = new HttpMethod(nameof(POST), 2);
    public static readonly HttpMethod PUT = new HttpMethod(nameof(PUT), 3);
    public static readonly HttpMethod DELETE = new HttpMethod(nameof(DELETE), 4);
    public static readonly HttpMethod OPTIONS = new HttpMethod(nameof(OPTIONS), 5);
    public HttpMethod(string name, int value) : base(name, value)
    {
    }
}
