using System;
using Microsoft.AspNetCore.Components;

namespace Calculator.Pages
{
    public class CalculatorComponentModel : ComponentBase
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }

        public void Add()
        {
            Result = Operand1 + Operand2;
        }

        public void Subtract()
        {
            Result = Operand1 - Operand2;
        }

        public void Multiply()
        {
            Result = Operand1 * Operand2;
        }

        public void Divide()
        {
            if (Operand2 == 0)
            {
                throw new Exception("Cannot divide by zero.");
            }

            Result = Operand1 / Operand2;
        }
    }
}
