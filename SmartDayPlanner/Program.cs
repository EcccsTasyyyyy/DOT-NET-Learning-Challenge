namespace SmartDayPlanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t--- Welcome to the Smart Day Planner! ---");

            Console.Write("\nEnter the day of the week (Monday-Sunday): ");
            string? dayOfWeek = Console.ReadLine();

            Console.Write("\nEnter the temperature (°C): ");
            int temperature = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIs it going to rain? (y/n): ");
            string? rainInput = Console.ReadLine();
            bool isRaining = rainInput == "y";

            Console.Write("\nHow many free hours do you have: ");
            int freeHours = Convert.ToInt32(Console.ReadLine());

            bool isWorkday = dayOfWeek switch
            {
                "Monday" or "Tuesday" or "Wednesday" or "Thursday" or "Friday" => true,
                "Saturday" or "Sunday" => false,
                _ => throw new ArgumentException("Invalid input!")
            };

            string activity = string.Empty;
            switch (dayOfWeek)
            {
                case "Monday":
                    activity = "Go for a workout session";
                    break;

                case "Tuesday":
                    activity = "Read a book";
                    break;

                case "Wednesday":
                    activity = "Start a new project";
                    break;

                case "Thursday":
                    activity = "Watch podcast";
                    break;

                case "Friday":
                    activity = "Hang out with your friends";
                    break;

                case "Saturday":
                    activity = "Let`s go hiking";
                    break;

                case "Sunday":
                    activity = "Enjoy family time";
                    break;
                default:
                    activity = "Invalid input";
                    break;
            }

            string weatherActivity = string.Empty;
            if (temperature > 30)
            {
                weatherActivity = "It`s very hot, better to stay indoors.";
            }
            else if (temperature > 20)
            {
                weatherActivity = "Perfect weather for a walk.";
            }
            else if (temperature > 10)
            {
                weatherActivity = "It`s a good waether for sports activity.";
            }
            else
            {
                weatherActivity = "It`s cold, dress warmly if you go outside.";
            }

            string rainAdvice = isRaining ? "Possible rain, grab an umbrella or a jacket with you!" : "Skyes are clear today, walk free";

            string additionalActivity = string.Empty;
            if (freeHours > 3)
            {
                additionalActivity = "You have planty of time, lets wath some movie";
            }
            else if(freeHours > 0)
            {
                additionalActivity = "Use your free time for a short hobby session";
            }
            else
            {
                additionalActivity = "No free time today, stay focust.";
            }

            string workDay = isWorkday ? "It`s a workdy, stay productive!" : "Relax and enjoy its weekend time!";

            Console.WriteLine("\n--- Yor smart day plan ---");
            Console.WriteLine($"Day: {dayOfWeek}");
            Console.WriteLine(workDay);
            Console.WriteLine($"Suggested activity: {activity}");
            Console.WriteLine($"Weather suggestion: {weatherActivity}");
            Console.WriteLine($"Rain advice: {rainAdvice}");
            Console.WriteLine($"Free hours suggestion: {additionalActivity}");
        }
    }
}
