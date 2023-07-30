using AntDesign;
using Microsoft.AspNetCore.Components;
using Project1.Models;
using System.Collections.Generic;

namespace Project1.Pages.Account.Center;
public partial class Applications
{
    private readonly ListGridType _listGridType = new ListGridType
    {
        Gutter = 24,
        Column = 4
    };

    [Parameter] public IList<ListItemDataType> List { get; set; }
}