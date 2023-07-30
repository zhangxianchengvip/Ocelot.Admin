using Microsoft.AspNetCore.Components;

namespace Project1.Pages.Dashboard.Analysis;
public partial class Trend
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Flag { get; set; }
}