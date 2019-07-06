using System;
using Microsoft.AspNetCore.Components;

namespace Calculator.Pages
{
    public class CalculatorComponentModel : ComponentBase
    {
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
                throw new Exception("Cannot divide by zero.");
            }

            Result = Operand1 / Operand2;
        }
    }
}
