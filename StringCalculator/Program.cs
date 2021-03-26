using CalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double result = Calculator.Calculate(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
