// Activity 2: Basic Arithmetic and Control Structures

using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // BREAKPOINT: Verify that the program prompts for the first number.
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            // BREAKPOINT: Verify that the program prompts for the second number.
            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double sum = num1 + num2;
            double diff = num1 - num2;
            double prod = num1 * num2;
            // BREAKPOINT: Check division logic when divisor is zero.
            double quot = (num2 != 0) ? num1 / num2 : 0;

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {diff}");
            Console.WriteLine($"Product: {prod}");
            
            if (num2 == 0)
            {
                Console.WriteLine("Division: Cannot divide by zero.");
            }
            else
            {
                Console.WriteLine($"Quotient: {quot}");
            }

            // BREAKPOINT: Check sum parity evaluation.
            if (sum % 2 == 0)
                Console.WriteLine("The sum is even.");
            else
                Console.WriteLine("The sum is odd.");
        }
    }
}