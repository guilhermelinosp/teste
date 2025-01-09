using System.Diagnostics;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Components.Pages;

public partial class Error : ComponentBase
{
    [CascadingParameter] 
    public HttpContext? HttpContext { get; set; }

    private string? RequestId { get; set; }
    private bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    protected override void OnInitialized()
    {
        RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
    }
}