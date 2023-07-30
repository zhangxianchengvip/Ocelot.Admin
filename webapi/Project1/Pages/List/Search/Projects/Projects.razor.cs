using AntDesign;
using Microsoft.AspNetCore.Components;
using Project1.Models;
using Project1.Pages.Form;
using Project1.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project1.Pages.List;
public partial class Projects
{
    private readonly ListGridType _listGridType = new ListGridType
    {
        Gutter = 16,
        Xs = 1,
        Sm = 2,
        Md = 3,
        Lg = 3,
        Xl = 4,
        Xxl = 4,
    };

    private readonly FormItemLayout _formItemLayout = new FormItemLayout
    {
        WrapperCol = new ColLayoutParam
        {
            Xs = new EmbeddedProperty { Span = 24 },
            Sm = new EmbeddedProperty { Span = 16 },
        }
    };

    private readonly ListFormModel _model = new ListFormModel();

    private IList<ListItemDataType> _fakeList = new List<ListItemDataType>();

    [Inject] public IProjectService ProjectService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _fakeList = await ProjectService.GetFakeListAsync(8);
    }
}