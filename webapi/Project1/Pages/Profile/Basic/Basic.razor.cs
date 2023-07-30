using Microsoft.AspNetCore.Components;
using Project1.Models;
using Project1.Services;
using System.Threading.Tasks;

namespace Project1.Pages.Profile;
public partial class Basic
{
    private BasicProfileDataType _data = new BasicProfileDataType();

    [Inject] protected IProfileService ProfileService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _data = await ProfileService.GetBasicAsync();
    }
}