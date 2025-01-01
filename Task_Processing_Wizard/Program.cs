namespace Task_Processing_Wizard;

internal class Program
{
    static void Main(string[] args)
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nSelect an operation: ");
            Console.WriteLine("1. Generate random matrix.");
            Console.WriteLine("2. Check if a number is a palindrome.");
            Console.WriteLine("3. Reverse a sentence.");
            Console.WriteLine("4. Rotate matrix 90 degrees.");
            Console.WriteLine("5. Check if a number is an Armstrong number.");
            Console.WriteLine("6. Check if a number is prime");
            Console.WriteLine("0. Exit.");

            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GenerateAndDisplayMatrix();
                    break;
                case 2:
                    CheckPalindrome();
                    break;
                case 3:
                    ReverseSentence();
                    break;
                case 4:
                    RotateMatrix();
                    break;
                case 5:
                    CheckArmstrongNumber();
                    break;
                case 6:
                    CheckPrimeNumber();
                    break;
                case 0:
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void GenerateAndDisplayMatrix()
    {
        Console.WriteLine("Generating a random matrix.");
        GenerateRandomMatrix(out int[,] matrix);

        Console.WriteLine("Generated matrix: ");
        PrintMatrix(matrix);
    }
    static void GenerateRandomMatrix(out int[,] matrix)
    {
        Console.Write("Enter matrix rows: ");
        var rows = int.Parse(Console.ReadLine());

        Console.Write("Enter matrix columns: ");
        var cols = int.Parse(Console.ReadLine());

        Console.Write("Enter min value: ");
        var min = int.Parse(Console.ReadLine());

        Console.Write("Enter max valie: ");
        var max = int.Parse(Console.ReadLine());

        matrix = new int[rows, cols];

        var random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(min, max + 1);
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static void CheckPalindrome()
    {
        Console.WriteLine("Enter a number: ");
        var number = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPalindrome(number) ? "The number is palindrome." : "The number is not a palindrome.");
    }

    static bool IsPalindrome(int number)
    {
        string str = number.ToString();

        return str == new string(str.Reverse().ToArray());
    }

    static void ReverseSentence()
    {
        Console.Write("Enter a sentence: ");
        var sentence = Console.ReadLine();

        var reversed = ReverseSentenceRecursively(sentence);

        Console.WriteLine($"Reversed sentence: {reversed}");
    }

    static string ReverseSentenceRecursively(string sentence)
    {
        var words = sentence.Split(' ', 2);

        if (words.Length == 1)
        {
            return words[0];
        }

        return ReverseSentenceRecursively(words[1]) + " " + words[0];
    }

    static void RotateMatrix()
    {
        Console.WriteLine("Generating and rotating matrix.");
        GenerateRandomMatrix(out int[,] matrix);

        Console.WriteLine("Original matrix: ");
        PrintMatrix(matrix);

        var rotated = RotateMatrix90Degrees(matrix);

        Console.WriteLine("Rotated matrix: ");
        PrintMatrix(rotated);
    }

    static int[,] RotateMatrix90Degrees(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        var rotated = new int[cols, rows];

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                rotated[j, rows - 1 - i] = matrix[i, j];
            }
        }

        return rotated;
    }

    static void CheckArmstrongNumber()
    {
        Console.Write("Enter a number: ");
        var number = int.Parse(Console.ReadLine());

        Console.WriteLine(IsArmstrongNumber(number) ? "The number is Armstrong number." : "The number is not Armstorng number.");
    }

    static bool IsArmstrongNumber(int number)
    {
        int sum = 0, temp = number, digits = number.ToString().Length;

        while(temp > 0)
        {
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, digits);
            temp /= 10;
        }

        return sum == number;
    }

    static void CheckPrimeNumber()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPrime(number) ? "The number is prime." : "The number is not prime");
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for(int i = 2; i <= Math.Sqrt(number); i++)
        {
            if(number % i == 0) return false;
        }

        return true;
    }
}
