using Microsoft.AspNetCore.Components;
using Project1.Models;
using System.Collections.Generic;

namespace Project1.Pages.Account.Center;
public partial class Articles
{
    [Parameter] public IList<ListItemDataType> List { get; set; }
}