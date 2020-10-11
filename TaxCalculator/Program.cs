using System;
using System.IO;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.Do();
            return;
            var employees = ReadEmployeesFromFile(@"c:\temp\employees2.csv");
            var taxScales = ReadTaxScalesFromFile(@"c:\temp\tax.csv");
            PrintEmployeesData(employees, taxScales);
        }

        static void PrintEmployeesData(Employee[] employees, TaxScale[] taxScales)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].CalculateMonthlyTax(taxScales);

                Console.WriteLine($"Id: {employees[i].Id} Name: {employees[i].FirstName} {employees[i].LastName} BD:{employees[i].BirthDate:d} " +
                    $"Joined: {employees[i].JoinDate:d} Salary: {employees[i].MonthlySalary}: Monthly Tax {employees[i].MonthlyTax}");
            }
        }

        static TaxScale[] ReadTaxScalesFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var taxScales = new TaxScale[lines.Length - 1];
            for(int i = 1; i <= lines.Length -1; i++)
            {
                var values = lines[i].Split(',');
                var scale = new TaxScale()
                {
                    From = decimal.Parse(values[0]),
                    To = string.IsNullOrEmpty(values[1]) ? null : (decimal?)decimal.Parse(values[1]),
                    Base = decimal.Parse(values[2]),
                    Percent = decimal.Parse(values[3])
                };
                taxScales[i - 1] = scale;
            }
            return taxScales;
        }
         
        static Employee[] ReadEmployeesFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var employees = new Employee[lines.Length - 1];

            for (int i = 1; i <= lines.Length - 1; i++)
            {
                var values = lines[i].Split(',');
                var emp = new Employee()
                {
                    Id = int.Parse(values[0]),
                    FirstName = values[1],
                    LastName = values[2],
                    BirthDate = DateTime.Parse(values[3]),
                    MonthlySalary = decimal.Parse(values[4]),
                    JoinDate = DateTime.Parse(values[6]),
                    ManagerId = string.IsNullOrEmpty(values[5]) ? null : (int?)int.Parse(values[5])
            };
                employees[i - 1] = emp;
            }
            return employees;
        }

    }
}
