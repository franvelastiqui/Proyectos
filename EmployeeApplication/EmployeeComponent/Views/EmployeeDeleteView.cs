using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeDeleteView
    {
        private Employees employees;
        public EmployeeDeleteView(Employees employees)
        {
            this.employees = employees;
        }

        public void RunDeleteView()
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Id of the employee you wish to delete.");

            int id = Convert.ToInt32(Console.ReadLine());

            int index = employees.Find(id);



            if (index != -1)
            {
                Employee employee = employees[index];

                Console.WriteLine($"Are you sure you wish to delete employee with Id({employee.Id})? (y/n)");

                ConsoleKey consoleKey = Console.ReadKey().Key;

                if (consoleKey == ConsoleKey.Y)
                {
                    employees.Delete(index);
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());
                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeNotFoundMessage(id));
                Console.ReadKey();
            }
        }
    }
}
