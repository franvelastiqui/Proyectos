using Entidades;
using System.Globalization;
using System.IO;

namespace BinaryFileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int recSize = sizeof(int) + ((Empleado.NameSize + 1) * 2) + sizeof(decimal) + (sizeof(char) - 1) + sizeof(bool);

                string rootPath = AppDomain.CurrentDomain.BaseDirectory;

                string archivoBinario = Path.Combine(rootPath, "Employees.dat");

                SeedData(archivoBinario);

                do
                {
                    ShowMainScreen(archivoBinario, recSize);
                    Console.WriteLine();
                    Console.WriteLine("Please press the 'y' key if you'd like to update a particular record \nor press any other key to end the application");

                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Y)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter the Id of the record you wish to update");

                        int inputId = Convert.ToInt32(Console.ReadLine());

                        UpdateEmpleadoRecord(inputId, archivoBinario, recSize);
                    }
                    else
                    {
                        break;
                    }

                }
                while (true);

                Console.Clear();
                Console.WriteLine("Thank you!");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private static void SeedData(string archivoBinario)
        {
            if(!File.Exists(archivoBinario))
            {
                Empleado empleadoUno = new Empleado { Id = 1001, Nombre = "Juan", Apellido = "Lopez", Salario = 20000, Genero = 'm', esSupervisor = true };
                Empleado empleadoDos = new Empleado { Id = 1002, Nombre = "Maria", Apellido = "Perez", Salario = 15000, Genero = 'f', esSupervisor = false };
                Empleado empleadoTres = new Empleado { Id = 1003, Nombre = "Carlos", Apellido = "Diaz", Salario = 10000, Genero = 'm', esSupervisor = false };

                using (BinaryWriter writer = new(new FileStream(archivoBinario, FileMode.Create)))
                {
                    AddEmpleadoRecord(writer, empleadoUno);
                    AddEmpleadoRecord(writer, empleadoDos);
                    AddEmpleadoRecord(writer, empleadoTres);
                }
            }
        }

        private static void AddEmpleadoRecord(BinaryWriter writer, Empleado empleado)
        {
            writer.Write(empleado.Id);
            writer.Write(empleado.Nombre);
            writer.Write(empleado.Apellido);
            writer.Write(empleado.Salario);
            writer.Write(empleado.Genero);
            writer.Write(empleado.esSupervisor);
        }

        private static void UpdateEmpleadoRecord(int id, string archivoBinario, int recordSize)
        {
            int totalRecords = GetNumberOfRecords(GetFileSize(archivoBinario), recordSize);

            int posicion = FindRecordById(archivoBinario, id, recordSize, totalRecords);

            if (posicion != -1)
            {
                using(FileStream fs = new(archivoBinario, FileMode.Open))
                {
                    fs.Seek(posicion + sizeof(int), SeekOrigin.Begin);

                    using (BinaryWriter writer = new(fs))
                    {
                        UpdateName(fs, writer, "first name");
                        UpdateName(fs, writer, "last name");
                        UpdateSalary(fs, writer, "salary");
                        UpdateGender(fs, writer, "gender");
                        UpdateIsManager(fs, writer);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to find record. Please press any key to navigate to the main screen");
                Console.ReadKey();
            }
        }
        private static void UpdateName(FileStream fileStream, BinaryWriter writer, string fieldLabel)
        {
            Console.WriteLine($"Please enter a value for {fieldLabel}");

            string name = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(name))
            {
                fileStream.Seek(Empleado.NameSize + 1, SeekOrigin.Current);
            }
            else
            {
                writer.Write(name.PadRight(Empleado.NameSize));
            }
        }
        private static void UpdateSalary(FileStream fileStream, BinaryWriter writer, string fieldLabel)
        {
            Console.WriteLine($"Please enter a value for the employee's {fieldLabel}");

            string salaryInput = Console.ReadLine();

            if (String.IsNullOrEmpty(salaryInput))
            {
                fileStream.Seek(sizeof(decimal), SeekOrigin.Current);
            }
            else
            {
                decimal salary = Decimal.Parse(salaryInput, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

                writer.Write(salary);
            }
        }

        private static void UpdateGender(FileStream fileStream, BinaryWriter writer, string fieldLabel)
        {
            Console.WriteLine($"Please enter a value for the employee's {fieldLabel} ('m'/'f')");

            string genderInput = Console.ReadLine();

            if (String.IsNullOrEmpty(genderInput))
            {
                fileStream.Seek(sizeof(char) - 1, SeekOrigin.Current);
            }
            else
            {
                char gender = Convert.ToChar(genderInput);
                writer.Write(gender);
            }

        }
        private static void UpdateIsManager(FileStream fileStream, BinaryWriter writer)
        {
            Console.WriteLine("The employee is a manager (true/false)");

            string isManagerInput = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(isManagerInput))
            {
                bool isManager = Convert.ToBoolean(isManagerInput);
                writer.Write(isManager);
            }

        }

        private static int FindRecordById(string archivoBinario, int id, int recordSize, int totalRecords)
        {
            int posicionRecord = -1;
            int leerId = -1;

            using(FileStream fs  = new FileStream(archivoBinario, FileMode.Open))
            {
                using (BinaryReader reader = new(fs))
                {
                    for (int i = 0; i < totalRecords; i++)
                    {
                        posicionRecord = GetRecordPosition(recordSize, i);

                        fs.Seek(posicionRecord, SeekOrigin.Begin);

                        leerId = reader.ReadInt32();

                        if(leerId == id)
                        {
                            return posicionRecord;
                        }
                        else
                        {
                            posicionRecord = -1;
                        }
                    }
                }
            }
            return posicionRecord;
        }
        private static int GetRecordPosition(int recSize, int position)
        {
            return recSize * position;
        }

        private static void ShowMainScreen(string archivoBinario, int recSize)
        {
            Console.Clear();
            DisplayHeadings();

            int totalRecords = GetNumberOfRecords(GetFileSize(archivoBinario), recSize);

            DisplayAllRecordsOnScreen(archivoBinario, totalRecords);

        }
        private static int GetFileSize(string binaryFile)
        {
            FileInfo f = new FileInfo(binaryFile);

            return Convert.ToInt32(f.Length);
        }
        private static int GetNumberOfRecords(int fileLength, int recSize)
        {
            return fileLength / recSize;
        }

        private static void DisplayAllRecordsOnScreen(string archivoBinario, int totalRecords)
        {
            using (BinaryReader reader = new(new FileStream(archivoBinario, FileMode.Open)))
            {
                for (int i = 0; i < totalRecords; i++)
                {
                    Console.WriteLine($"{reader.ReadInt32().ToString().PadRight(7)} {reader.ReadString().PadRight(Empleado.NameSize)} {reader.ReadString().PadRight(Empleado.NameSize)} {reader.ReadDecimal().ToString().PadRight(8)} {reader.ReadChar().ToString().PadRight(7)} {reader.ReadBoolean().ToString().PadRight(8)}");
                }
            }
        }

        private static void DisplayHeadings()
        {
            string mainHeading = GetMainHeading();

            Console.WriteLine(mainHeading);
            Console.WriteLine(GetUnderLine(mainHeading));
            Console.WriteLine();

            string fieldHeadings = GetFieldHeadings();
            Console.WriteLine(fieldHeadings);
            Console.WriteLine(GetUnderLine(fieldHeadings));
            Console.WriteLine();

        }

        private static string GetMainHeading()
        {
            return "Employee Records binary Application";
        }

        private static string GetFieldHeadings()
        {
            return $"{"Id".PadRight(7)} {"First Name".PadRight(Empleado.NameSize)} {"Last Name".PadRight(Empleado.NameSize)} {"Salary".PadRight(8)} {"Gender".PadRight(7)} {"Manager".PadRight(8)}";

        }

        private static string GetUnderLine(string heading)
        {
            return new string('-', heading.Length);
        }
    }
}
