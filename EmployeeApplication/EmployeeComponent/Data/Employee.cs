using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Data
{
    public class Employee
    {
        private static int nextId = 0;
        private int id = 0;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }


        public Employee()
        {
            nextId++;
            id = nextId;

        }

        public string GetEmployeeInformation()
        {
            string employeeInformation = $"{Id.ToString().PadRight(6)}\t{FirstName.PadRight(15)}\t{LastName.PadRight(15)}\t{AnnualSalary.ToString().PadRight(15)}\t{Gender.ToString().PadRight(6)}\t{IsManager.ToString().PadRight(7)}{Environment.NewLine}";

            return employeeInformation;

        }
    }
}
