using Blazor.Server.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Server.Components.Pages;

public partial class SignIn : ComponentBase
{
    [SupplyParameterFromForm]
    public SignInForm _signInForm { get; set; } = new();
    public EditContext? _editContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _editContext ??= new EditContext(_signInForm);
        
        await base.OnInitializedAsync();
    }

    public async Task HandleSubmitAsync()
    {
        Console.WriteLine($"Email: {_signInForm.Email}, Password: {_signInForm.Password}, Remember Me: {_signInForm.RememberMe}");

        await Task.Delay(2000); 
        
        Navigation.NavigateTo("/dashboard");
            
        await Task.Yield();
    }
}