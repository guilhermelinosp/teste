using Blazor.Server.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Server.Components.Pages;

public partial class Reset : ComponentBase
{
    [SupplyParameterFromForm]
    public ResetForm _resetForm { get; set; } = new();
    public EditContext? _editContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _editContext ??= new EditContext(_resetForm);
        await base.OnInitializedAsync();
    }

    public async Task HandleSubmitAsync()
    {
        Console.WriteLine($"Password: {_resetForm.Password}, Confirm Password: {_resetForm.ConfirmPassword}");
        Navigation.NavigateTo("/");
        await Task.Yield();
    }
}