using Blazor.Server.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Server.Components.Pages;

public partial class Forgot : ComponentBase
{
    [SupplyParameterFromForm]
    public ForgotForm _forgotForm { get; set; } = new();
    public EditContext? _editContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _editContext ??= new EditContext(_forgotForm);
        await base.OnInitializedAsync();
    }

    public async Task HandleSubmitAsync()
    {
        Console.WriteLine($"Email: {_forgotForm.Email}");
        Navigation.NavigateTo("/");
        await Task.Yield();
    }
}