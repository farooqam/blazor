using Microsoft.JSInterop;

namespace Calculator.Shared
{
    public class ToastService
    {
        private readonly IJSRuntime _jSRuntime;

        public ToastService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public void ShowToast(string message)
        {
            _jSRuntime.InvokeAsync<bool>("showToast", message);
        }
    }
}
