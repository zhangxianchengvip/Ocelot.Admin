using Microsoft.AspNetCore.Components;
using Project1.Models;
using Project1.Services;
using System.Threading.Tasks;

namespace Project1.Pages.Account.Settings;
public partial class BaseView
{
    private CurrentUser _currentUser = new CurrentUser();

    [Inject] protected IUserService UserService { get; set; }

    private void HandleFinish()
    {
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _currentUser = await UserService.GetCurrentUserAsync();
    }
}