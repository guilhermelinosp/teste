using System.ComponentModel.DataAnnotations;

namespace Blazor.Server.Components.Forms;

public record ResetForm
{
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Please confirm your password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }

}