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
        public int ItEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Information_Technology);
        public int FinanceEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Finance);
        public int CrediteEmployeeCount => _getItEmployeeCount(x=>x.Departament==EmployeeDepartament.Credite);

        private int _maxEmployeeCountForPerDepartment = 10;
        public int MaxEmployeeCountForPerDepartment { get { return _maxEmployeeCountForPerDepartment; } }

        public void AddEmployee(Employee employee)
        {
            if (_hasEmployeeNo(employee.No))
            {
                throw new HasAlreadyBeenEmployeeEcxeption();
            }
           
            foreach (var item in _employees)
            {
                if (item.Departament == EmployeeDepartament.Information_Technology)
                {
                    
                    if (ItEmployeeCount <= _maxEmployeeCountForPerDepartment)
                    {
                        _employees.Add(item);
                    }
                    else
                    {
                        throw new OutOfLimitPersonCountException();
                    }

                }
                else if (item.Departament == EmployeeDepartament.Finance)
                {
                    
                    if (FinanceEmployeeCount <= _maxEmployeeCountForPerDepartment)
                    {
                        _employees.Add(item);
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
                        _employees.Add(item);
                    }
                    else
                    {
                        throw new OutOfLimitPersonCountException();
                    }

                }
            }

           
        }

        public void EditEmployee(int employeeNo, double salary, EmployeePosition position)
        {
            
        }

        public void RemoveEmployee(string employeeNo)
        {
           
        }

        public List<Employee> SearcEmployee(string str)
        {
            throw new NotImplementedException();
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
        private bool _hasEmployeeNo(string employeeNo)
        {
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
