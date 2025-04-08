// Activity 3: Loops and Factorial Function

using System;

namespace LoopAndFunctionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // BREAKPOINT: Verify that numbers 1 to 10 are printed.
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            // BREAKPOINT: Ensure the while loop correctly reads user input.
            string input = "";
            while (!input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter a number (or type 'exit' to quit):");
                input = Console.ReadLine();
            }

            // BREAKPOINT: Check user input for factorial calculation.
            Console.WriteLine("Enter a number to compute its factorial:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Factorial of {n} is {Factorial(n)}");
        }

        static long Factorial(int n)
        {
            // BREAKPOINT: Inspect recursive calls for factorial computation.
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}