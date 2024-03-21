using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeUpdateView
    {
        private Employees employees;

        public EmployeeUpdateView(Employees employees)
        {
            this.employees = employees;
        }

        public void RunUpdateView()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the Id of the employee you wish to edit.");

            int id = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

            int index = employees.Find(id);

            if (index != -1)
            {
                string firstName;
                string lastName;
                string annualSalary;
                string gender;
                string isManager;

                Employee employee = employees[index];

                Console.WriteLine(EmployeeCommonOutputText.GetUpdateHeading(employee));

                Console.WriteLine(EmployeeCommonOutputText.GetUpdateViewAdditionalInstructions());

                Console.Write($"First Name ({employee.FirstName}): ");
                firstName = Console.ReadLine();

                Console.Write($"Last Name ({employee.LastName}): ");
                lastName = Console.ReadLine();

                Console.Write($"Annual Salary ({employee.AnnualSalary}): ");
                annualSalary = Console.ReadLine();

                Console.Write($"Gender ({employee.Gender}): ");
                gender = Console.ReadLine();

                Console.Write($"Manager ({employee.IsManager}): ");
                isManager = Console.ReadLine();

                employees.Update(employee,
                    (String.IsNullOrWhiteSpace(firstName) ? employee.FirstName : firstName),
                    (String.IsNullOrWhiteSpace(lastName) ? employee.LastName : lastName),
                    (String.IsNullOrWhiteSpace(annualSalary) ? employee.AnnualSalary : Decimal.Parse(annualSalary, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture)),
                    (String.IsNullOrWhiteSpace(gender) ? employee.Gender : Convert.ToChar(gender)),
                    (String.IsNullOrWhiteSpace(isManager) ? employee.IsManager : Convert.ToBoolean(isManager))
                );
            }
            else
            {
                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeNotFoundMessage(id));
                Console.ReadKey();
            }
        }
    }
}
