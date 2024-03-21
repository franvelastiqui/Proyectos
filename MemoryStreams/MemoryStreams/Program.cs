using System.Text;

namespace MemoryStreams
{
    internal class Program
    {
        const int IdOffset = 0;
        const int IdLength = 16;

        const int FirstNameOffset = 16;
        const int FirstNameLength = 40;

        const int LastNameOffset = 56;
        const int LastNameLength = 40;

        const int SalaryOffset = 96;
        const int SalaryLength = 20;

        const int GenderOffset = 116;
        const int GenderLength = 4;

        const int IsManagerOffset = 120;
        const int IsManagerLength = 10;

        const int RecordLength = IdLength + FirstNameLength + LastNameLength + SalaryLength + GenderLength + IsManagerLength;

        static void Main(string[] args)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

            MemoryStream ms = new MemoryStream(RecordLength);

            SeedData(unicodeEncoding, ms);

            ms.Seek(0, SeekOrigin.Begin);

            Console.WriteLine("Employee Record before Promotion");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"Id: {GetField(unicodeEncoding, ms, IdOffset, IdLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, FirstNameOffset, FirstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, LastNameOffset, LastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, SalaryOffset, SalaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, GenderOffset, GenderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength)}");

            Console.WriteLine();
            Console.WriteLine("Press any key to update the above employee's record...");
            Console.ReadKey();
            Console.WriteLine();

            ms.Seek(0, SeekOrigin.Begin);

            UpdateSalary(unicodeEncoding, ms, 80000);
            UpdateIsManager(unicodeEncoding, ms, true);

            ms.Seek(0, SeekOrigin.Begin);

            Console.WriteLine("Employee Record after Promotion");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {GetField(unicodeEncoding, ms, IdLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, FirstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, LastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, SalaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, GenderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, IsManagerLength)}");
        }

        private static void SeedData(UnicodeEncoding unicodeEncoding, MemoryStream ms)
        {
            int id = 1003;
            string firstName = "John";
            string lastName = "Jenkins";
            decimal salary = 60000;
            char gender = 'm';
            bool isManager = false;

            string employeeRecord = id.ToString().PadRight(IdLength / 2) + firstName.PadRight(FirstNameLength / 2) + lastName.PadRight(LastNameLength / 2) + salary.ToString().PadRight(SalaryLength / 2) + gender.ToString().PadRight(GenderLength / 2) + isManager.ToString().PadRight(IsManagerLength / 2);

            byte[] employeeData = unicodeEncoding.GetBytes(employeeRecord);

            ms.Write(employeeData, 0, employeeRecord.Length * 2);

        }

        private static string GetField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int offset, int length)
        {
            ms.Seek(offset, SeekOrigin.Begin);

            byte[] byteArray = new byte[length];

            int count = ms.Read(byteArray, 0, length);

            string fieldValue = new string(ReturnCharArrayFromByteArray(unicodeEncoding, byteArray, count));

            return fieldValue.Trim();

        }

        private static string GetField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int length)
        {
            ms.Seek(0, SeekOrigin.Current);

            byte[] byteArray = new byte[length];

            int count = ms.Read(byteArray, 0, length);

            string fieldValue = new string(ReturnCharArrayFromByteArray(unicodeEncoding, byteArray, count));

            return fieldValue.Trim();
        }
        private static char[] ReturnCharArrayFromByteArray(UnicodeEncoding unicodeEncoding, byte[] byteArray, int count)
        {
            char[] charArray = new char[unicodeEncoding.GetCharCount(byteArray, 0, count)];

            unicodeEncoding.GetDecoder().GetChars(byteArray, 0, count, charArray, 0);

            return charArray;
        }

        private static void Updatefield(UnicodeEncoding unicodeEncoding, MemoryStream ms, int offset, int length, string newValue)
        {
            byte[] data = unicodeEncoding.GetBytes(newValue);

            ms.Seek(offset, SeekOrigin.Begin);
            ms.Write(data, 0, length);
        }

        private static void UpdateIsManager(UnicodeEncoding unicodeEncoding, MemoryStream ms, bool isManager)
        {

            string newValue = isManager.ToString().PadRight(IsManagerLength / 2);

            Updatefield(unicodeEncoding, ms, IsManagerOffset, IsManagerLength, newValue);

        }
        private static void UpdateSalary(UnicodeEncoding unicodeEncoding, MemoryStream ms, decimal salary)
        {
            string newValue = salary.ToString().PadRight(SalaryLength / 2);

            Updatefield(unicodeEncoding, ms, SalaryOffset, SalaryLength, newValue);

        }
    }
}