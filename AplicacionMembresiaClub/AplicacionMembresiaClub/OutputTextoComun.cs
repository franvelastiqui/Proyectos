using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub
{
    public static class OutputTextoComun
    {
        private static string HeadingPrincipal
        {
            get
            {
                string heading = "Club de Ciclismo";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string HeadingRegistro
        {
            get
            {
                string heading = "Registro";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }
        private static string HeadingLogin
        {
            get
            {
                string heading = "Login";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        public static void EscribirHeadingPrincipal()
        {
            Console.Clear();
            Console.WriteLine(HeadingPrincipal);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void EscribirHeadingLogin()
        {
            Console.WriteLine(HeadingLogin);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void EscribirHeadingRegistro()
        {
            Console.WriteLine(HeadingRegistro);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
