using Cs.HumanResourceConsoleApp.Classes;
using Cs.HumanResourceConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Interfaceses
{
    internal interface IHumanResourceManager
    {
         int MaxEmployeeCountForPerDepartment { get; }
        void AddEmployee(Employee employee);
        void RemoveEmployee(string employeeNo);
        void EditEmployee(int employeeNo,double salary,EmployeePosition position);
        List<Employee> SearcEmployee(string str);
    }
}
