using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module1.Task3
{
    class Calculator
    {

        private int firstValue = 0, secondValue = 0;
        private ISet<string> availableCommands = new HashSet<string>();
        private const string MULT = "*", DIV = "/", ADDITION = "+", DEDUCTION = "-";
        private string operation = null;

        //static void Main(string[] args)
        //{

        //    Calculator calc = new Calculator();
        //    calc.StartApplication();

        //}

        private void StartApplication()
        {
            FillSetCommands()
                 .SetValues()
                 .Calculate(operation);
        }

        private void Calculate(string operation)
        {
            switch (operation)
            {
                case ADDITION:
                    PintResult(Addition(firstValue, secondValue));
                    break;

                case DEDUCTION:
                    PintResult(Deduction(firstValue, secondValue));
                    break;

                case MULT:
                    PintResult(Multiply(firstValue, secondValue));
                    break;

                case DIV:
                    PintResult(Div(firstValue, secondValue));
                    break;
            }

        }

        private int Div(int a, int b)
        {
            if (b==0) {
            Console.WriteLine("Cannot divide by zero");
            return 0;
        }
            return a / b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Deduction(int a, int b)
        {
            return a - b;
        }

        private int Addition(int a, int b)
        {
            return a + b;
        }

        private void PintResult(int result)
        {
            Console.WriteLine("Result=" + result);
        }

        private Calculator SetValues() {
       
        Console.WriteLine("Type first value");
        firstValue = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Type second value");
        secondValue = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Type command");
        operation = Console.ReadLine();
            
        while (!availableCommands.Contains(operation)) {
            Console.WriteLine("Available commands= ");
            foreach(var command in availableCommands) {Console.WriteLine(" " + command);};
            Console.WriteLine("\n" + "Try again!");
            operation = Console.ReadLine();
        }

        
        return this;
    }

        private Calculator FillSetCommands()
        {
            availableCommands.Add(ADDITION);
            availableCommands.Add(DEDUCTION);
            availableCommands.Add(MULT);
            availableCommands.Add(DIV);
            return this;
        }
    }
}
