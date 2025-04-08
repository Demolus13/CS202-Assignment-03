// Activity 5: Exception Handling

using System;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // BREAKPOINT: Ensure correct reading of dividend and divisor.
                Console.WriteLine("Enter dividend:");
                double dividend = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter divisor:");
                double divisor = Convert.ToDouble(Console.ReadLine());
                
                // BREAKPOINT: Check division operation and exception handling.
                double result = dividend / divisor;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                // BREAKPOINT: Verify that division-by-zero is caught.
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                // BREAKPOINT: Check general exception handling.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}