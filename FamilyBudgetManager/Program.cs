namespace FamilyBudgetManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t--- Welcome to Family Budget Manager ---");

            const decimal minSalary = 1000;
            Console.WriteLine();

            Console.Write("Enter your First: ");
            string name = Console.ReadLine();

            Console.Write("Enter your sallary: ");
            decimal userSalary = Convert.ToDecimal(Console.ReadLine());

            decimal salaryDifference = userSalary - minSalary;
            Console.Write($"Salary difference : {salaryDifference}");

            LivingExpences[] livingExpenses =
            {
                new() {Rent = 550, CommunalExpenses = 250, GroceryExpenses = 350}
            };

            decimal sumOfLivingExpences = 0;
            foreach(var i  in livingExpenses)
            {
                sumOfLivingExpences += i.Rent + i.CommunalExpenses + i.GroceryExpenses;
            }

            decimal moneyLeft = userSalary - sumOfLivingExpences;
            Console.WriteLine($"\nAmount of money left after paying expences: {moneyLeft}");

            if(moneyLeft < 0)
            {
                Console.WriteLine("WARNING");
            }

            Console.Write("Enter savings goal: ");
            decimal savingsGoal = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter how much you can save per month: ");
            decimal monthlySaving = Convert.ToDecimal(Console.ReadLine());

            int months = (int)Math.Ceiling(savingsGoal / monthlySaving);

            Console.WriteLine($"It`s gonna take {months} month to reach your goal {savingsGoal}");
        }
    }
    internal class LivingExpences
    {
        public decimal Rent {  get; set; }
        public decimal CommunalExpenses { get; set; }
        public decimal GroceryExpenses { get; set; }
    }
}
