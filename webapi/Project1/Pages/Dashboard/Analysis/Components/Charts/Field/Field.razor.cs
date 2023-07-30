using Microsoft.AspNetCore.Components;

namespace Project1.Pages.Dashboard.Analysis;
public partial class Field
{
    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public string Value { get; set; }
}