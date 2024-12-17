namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, from simple calculator");
            Console.WriteLine();

            bool continueCalculating = true;

            while (continueCalculating)
            {

                Console.WriteLine("Enter first number :");
                double firstNumber = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter second number :");
                double secondNumber = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Choose operation: ");
                Console.WriteLine("1 Addition");
                Console.WriteLine("2 Subtract");
                Console.WriteLine("3 Multiply");
                Console.WriteLine("4 Divide");
                Console.WriteLine("5 Power");
                Console.WriteLine("6 Square root");

                int choice = Convert.ToInt32(Console.ReadLine());

                double result = 0;

                switch (choice)
                {
                    case 1:
                        result = firstNumber + secondNumber;
                        break;

                    case 2:
                        result = firstNumber - secondNumber;
                        break;

                    case 3:
                        result = firstNumber * secondNumber;
                        break;

                    case 4:
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            throw new DivideByZeroException();
                        }
                        break;

                    case 5:
                        result = Math.Pow(firstNumber, secondNumber);
                        break;

                    case 6:
                        result = Math.Sqrt(firstNumber);
                        break;

                    default:
                        Console.WriteLine("Something went wrong try again...");
                        return;
                }
                Console.WriteLine();

                Console.WriteLine($"Result: {result}");

                Console.WriteLine("Do you want to perform another operation? (y/n):");
                string userResponse = Console.ReadLine().ToLower();

                if (userResponse == "n")
                {
                    continueCalculating = false;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using the calculator! Goodbye!");
        }
    }
}
