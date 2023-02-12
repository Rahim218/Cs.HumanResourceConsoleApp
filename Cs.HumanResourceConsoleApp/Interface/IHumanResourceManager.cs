using Cs.HumanResourceConsoleApp.Classes;
using Cs.HumanResourceConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Interfaceses
{
    internal interface IHumanResourceManager
    {
        
        List<Employee> Employees { get; }
        void AddEmployee(Employee employee);
        void RemoveEmployee(string employeeNo);
        void EditEmployee(string employeeNo,double salary,EmployeePosition position);
        List<Employee> SearcEmployee(Predicate<Employee> predicate);
    }
}
