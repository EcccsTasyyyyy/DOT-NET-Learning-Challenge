using System.Text;

namespace Text_Analyzer
{
    internal class Program
    {
        const int maxLength = 100;
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string? userInput = Console.ReadLine();

            if (userInput is null)
            {
                throw new ArgumentNullException(nameof(userInput));
            }

            StringBuilder sb = new StringBuilder(userInput);
            for(int i = sb.Length - 1; i >= 0; i--)
            {
                Console.Write(sb[i]);
            }

            //char[] charArray = sb.ToString().ToCharArray();
            //Array.Reverse(charArray);
            //Console.WriteLine($"\n{new string(charArray)}");

            int count = 0;
            foreach(char ch in userInput.ToLower())
            {
                if ("aeiou".Contains(ch))
                {
                    count++;
                }
            }
            Console.WriteLine($"\n\nAmount of vowels in the text: {count}");

            StringBuilder sb2 = new StringBuilder(userInput);
            foreach (char ch in sb2.ToString())
            {
                if (char.IsDigit(ch))
                {
                    sb2.Replace(ch, '*');
                }
            }
            Console.WriteLine($"\nText with digits replaced: {sb2}");

            Console.WriteLine("\nWords that starts with an uppercase letter:");
            string[] words = userInput.Split(new[] {' ','\t', '\n', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (char.IsUpper(words[i][0]))
                {
                    Console.WriteLine(words[i]);
                }
            }

            StringBuilder sb3 = new StringBuilder(userInput);
            if (sb3.Length > maxLength)
            {
                sb3.Length = maxLength;
                sb3.Append("...");
                Console.WriteLine($"\nShortened text: {sb3}");
            }
            else
            {
                Console.WriteLine($"\nText is within allowed length: {sb3}");
            }

            words = userInput.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string word = string.Empty;
            count = 0;
            foreach(string s in words)
            {
                if(s.Length > count)
                {
                    word = s;
                    count = s.Length;
                }
            }
            Console.WriteLine($"\nWord with the maximum length: {word}");
        }
    }
}
