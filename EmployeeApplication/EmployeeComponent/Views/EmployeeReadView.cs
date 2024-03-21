using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeReadView
    {
        private Employees employees;

        public EmployeeReadView(Employees employees)
        {
            this.employees = employees;
        }

        public void RunReadView()
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the id of the employee you wish to view.");

            int id = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

            int index = employees.Find(id);

            if (index != -1)
            {
                Employee employee = employees[index];

                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeRecordHeading(employee));

                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Gender: {employee.Gender}");
                Console.WriteLine($"Manager: {employee.IsManager}");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please press any key to return to the main view...");


            }
            else
            {
                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeNotFoundMessage(id));
            }
            Console.ReadKey();
        }
    }
}
