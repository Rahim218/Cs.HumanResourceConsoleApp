using Cs.HumanResourceConsoleApp.Classes;
using System;

namespace Cs.HumanResourceConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee(Enums.EmployeeDepartament.Credite)
            {
                FullName = "Rahim Valiyev",
                Position = Enums.EmployeePosition.Fronend_Developer,
                Salary = 1500,
                

            };
            Employee employee2 = new Employee(Enums.EmployeeDepartament.Finance)
            {
                FullName = "Rahim Valiyev",
                Position = Enums.EmployeePosition.Backend_Developer,
                Salary = 1500,
               

            };

            Console.WriteLine($"{employee.No} -{employee.FullName} - {employee.Salary} - {employee.Position}- {employee.Departament}");
            Console.WriteLine($"{employee2.No} -{employee2.FullName} - {employee2.Salary} - {employee2.Position}- {employee2.Departament}");

        }
    }
}
