using Microsoft.AspNetCore.Components;

namespace Project1.Pages.Dashboard.Monitor;
public partial class Pie
{
    [Parameter]
    public bool? Animate { get; set; }

    [Parameter]
    public int? LineWidth { get; set; }
}