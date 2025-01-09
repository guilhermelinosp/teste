﻿using System.ComponentModel.DataAnnotations;

namespace Blazor.Server.Components.Forms;

public record ForgotForm
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;
}