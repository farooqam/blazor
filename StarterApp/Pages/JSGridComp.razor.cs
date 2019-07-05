using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace JsInteropDemo.Pages
{
    public class JsGridComponent : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime {get; set;}
        public void ShowGrid()
        {
            JSRuntime.InvokeAsync<bool>("showJsGrid");
        }
    }
}