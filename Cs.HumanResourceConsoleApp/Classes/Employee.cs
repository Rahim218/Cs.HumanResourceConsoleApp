using Cs.HumanResourceConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Classes
{
    internal class Employee
    {
        static int _totalCount = 1000;
      

        public Employee(EmployeeDepartament departament)
        {
            Departament = departament;
            if (departament == EmployeeDepartament.Information_Technology)
            {
                _no = "IT" + _totalCount++;
               
            }
            else if (departament == EmployeeDepartament.Finance)
            {
                _no = "FN" + _totalCount++;
                
            }
            else
            {
                _no = "CR" + _totalCount++;
                
            }
        }
        private string _no;
        public string No { get { return _no; } }
        
        public string FullName;
        public EmployeePosition Position;
        public double Salary;       
        public EmployeeDepartament Departament;
        public DateTime StartDate;

    }
}
