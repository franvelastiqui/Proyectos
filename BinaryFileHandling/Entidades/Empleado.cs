using System.Reflection.Metadata;

namespace Entidades
{
    public class Empleado
    {
        public const int NameSize = 20;
        private string nombre;
        private string apellido;

        public int Id { get; set; }
        public string Nombre
        {
            get
            {
                return (nombre.Length > 20) ? nombre.Substring(0, NameSize) : nombre.PadRight(NameSize);
            }
            set
            {
                nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return (apellido.Length > 20) ? apellido.Substring(0,NameSize) : apellido.PadRight(NameSize);
            }
            set
            {
                apellido = value;
            }
        }
        public decimal Salario { get; set; }
        public char Genero { get; set; }
        public bool esSupervisor { get; set; }

    }
}