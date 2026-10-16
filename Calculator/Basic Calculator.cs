using System;

class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("=== Simple Calculator ===");

        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        string op = Console.ReadLine();

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                    result = num1 / num2;
                else
                    Console.WriteLine("Error: Division by zero!");
                break;
            default:
                Console.WriteLine("Invalid operator!");
                break;
        }

        Console.WriteLine($"Result: {result}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
