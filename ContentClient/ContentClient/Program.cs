
using ContentClient.Entities;
using ContentClient.Entities.Enums;
using System.Globalization;

namespace program
{
    class WorkerContent
    {
        static void Main(String[] Args)
        {
            

            Console.Write("Enter department name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");     
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level= Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary=double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department depart = new Department(deptName);
            Worker worker=new Worker(name, level, baseSalary, depart);

            Console.WriteLine("How many contracts to this worker? ");
            int n=int.Parse(Console.ReadLine());    

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract hourContract= new HourContract(date, valueHour, hours);
                worker.AddContratact(hourContract);
            }


            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string yearMonth = Console.ReadLine();
            int month = int.Parse(yearMonth.Substring(0, 2));
            int year = int.Parse(yearMonth.Substring(3));
            Console.WriteLine();
            Console.WriteLine("Name: "+worker.Name);
            Console.WriteLine("Department: "+worker.Department.Name);
            Console.WriteLine("Income for "+yearMonth+" :" +worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));



        }


    }

}