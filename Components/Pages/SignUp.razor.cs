using Blazor.Server.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Server.Components.Pages;

public partial class SignUp : ComponentBase
{
    [SupplyParameterFromForm] 
    private SignUpForm _signUpForm { get; set; } = new();
    private EditContext? _editContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _editContext = new EditContext(_signUpForm);
        await base.OnInitializedAsync();
    }
    
    public async Task HandleSubmitAsync()
    {
        if (_signUpForm.Password != _signUpForm.ConfirmPassword)
        {
            Console.WriteLine("Passwords do not match.");
            return;
        }
        
        Console.WriteLine($"Name: {_signUpForm.Name}, Email: {_signUpForm.Email}, Password: {_signUpForm.Password}, Agree to Terms: {_signUpForm.AgreeToTerms}");
        
        await Task.Delay(2000); 
        
        Navigation.NavigateTo("/");
        
        await Task.Yield();
    }
}