using Cs.HumanResourceConsoleApp.Classes;
using Cs.HumanResourceConsoleApp.Enums;
using System;

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
                        Console.WriteLine("Departament daxil edin :");
                        foreach (var item in Enum.GetValues(typeof(EmployeeDepartament)))
                        {
                            Console.WriteLine($"{(int)item} - {item}");
                        }
                        int depart;
                       
                        do
                        {


                            depart = int.Parse(Console.ReadLine());
                            
                        } while (Enum.IsDefined(typeof(EmployeeDepartament), depart) && isOk == false);


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
    }
}
