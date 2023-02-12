using Cs.HumanResourceConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Classes
{
    internal class Employee
    {
        static int _totalCount = 1000;
      

        public Employee(EmployeeDepartament departament,double salary,EmployeePosition position,DateTime startDate,string fullName)
        {
            Departament = departament;
            Salary = salary;
            Position = position;
            StartDate = startDate;
            FullName = fullName;        
            _no = departament.ToString().Substring(0,2).ToUpper() + _totalCount++;
        }
        private string _no;
        public string No { get { return _no; } }
        
        public string FullName;
        public EmployeePosition Position;
        public double Salary;       
        public EmployeeDepartament Departament;
        public DateTime StartDate;

        public override string ToString()
        {
            return $"No : {No} - FullName : {FullName} - Salary : {Salary} - Position : {Position} - Departament : {Departament} - Stardate : {StartDate}";
        }

    }
}
