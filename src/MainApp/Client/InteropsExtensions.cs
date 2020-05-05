using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MainApp.Client
{
    public static class InteropsExtensions
    {
        public static async Task FocusAsync(this ElementReference elementRef, IJSRuntime jsRuntime)
            => await jsRuntime.InvokeVoidAsync("interops.focusElement", elementRef);
    }
}
