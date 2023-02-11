using Cs.HumanResourceConsoleApp.Enums;
using Cs.HumanResourceConsoleApp.Exceptions;
using Cs.HumanResourceConsoleApp.Interfaceses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Classes
{
    internal class HumanResourceManager : IHumanResourceManager
    {
         List<Employee> _employees = new List<Employee>();
        public List<Employee> Employees { get { return _employees; } }
        private int ItEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Information_Technology);
        private int FinanceEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Finance);
        private int CrediteEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Credite);        
        static int _maxEmployeeCountForPerDepartment = 10;
       

        public void AddEmployee(Employee employee)
        {
            if (HasEmployeeNo(employee.No))
            {
                throw new HasAlreadyBeenEmployeeEcxeption();
            }
           
                if (employee.Departament == EmployeeDepartament.Information_Technology)
                {
                    
                    if (ItEmployeeCount <= _maxEmployeeCountForPerDepartment)
                    {
                        _employees.Add(employee);
                    }
                    else
                    {
                        throw new OutOfLimitPersonCountException();
                    }

                }
                else if (employee.Departament == EmployeeDepartament.Finance)
                {
                    
                    if (FinanceEmployeeCount <= _maxEmployeeCountForPerDepartment)
                    {
                        _employees.Add(employee);
                    }
                    else
                    {
                        throw new OutOfLimitPersonCountException();
                    }


                }
                else
                {
                    
                    if (CrediteEmployeeCount <= _maxEmployeeCountForPerDepartment)
                    {
                        _employees.Add(employee);
                    }
                    else
                    {
                        throw new OutOfLimitPersonCountException();
                    }

                }
            

           
        }

        public void EditEmployee(string employeeNo, double salary, EmployeePosition position)
        {
            if (!HasEmployeeNo(employeeNo))
            {
                throw new NotFoundEmployeeException();
            }
            foreach (var item in _employees)
            {
                if (item.No == employeeNo)
                {
                    item.Salary = salary;
                    item.Position = position;
                }
            }
        }

        public void RemoveEmployee(string employeeNo)
        {
            if (!HasEmployeeNo(employeeNo))
            {
                throw new NotFoundEmployeeException();
            }
            foreach (var item in _employees)
            {
                if (item.No == employeeNo)
                {
                    _employees.Remove(item);
                    break;
                   
                }

            }
            

        }

        public List<Employee> SearcEmployee(Predicate<Employee> predicate)
        {
            var list = new List<Employee>();
            bool searcName = false;
            foreach (var item in _employees)
            {
                if (predicate(item))
                {
                    list.Add(item);
                    searcName = true;
                }
            }
            if (searcName==true)
            {
                return list;
            }
            throw new NotFoundEmployeeException();
        }


        private int _getItEmployeeCount(Predicate<Employee> check)
        {
            int count = 0;
            foreach (var item in _employees)
            {
                if (check(item))
                {
                    count++;
                }
            }
            return count;
        }
        public bool HasEmployeeNo(string employeeNo)
        {
            if (string.IsNullOrWhiteSpace(employeeNo))
            {
                return false;
            }
            foreach (var item in _employees)
            {
                if (item.No == employeeNo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
