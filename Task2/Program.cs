using System;

namespace Task2
{
    enum OperationType
    {
        Add = 1,
        Subtract,
        Multiply,
        Divide
    }

    delegate double Operation(double x, double y);

    internal static class Arithmetic
    {
        public static Operation SelectOperation(OperationType opTtpe)
        {
            return opTtpe switch
            {
                OperationType.Add => (x, y) => x + y,
                OperationType.Subtract => (x, y) => x - y,
                OperationType.Multiply => (x, y) => x * y,
                OperationType.Divide => (x, y) =>
                {
                    if (y != 0) return x / y;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Second ardgument can't be 0!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return 0;
                    }
                },
                _ => (x, y) => x + y
            };
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1-4 for operation: \n\t1. Add \n\t2. Subtract \n\t3. Multiply \n\t4. Divide");
            Int32.TryParse(Console.ReadLine(), out int opNumber);
            if (Enum.IsDefined(typeof(OperationType), opNumber))
            {
                OperationType optype = (OperationType)opNumber;
                Operation operation = Arithmetic.SelectOperation(optype);
                Console.WriteLine("Enter first number:");
                double x = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double y = Double.Parse(Console.ReadLine());
                double result = operation(x, y);
                Console.WriteLine($"result = {result}");
            }
            else
                Console.WriteLine("Wrong input");
        }
    }
}
