using Cs.HumanResourceConsoleApp.Classes;
using Cs.HumanResourceConsoleApp.Enums;
using System;
using System.Collections.Generic;

namespace Cs.HumanResourceConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

         HumanResourceManager hrm = new HumanResourceManager();
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine(">>>>>>>>>>>>>>>>>MENU<<<<<<<<<<<<<<<<<<\n");
                Console.WriteLine("      1. Iscilerin siyahisina bax.");
                Console.WriteLine("      2  Departamentdeki iscilerin siyahisina bax .");
                Console.WriteLine("      3. Isci elave et.");
                Console.WriteLine("      4. Isci uzerinde deyisiklik et.");
                Console.WriteLine("      5. Isci sil.");
                Console.WriteLine("      6. Axtaris et.");
                Console.WriteLine("      7. Tarix araligina gore iscilerin sayina bax.");
                Console.WriteLine("      8. Secilmis departamentdeki iscilerin siyahisina bax .");
                Console.WriteLine("      0. Menyudan chix.\n");
                Console.WriteLine("\nSechiminizi daxil edin ve 'ENTER' duymesini kilikleyin.");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        ShowEmployee(hrm);
                        Console.ReadLine();
                        break;
                        case "2":
                        Console.Clear();
                        hrm.AddEmployee(CreateEmployee());
                        Console.WriteLine($"\nMenu-ya qayitmaq ucun ENTER duymesini basin");
                        Console.ReadLine();
                        break;
                }

            } while (option != "0");

        }
        static void ShowEmployee(HumanResourceManager hrm)
        {
            foreach (var item in hrm.Employees)
            {
                Console.WriteLine(item);
            }
        }
        static bool MakeFullName(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            var nameSurname = str.Split(' ');
            List<string> newNameSurname = new List<string>();
            int count = 0;
            foreach (var item in nameSurname)
            {
                if (item != "")
                {
                    newNameSurname.Add(item);
                    count++;
                }
            }
            if (count != 2)
            {
                return false;
            }
            if (!(HasNameAndSurname(newNameSurname[0])) || !(HasNameAndSurname(newNameSurname[1])))
            {
                return false;
            }
           
            return true;

        }
        static bool HasNameAndSurname(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            if (!char.IsUpper(str[0]))
            {
                return false;
            }
            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsLower(str[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static Employee CreateEmployee()
        {
            Console.WriteLine("Departament daxil edin :");
            foreach (var item in Enum.GetValues(typeof(EmployeeDepartament)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
            string departStr;
            int departNum;

            bool isOk = false;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Duzgun deyer daxil edin : ");
                }

                departStr = (Console.ReadLine());

                isOk = true;


            } while (!int.TryParse(departStr, out departNum) || !Enum.IsDefined(typeof(EmployeeDepartament), departNum));
            EmployeeDepartament departament = (EmployeeDepartament)departNum;
            isOk = false;
            Console.WriteLine("FullName daxil edin : ");
            string fullName;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Ad ve soyadiniz boyuk herfle baslamalidir");
                }
                fullName = Console.ReadLine();
                isOk = true;

            } while (!MakeFullName(fullName));
            isOk = false;
            Console.WriteLine("Position daxil edin : ");
            foreach (var item in Enum.GetValues(typeof(EmployeePosition)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
            string positionStr;
            int positionNum;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Yalnizca (1),(2),(3) deyerlerini daxil ede bilersiniz");
                }
                positionStr = Console.ReadLine();
                isOk = true;
            } while (!int.TryParse(positionStr, out positionNum) || !Enum.IsDefined(typeof(EmployeePosition), positionNum));
            EmployeePosition position = (EmployeePosition)positionNum;

            Console.WriteLine("Maas daxil edin : ");
            isOk = false;
            string salaryStr;
            double salary;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Maas yalnizca reqem ve 300 den yuxari qeyd ede bilersiniz");
                }
                salaryStr = Console.ReadLine();
                isOk = true;
            } while (string.IsNullOrWhiteSpace(salaryStr) || !double.TryParse(salaryStr, out salary) || !(salary >= 300));


            Console.WriteLine("Ise baslama tarixini qeyd edin : ");
            isOk = false;
            string startDateStr;
            DateTime startDate;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Ilk once Ay sonra Gun en son Il daxil edin");
                }
                startDateStr = Console.ReadLine();
                isOk = true;
            } while (string.IsNullOrWhiteSpace(startDateStr) || !DateTime.TryParse(startDateStr, out startDate));

            Employee employee = new Employee(departament, salary, position, startDate, fullName);
            return employee;
            
        }
    }
}
