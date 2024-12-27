namespace Star_Artist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Not my strong side...
            char symbol = '*';
            Star(symbol);
            Clock(symbol);

            symbol = '#';
            Cheesboard(symbol);
            Spiral(symbol);
        }

        internal static void Star(char symbol)
        {
            int size = 5;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i == 0 && j == 2) ||
                        (i == 1 && (j == 1 || j == 3)) ||
                        (i == 2 && (j == 0 || j == 4 || j == 2)) ||
                        (i == 3 && (j == 1 || j == 3)) ||
                        (i == 4 && j == 2))
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void Clock(char symbol)
        {
            int size = 7;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i == 0 && j == 3) ||
                        (i == 3 && j == 0) ||
                        (i == 3 && j == 6) ||
                        (i == 6 && j == 3))
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void Cheesboard(char symbol)
        {
            int size = 8;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write((i + j) % 2 == 0 ? symbol : ' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void Spiral(char symbol)
        {
            int size = 10;
            char[,] spiral = new char[size, size];
            int top = 0, bottom = size - 1, left = 0, right = size - 1;

            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++) spiral[top, i] = symbol;
                top++;
                for (int i = top; i <= bottom; i++) spiral[i, right] = symbol;
                right--;
                for (int i = right; i >= left; i--) spiral[bottom, i] = symbol;
                bottom--;
                for (int i = bottom; i >= top; i--) spiral[i, left] = symbol;
                left++;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(spiral[i, j] == symbol ? symbol : ' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
