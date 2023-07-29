using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Properties.Enums;
public class Operation : SmartEnum<Operation>
{
    public static readonly Operation Read = new Operation(nameof(Read), 1, "只读");
    public static readonly Operation Write = new Operation(nameof(Write), 2, "只写");
    public static readonly Operation ReadWrite = new Operation(nameof(ReadWrite), 3, "读写");
    public Operation(string name, int value, string showName) : base(name, value)
    {
    }
}
