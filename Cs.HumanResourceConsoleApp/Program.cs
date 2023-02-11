using Cs.HumanResourceConsoleApp.Classes;
using Cs.HumanResourceConsoleApp.Enums;
using Cs.HumanResourceConsoleApp.Exceptions;
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
                        Console.WriteLine("Departamenti daxil edin :");
                        foreach (var item in Enum.GetValues(typeof(EmployeeDepartament)))
                        {
                            Console.WriteLine($"{(int)item} - {item}");
                        }
                        var employeDepart = GetDepartamentOption();
                        foreach (var item in GetEmployeeByDepartament(hrm, employeDepart))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();

                        break;
                    case "3":
                        Console.Clear();
                        hrm.AddEmployee(CreateEmployee());
                        Console.WriteLine($"\nMenu-ya qayitmaq ucun ENTER duymesini basin");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        string employeeNo;
                        bool trueOrFalse = false;
                        do
                        {
                            Console.WriteLine("Deyisiklik etmek istediyiniz iscinin No-sunu daxil edin");
                            employeeNo = Console.ReadLine();
                            foreach (var item in hrm.Employees)
                            {


                                if (item.No==employeeNo)
                                {
                                    Console.WriteLine($"Employee Fullname : {item.FullName}\nEmployee Salary : {item.Salary}\nEmployee Position : {item.Position}");
                                    trueOrFalse = true;
                                }
                            }
                            if (trueOrFalse == false)
                            {
                                Console.WriteLine("Bu nomreli isci yoxdur....");
                                Console.WriteLine("Isci nomresi XX1001 formasinda olmalidir..(XX - Departamentin ilk iki herfidir)..");
                            }
                        } while (trueOrFalse == false);


                        Console.WriteLine("Yeni maasi daxil edin : ");
                        string newSalaryStr;
                        double newSalary;
                        bool isOk = false;
                        do
                        {
                            if (isOk == true)
                            {
                                Console.WriteLine("Maas 300 Azn den yuksek olmalidir");
                            }
                            newSalaryStr = Console.ReadLine();
                            isOk = true;

                        } while (string.IsNullOrWhiteSpace(newSalaryStr) || !double.TryParse(newSalaryStr, out newSalary) || !(newSalary >= 300));

                        Console.WriteLine("Yeni position daxil edin : ");
                        foreach (var item in Enum.GetValues(typeof(EmployeePosition)))
                        {
                            Console.WriteLine($"{(int)item} - {item}");
                        }
                        string positionStr;
                        int positionNum;
                        isOk = false;
                        do
                        {
                            if (isOk == true)
                            {
                                Console.WriteLine("Yalnizca (1),(2),(3),(4) deyerlerini daxil ede bilersiniz");
                            }
                            positionStr = Console.ReadLine();
                            isOk = true;
                        } while (!int.TryParse(positionStr, out positionNum) || !Enum.IsDefined(typeof(EmployeePosition), positionNum));
                        EmployeePosition position = (EmployeePosition)positionNum;

                        hrm.EditEmployee(employeeNo, newSalary, position);
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();

                        string employeeNo2;
                        isOk = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("\nSiyahidan silmek istediyiniz iscinin No-sunu daxil edin :");
                                employeeNo2 = Console.ReadLine();
                                hrm.RemoveEmployee(employeeNo2);
                                isOk = true;
                            }
                            catch (NotFoundEmployeeException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"Isci nomresi XX1001 formasinda olmalidir..(XX - Departamentin ilk iki herfidir)..");
                            }
                        } while (isOk == false);
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Axtarmaq istediyiniz iscinin adini daxil edin");

                        var name =GetCorrectFullNameFromConsole();
                       
                        GetSearchEmployees(hrm,x=>x.FullName.Contains(name));

                        Console.WriteLine($"\nMenu-ya qayitmaq ucun ENTER basin");

                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Ilk tarixi qeyd edin : ");
                       var firstDate = GetCorrectTimeFromConsole();

                        Console.WriteLine("Ikinci tarixi qeyd edin : ");
                       var secondDate = GetCorrectTimeFromConsole();

                        GetSearchEmployees(hrm, x => x.StartDate > firstDate && x.StartDate < secondDate);
                        Console.ReadLine();
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("Departamenti daxil edin :");
                        foreach (var item in Enum.GetValues(typeof(EmployeeDepartament)))
                        {
                            Console.WriteLine($"{(int)item} - {item}");
                        }
                        var employeeDprt = GetDepartamentOption();

                        double sum = 0;
                        int count = 0;

                        foreach (var item in hrm.SearcEmployee(x=>x.Departament==employeeDprt))
                        {
                            sum += item.Salary;
                            count++;
                        }
                        double avarage = sum/count;
                        Console.WriteLine("Secdiyiniz departamentdeki iscilerin maaslarinin ortalamasi :");
                        Console.WriteLine($"Avarage Salary - {avarage}");

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
            bool isOk = false;
            string departStr;
            int departNum;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Yalnizca (1),(2),(3) deyerlerini daxil ede bilersiniz ");
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
                    Console.WriteLine("Yalnizca (1),(2),(3),(4) deyerlerini daxil ede bilersiniz");
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

        static List<Employee> GetEmployeeByDepartament(HumanResourceManager hrm, EmployeeDepartament dprt)
        {
            List<Employee> employees = new List<Employee>();

            foreach (var item in hrm.Employees)
            {
                if (item.Departament == dprt)
                {
                    employees.Add(item);
                }
            }
            return employees;
        }

        static EmployeeDepartament GetDepartamentOption()
        {


            string dprtStr;
            int depart;
           bool isOk = false;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Yalnizca (1),(2),(3) deyerlerini daxil ede bilersiniz");
                }
                dprtStr = Console.ReadLine();
                isOk = true;
            } while (string.IsNullOrWhiteSpace(dprtStr) || !int.TryParse(dprtStr, out depart) || !Enum.IsDefined(typeof(EmployeeDepartament), depart));
            EmployeeDepartament employeeDepartament = (EmployeeDepartament)depart;
            return employeeDepartament;

        }

        static void GetSearchEmployees(HumanResourceManager hrm,Predicate<Employee> predicate)
        {
            
                try
                {
                    foreach (var item in hrm.SearcEmployee(predicate))
                    {
                        Console.WriteLine(item);

                    }
                    
                }
                catch (NotFoundEmployeeException ex)
                {

                    Console.WriteLine(" Isci tapilmadi");

                }
           
        }

        static string GetCorrectFullNameFromConsole()
        {
            
            string fullNameStr;
            bool isOk = false;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Ad ve Soyadi bosluq kimi qeyd ede bilmersiniz....");
                    Console.WriteLine($"\nAd ve Soyadi yeniden daxil edin");
                }
                fullNameStr = Console.ReadLine();
                isOk = true;

            } while (string.IsNullOrWhiteSpace(fullNameStr));

            return fullNameStr;
        }

        static DateTime GetCorrectTimeFromConsole()
        {
            string DateStr;
            DateTime Date;
             bool isOk = false;
            do
            {
                if (isOk == true)
                {
                    Console.WriteLine("Ilk onke Ay sonra Gun en son Il daxil edin");
                }
                DateStr = Console.ReadLine();
                isOk = true;
            } while (string.IsNullOrWhiteSpace(DateStr) || !DateTime.TryParse(DateStr, out Date));
            return Date;
        }
    }
}
