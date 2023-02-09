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
                FullName = "Xalid Suleymanov",
                Position = Enums.EmployeePosition.Backend_Developer,
                Salary = 2500,


            };
            Employee employee3 = new Employee(Enums.EmployeeDepartament.Information_Technology)
            {
                FullName = "Behruz Rehimli",
                Position = Enums.EmployeePosition.Full_Stack_Developer,
                Salary = 1000,


            };
            Employee employee4 = new Employee(Enums.EmployeeDepartament.Finance)
            {
                FullName = "Nuru Huseynov",
                Position = Enums.EmployeePosition.System_Admistrator,
                Salary = 500,


            };


            HumanResourceManager hrm = new HumanResourceManager();
            hrm.AddEmployee(employee);
            hrm.AddEmployee(employee2);
            hrm.AddEmployee(employee3);
            hrm.AddEmployee(employee4);


            foreach (var item in hrm.Employees)
            {
                Console.WriteLine($"{item.No} -{item.FullName} - {item.Salary} - {item.Position}- {item.Departament}");
            }
            hrm.RemoveEmployee("CR1000");
            Console.WriteLine();
            foreach (var item in hrm.Employees)
            {
                Console.WriteLine($"{item.No} -{item.FullName} - {item.Salary} - {item.Position}- {item.Departament}");
            }
            Console.WriteLine();
            
            foreach (var item in hrm.SearcEmployee("Nuru"))
            {
                
                    Console.WriteLine($"{item.No} -{item.FullName} - {item.Salary} - {item.Position}- {item.Departament}");
                

            }
            Console.WriteLine();
            hrm.EditEmployee("FN1003", 1500, Enums.EmployeePosition.Fronend_Developer);
            foreach (var item in hrm.Employees)
            {
                Console.WriteLine($"{item.No} -{item.FullName} - {item.Salary} - {item.Position}- {item.Departament}");
            }





        }
    }
}
