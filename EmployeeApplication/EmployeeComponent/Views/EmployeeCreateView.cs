using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeCreateView
    {
        private Employees employees;

        public EmployeeCreateView(Employees employees)
        {
            this.employees = employees;
        }

        public void RunCreateView()
        {
            string firstName;
            string lastName;
            decimal annualSalary;
            char gender;
            bool isManager;

            Console.Clear();

            Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

            Console.WriteLine();
            Console.WriteLine(EmployeeCommonOutputText.GetCreateHeading());

            Console.Write("First Name: ");
            firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            lastName = Console.ReadLine();

            Console.Write("Annual Salary: ");
            annualSalary = decimal.Parse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

            Console.Write("Gender (m/f): ");
            gender = Convert.ToChar(Console.ReadLine());

            Console.Write("Manager (true/false): ");
            isManager = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Please press the [S] key to save the new employee record to the system or any other key to cancel.");

            ConsoleKey consoleKey = Console.ReadKey().Key;

            if (consoleKey == ConsoleKey.S)
            {
                employees.Add(EmployeeObjectFactory.CreateNewEmployeeObject(firstName, lastName, annualSalary, gender, isManager));
            }
        }
    }
}
