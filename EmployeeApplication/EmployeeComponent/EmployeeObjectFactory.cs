using EmployeeComponent.Data;
using EmployeeComponent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent
{
    public static class EmployeeObjectFactory
    {
        private static EmployeeCreateView employeeCreateView;
        private static EmployeeReadView employeeReadView;
        private static EmployeeUpdateView employeeUpdateView;
        private static EmployeeDeleteView employeeDeleteView;

        public static Employee CreateNewEmployeeObject(string firstName, string lastName, decimal annualSalary, char gender, bool isManager)
        {
            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                AnnualSalary = annualSalary,
                Gender = gender,
                IsManager = isManager
            };
        }

        public static EmployeeRecordsView EmployeeRecordsViewObject(Employees employees)
        {
            return new EmployeeRecordsView(employees);
        }
        public static EmployeeCreateView EmployeeCreateViewObject(Employees employees)
        {
            if (employeeCreateView == null)
            {
                employeeCreateView = new EmployeeCreateView(employees);
            }

            return employeeCreateView;
        }
        public static EmployeeReadView EmployeeReadViewObject(Employees employees)
        {
            if (employeeReadView == null)
            {
                employeeReadView = new EmployeeReadView(employees);
            }

            return employeeReadView;
        }
        public static EmployeeUpdateView EmployeeUpdateViewObject(Employees employees)
        {
            if (employeeUpdateView == null)
            {
                employeeUpdateView = new EmployeeUpdateView(employees);
            }

            return employeeUpdateView;
        }
        public static EmployeeDeleteView EmployeeDeleteViewObject(Employees employees)
        {
            if (employeeDeleteView == null)
            {
                employeeDeleteView = new EmployeeDeleteView(employees);
            }

            return employeeDeleteView;
        }
    }
}
