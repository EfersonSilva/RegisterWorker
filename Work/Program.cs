using System;
using System.Globalization;
using Work.Entities;
using Work.Entities.Enums;

namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's Name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter Worker Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior, MIdLevel, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Enter Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i} contracts Data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hour): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);

            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income(MM/yyyy): ");
            string montAndYear = Console.ReadLine();
            int month = int.Parse(montAndYear.Substring(0, 2));
            int year = int.Parse(montAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Incame for {montAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)} ");


        }
    }
}
