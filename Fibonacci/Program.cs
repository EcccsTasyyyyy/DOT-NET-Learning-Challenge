namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter positive integer: ");
            var userInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Recursive");
            for(int i = 0; i <= userInput; i++)
            {
                Console.WriteLine($"F({i}) = {FibonacciRecursive(i)}");
            }

            Console.WriteLine("\nIterative Fibonacci: ");
            for(int i = 0;i <= userInput; i++)
            {
                Console.WriteLine($"F({i}) = {FibonacciIterative(i)}");
            }
        }

        public static int FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        public static int FibonacciIterative(int n)
        {
            if (n <= 1)
                return n;

            int previous = 0, current = 1;
            for(int i = 2;  i <= n; i++)
            {
                int next = previous + current;
                previous = current;
                current = next;
            }

            return current;
        }
    }
}
