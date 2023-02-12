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
                Console.WriteLine("      8. Secilmis departamentdeki iscilerin maas ortalamasina bax .");
                Console.WriteLine("      0. Menyudan chix.\n");
                Console.WriteLine("\nSechiminizi daxil edin ve 'ENTER' duymesini kilikleyin.");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        if (hrm.Employees.Count>0)
                        {
                            ShowEmployee(hrm);
                        }
                        else
                        {
                            Console.WriteLine($"\n     Hal - hazirda qeydiyyatimizda isci yoxdur......");
                        }
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Departamenti daxil edin :");
                        ShowDepartamentOption();
                        var employeDepart = GetCorrectDepartamentFromConsole();
                        GetSearchEmployees(hrm, x => x.Departament == employeDepart);
                        Console.WriteLine($"      Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();

                        break;
                    case "3":
                        Console.Clear();
                        try
                        {
                            hrm.AddEmployee(CreateEmployee());
                        }
                        catch (OutOfLimitPersonCountException ex)
                        {

                            Console.WriteLine("$\n            Departamentdeki isci limiti doludur.......\n");
                        }                      
                        catch(HasAlreadyBeenEmployeeEcxeption ex)
                        {
                            Console.WriteLine($"\n           Eyni No-lu isci artiq qeydiyyatdan kecib.....");
                        }
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        if (hrm.Employees.Count>0)
                        {
                            Console.WriteLine("Isci No-sunu daxil edin :");
                            var employeeNo = GetCorrectEmpNoFromConsole(hrm);

                            GetSearchEmployees(hrm, x => x.No == employeeNo);

                            Console.WriteLine("Yeni maasi daxil edin : ");
                            var newSalary = GetCorrectSalaryFromConssole();

                            Console.WriteLine("Yeni position daxil edin : ");

                            ShowPositionOption();

                            var employeePosition = GetCorrectPositionFromConsole();

                            hrm.EditEmployee(employeeNo, newSalary, employeePosition);
                        }
                        else
                        {
                            Console.WriteLine($"\n     Hal - hazirda qeydiyyatimizda isci yoxdur......");
                        }                      
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        if (hrm.Employees.Count>0)
                        {
                            Console.WriteLine("Isci nomresini daxil edin :");
                            var employeNo = GetCorrectEmpNoFromConsole(hrm);

                            try
                            {
                                hrm.RemoveEmployee(employeNo);
                            }
                            catch (NotFoundEmployeeException ex)
                            {

                                Console.WriteLine("Isci tapilmadi");

                            }
                        }
                        else
                        {
                            Console.WriteLine($"\n     Hal - hazirda qeydiyyatimizda isci yoxdur......");
                        }
                        Console.WriteLine($"\n       Isci ugurla silindi......");
                        Console.WriteLine($"\n       Menu-ya qayidib secim etmek ucun ENTER duymesine basin.......\n");

                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Axtarmaq istediyiniz iscinin adini daxil edin");
                        string name;
                        bool checkFullName= true;
                        do
                        {
                            if (checkFullName == false)
                            {
                                Console.WriteLine($"\nAxtaris deyeri bosluq ola bilmez.Zehmet olmasa duzgun deyer daxil edin");
                            }
                            name = Console.ReadLine();
                            checkFullName = false;
                        } while (string.IsNullOrWhiteSpace(name));
                        GetSearchEmployees(hrm, x => x.FullName.Contains(name));
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Ilk tarixi qeyd edin : ");

                        var firstDate = GetCorrectTimeFromConsole();

                        DateTime seconDate;
                        bool checkSecondDate = true;
                        Console.WriteLine("Ikinci tarixi qeyd edin : ");
                        do
                        {
                            if (checkSecondDate == false)
                            {
                                Console.WriteLine("Daxil etdiyiniz tarix ilk daxil etdiyiniz tarixden boyuk olmalidir.....");
                            }
                            seconDate = GetCorrectTimeFromConsole();
                            checkSecondDate = false;
                        } while (seconDate<=firstDate);
                        

                        GetSearchEmployees(hrm, x => x.StartDate > firstDate && x.StartDate < seconDate);
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("Departamenti daxil edin :");
                        ShowDepartamentOption();
                       
                        var employeeDprt = GetCorrectDepartamentFromConsole();

                        double sum = 0;
                        int count = 0;

                        GetSearchEmployees(hrm, x => x.Departament == employeeDprt);
                        foreach (var item in hrm.SearcEmployee(x=>x.Departament == employeeDprt))
                        {
                            sum += item.Salary;
                            count++;
                        }                      
                        double avarage = sum / count;
                        Console.WriteLine("Secdiyiniz departamentdeki iscilerin maaslarinin ortalamasi :");
                        Console.WriteLine($"Avarage Salary - {avarage}");
                        Console.WriteLine($"\n       Menu -ya qayitmaq ucun ENTER duymesine basin......\n");
                        Console.ReadLine();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine($"Menu -dan cixmaq istediyinize eminsinizmi?\n1.Beli\n2.Xeyr\n");
                        Console.WriteLine("\nSechiminizi daxil edin ve 'ENTER' duymesini kilikleyin.");
                        string exit = Console.ReadLine();
                        if (exit=="1")
                        {
                            option = "0";
                            Console.WriteLine($"\n     Cixis olundu");
                        }
                        else
                        {
                            option = "1";
                            Console.WriteLine($"\n       Menu- ya qayitmaq ucun ENTER duymesini basin");
                        }
                        Console.ReadLine();
                        break;
                        default:
                        Console.Clear();
                        Console.WriteLine("\n  Zehmet olmasa sechiminiz duzgun daxil edin. Siz 0-dan 8-e qeder reqem daxil ede bilersiz.");
                        Console.WriteLine("\n    Menuya qayitmaq uchun 'ENTER' duymesini kilikleyin.");
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
            ShowDepartamentOption();
            var employeeDepart = GetCorrectDepartamentFromConsole();


            Console.WriteLine("FullName daxil edin : ");
            var fullName = GetCorrectFullNameFromConsole();



            Console.WriteLine("Position daxil edin : ");
            ShowPositionOption();
            var employeePosition = GetCorrectPositionFromConsole();


            Console.WriteLine("Maas daxil edin : ");

            var salary = GetCorrectSalaryFromConssole();


            Console.WriteLine("Ise baslama tarixini qeyd edin : ");

            var startDate = GetCorrectTimeFromConsole();

            Employee employee = new Employee(employeeDepart, salary, employeePosition, startDate, fullName);
            return employee;

        }

        static EmployeeDepartament GetCorrectDepartamentFromConsole()
        {


            string dprtStr;
            int depart;
            bool checkDepart = true;
            do
            {
                if (checkDepart == false)
                {
                    Console.WriteLine("Yalnizca (1),(2),(3) deyerlerini daxil ede bilersiniz");
                }
                dprtStr = Console.ReadLine();
                checkDepart = false;
            } while (string.IsNullOrWhiteSpace(dprtStr) || !int.TryParse(dprtStr, out depart) || !Enum.IsDefined(typeof(EmployeeDepartament), depart));
            EmployeeDepartament employeeDepartament = (EmployeeDepartament)depart;
            return employeeDepartament;

        }

        static void GetSearchEmployees(HumanResourceManager hrm, Predicate<Employee> predicate)
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
                Console.WriteLine($"\nMenyuya qayidib yeniden secim etmek ucun ENTER duymesine basin\n");

            }
        }

        static string GetCorrectFullNameFromConsole()
        {
            bool checkFullName = true;
            string fullName;
            do
            {
                if (checkFullName == false)
                {
                    Console.WriteLine("Ad ve soyad boyuk herfle baslamalidir");
                }
                fullName = Console.ReadLine();
                checkFullName = false;

            } while (string.IsNullOrWhiteSpace(fullName) || !MakeFullName(fullName));

            return fullName.Trim() ;
        }

        static DateTime GetCorrectTimeFromConsole()
        {
            string DateStr;
            DateTime Date;
            bool checkPosition = true;
            do
            {
                if (checkPosition == false)
                {
                    Console.WriteLine($"Ilk onke Ay sonra Gun en son Il(2000-{DateTime.Now.ToString("dd.MM.yyyy")} araliginda) daxil edin");
                }
                DateStr = Console.ReadLine();
                checkPosition = false;
            } while (string.IsNullOrWhiteSpace(DateStr) || !DateTime.TryParse(DateStr, out Date) || !(Date.Year>=2000 && Date<=DateTime.Now));
            return Date;
        }

        static double GetCorrectSalaryFromConssole()
        {
            bool checkSalary = true;
            string salaryStr;
            double salary;
            do
            {
                if (checkSalary == false)
                {
                    Console.WriteLine("Maas yalnizca reqem ve 300 den yuxari qeyd ede bilersiniz");
                }
                salaryStr = Console.ReadLine();
                checkSalary = false;
            } while (string.IsNullOrWhiteSpace(salaryStr) || !double.TryParse(salaryStr, out salary) || !(salary >= 300));
            return salary;
        }

        static EmployeePosition GetCorrectPositionFromConsole()
        {
            bool checkPosition = true;
            string positionStr;
            int positionNum;
            do
            {
                if (checkPosition == false)
                {
                    Console.WriteLine("Yalnizca (1),(2),(3),(4) deyerlerini daxil ede bilersiniz");
                }
                positionStr = Console.ReadLine();
                checkPosition = false;
            } while (!int.TryParse(positionStr, out positionNum) || !Enum.IsDefined(typeof(EmployeePosition), positionNum));
            EmployeePosition position = (EmployeePosition)positionNum;
            return position;
        }

        static string GetCorrectEmpNoFromConsole(HumanResourceManager hrm)
        {
            string empNo;
            bool checkEmpNo = true;
            do
            {
                if (checkEmpNo == false)
                {
                    Console.WriteLine($"\nIsci Tapilmadi\n");
                    Console.WriteLine($"\nIsci nomresi XX0000 formasinda olmalidir..(XX - Departamentin ilk iki herfidir)..");
                }
                empNo = Console.ReadLine();
                checkEmpNo = false;
            } while (string.IsNullOrWhiteSpace(empNo) || !hrm.HasEmployeeNo(empNo) );
            return empNo;

        }

        static void ShowDepartamentOption()
        {
            foreach (var item in Enum.GetValues(typeof(EmployeeDepartament)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
        }

        static void ShowPositionOption()
        {
            foreach (var item in Enum.GetValues(typeof(EmployeePosition)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
        }
    }
}
