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
            Console.WriteLine($"{avarageMonthlyExpenses}");

            Console.WriteLine($"{aboveMinSalaryCount}");

            Console.WriteLine($"{maxExpenseMonth} {maxExpenses}");

            Console.Write("\nChoose a month for a detailed report: ");
            int monthIndex = Convert.ToInt32(Console.ReadLine());

            if(monthIndex >= 1 && monthIndex <= 12)
            {
                int monthNumber = monthIndex - 1;

                decimal salary = expenses[monthNumber, 0];
                decimal communalBills = expenses[monthNumber, 1];
                decimal groceryExpenses = expenses[monthNumber, 2];
                decimal enterteinmentExpenses = expenses[monthNumber, 3];
                decimal total = communalBills + groceryExpenses + enterteinmentExpenses;

                Console.WriteLine($"\nDetailed report for {months[monthNumber]}");
                Console.WriteLine($"Salary: {salary}");
                Console.WriteLine($"Communal bills: {communalBills}");
                Console.WriteLine($"Grocery expenses: {groceryExpenses}");
                Console.WriteLine($"Enterteinment expenses: {enterteinmentExpenses}");
                Console.WriteLine($"Total expenses for month: {total}");
            }
        }
    }
}
