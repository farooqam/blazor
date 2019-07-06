using Microsoft.AspNetCore.Components;
using Calculator.Shared;

namespace Calculator.Pages
{
    public class CalculatorComponentModel : ComponentBase
    {
        [Inject]
        protected ToastService ToastService { get; set; }
        protected double Operand1 { get; set; }
        protected double Operand2 { get; set; }
        protected double Result { get; set; }

        protected void Add()
        {
            Result = Operand1 + Operand2;
        }

        protected void Subtract()
        {
            Result = Operand1 - Operand2;
        }

        protected void Multiply()
        {
            Result = Operand1 * Operand2;
        }

        protected void Divide()
        {
            if (Operand2 == 0)
            {
                ToastService.ShowToast("Cannot divide by zero.");
                return;
            }

            Result = Operand1 / Operand2;
        }
    }
}
