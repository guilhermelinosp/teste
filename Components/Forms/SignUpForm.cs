using System.ComponentModel.DataAnnotations;

namespace Blazor.Server.Components.Forms;

public record SignUpForm
{
    [Required(ErrorMessage = "Full name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Please confirm your password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = "You must agree to the terms.")]
    public bool AgreeToTerms { get; set; }
}