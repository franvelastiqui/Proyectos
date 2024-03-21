using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeRecordsView
    {
        private Employees employees = null;

        internal protected EmployeeRecordsView(Employees employees)
        {
            this.employees = employees;
        }
        public void RunRecordsView()
        {

            Console.WriteLine(EmployeeCommonOutputText.GetColumnHeadings());
            Console.WriteLine();

            foreach (Employee emp in employees)
            {
                Console.Write(emp.GetEmployeeInformation());
            }
        }
        }
}
