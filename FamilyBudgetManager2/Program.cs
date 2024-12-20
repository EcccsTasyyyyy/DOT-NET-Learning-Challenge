namespace FamilyBudgetManager2
{
    internal class Program
    {
        const decimal minSalary = 1000;
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            decimal[,] expenses = new decimal[12, 4];

            decimal totalSalary = 0;
            decimal totalExpenses = 0;
            decimal maxExpenses = 0;
            string maxExpenseMonth = "";
            int aboveMinSalaryCount = 0;

            //for (int i  = 0; i < months.Length; i++)
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"\tSalary and expenses for {months[i]}");

                Console.Write("Salary:");
                expenses[i, 0] = Convert.ToDecimal(Console.ReadLine());
                totalSalary += expenses[i,0];

                if (expenses[i, 0] > minSalary)
                {
                    aboveMinSalaryCount++;
                }

                Console.Write($"Communal bills:");
                expenses[i, 1] = Convert.ToDecimal(Console.ReadLine());

                Console.Write($"Grocery expenses: ");
                expenses[i, 2] = Convert.ToDecimal(Console.ReadLine());

                Console.Write($"Entertainment expenses: ");
                expenses[i, 3] = Convert.ToDecimal(Console.ReadLine());

                decimal monthlyExpenses = expenses[i, 1] + expenses[i, 2] + expenses[i, 3];
                totalExpenses += monthlyExpenses;

                if(monthlyExpenses > maxExpenses)
                {
                    maxExpenses = monthlyExpenses;
                    maxExpenseMonth = months[i];
                }
            }

            Console.WriteLine($"\nTotal yearly salary: {totalSalary}");

            //decimal avarageMonthlyExpenses = totalExpenses / months.Length;
            decimal avarageMonthlyExpenses = totalExpenses / 2;
            Console.WriteLine($"Avarage monthly expenses: {avarageMonthlyExpenses}");

            Console.WriteLine($"How many times was salary above minimal: {aboveMinSalaryCount}");

            Console.WriteLine($"Most expensive month was: {maxExpenseMonth} with amount of: {maxExpenses}");

            Console.Write("\nChoose a month for a detailed report: ");
            int monthIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if(monthIndex >= 0 && monthIndex <= 12)
            {
                decimal salary = expenses[monthIndex, 0];
                decimal communalBills = expenses[monthIndex, 1];
                decimal groceryExpenses = expenses[monthIndex, 2];
                decimal enterteinmentExpenses = expenses[monthIndex, 3];
                decimal total = communalBills + groceryExpenses + enterteinmentExpenses;

                Console.WriteLine($"\nDetailed report for {months[monthIndex]}");
                Console.WriteLine($"Salary: {salary}");
                Console.WriteLine($"Communal bills: {communalBills}");
                Console.WriteLine($"Grocery expenses: {groceryExpenses}");
                Console.WriteLine($"Enterteinment expenses: {enterteinmentExpenses}");
                Console.WriteLine($"Total expenses for month: {total}");
            }

            Console.Write("\nEnter saving goal: ");
            decimal savingGoal = Convert.ToDecimal(Console.ReadLine());
            decimal avarageSavings = (totalSalary - totalExpenses) / 2;
            int monthsToReachGoal = (int)Math.Ceiling(savingGoal / avarageSavings);
            Console.WriteLine($"It`s gonna take {monthsToReachGoal} months to reach your goal of {savingGoal}");

            decimal maxSavings = 0;
            string highestMonthlySaving = string.Empty;

            //for (int i = 0; i < months.Length; i++)
            for (int i = 0; i < 2;  i++)
            {
                decimal monthlySavings = expenses[i, 0] - (expenses[i, 1] + expenses[i, 2] + expenses[i, 3]);
                if(monthlySavings > maxSavings )
                {
                    maxSavings = monthlySavings;
                    highestMonthlySaving = months[i];
                }
            }

            Console.WriteLine($"Highest monthly saving was  in {highestMonthlySaving}, with amount of {maxSavings}");

            Console.WriteLine("\t---- Yearly Expenses Visualization ----");
            //for (int i = 0; i < months.Length; i++)
            for (int i = 0; i < 2; i++)
            {
                decimal monthlyTotal = expenses[i, 1] + expenses[i, 2] + expenses[i, 3];
                int stars = (int)(monthlyTotal / 100);
                Console.WriteLine($"{months[i]}: {new string('*', stars)}");
            }
        }
    }
}
