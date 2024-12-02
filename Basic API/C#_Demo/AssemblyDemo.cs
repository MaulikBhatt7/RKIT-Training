using System;
using CalculatorLibrary;

namespace AssemblyDemo
{
    public class AssemblyExample
    {
        public static void RunDemo()
        {
            // Using Calculator class of CalculatorLibrary
            Calculator objCalculator = new Calculator();

            // Add method of Calculator class
            double ans = objCalculator.Add(5 , 10);
            Console.WriteLine("Addition = "+ans);

        }
    }
}
