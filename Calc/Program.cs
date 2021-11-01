using System;


namespace Calc
{
    class Program
    {
        enum TrigShit
        {
            sin, tan, cos
        }
        static double SimpleCalc(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 3)
            {
                if (double.TryParse(parts[0], out double number1) &&
                    double.TryParse(parts[2], out double number2))
                {
                    switch (parts[1])
                    {
                        case "+": return number1 + number2;
                        case "-": return number1 - number2;
                        case "*": return number1 * number2;
                        case "/": 
                                if (number2 != 0)
                                    return number1 / number2;
                                else
                                {
                                    throw new Exception("Divide by zero");
                                }
                        case "**": return Math.Pow(number1, number2);
                        default: throw new Exception("Incorrect input");
                    }
                }
                else throw new Exception("Incorect input");
            }
            else if (parts.Length == 2)
            {
                if (double.TryParse(parts[1], out double number1))
                {
                    TrigShit.TryParse(parts[0], out TrigShit s);
                    switch (s)
                    {
                        case (TrigShit.cos): return Math.Cos(number1);
                        case (TrigShit.sin): return Math.Sin(number1);
                        case (TrigShit.tan): return Math.Tan(number1);
                        default: throw new Exception("Incorrect input");
                    }
                }
                else
                {
                    throw new Exception("Incoreect input");
                }
            }
            else
            {
                throw new Exception("Incorect input");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***CALCULATOR***");
            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();
                try
                {
                    Console.WriteLine("Result: " + SimpleCalc(input));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Try again.");
                }
            }
        }
    }
}
