using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub
{
    public enum TemaFuente
    {
        Default,
        Peligro,
        Exito
    }

    public class OutputFormatoComun
    {
        public static void CambiarColorFuente(TemaFuente fontTheme)
        {
            if (fontTheme == TemaFuente.Peligro)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fontTheme == TemaFuente.Exito)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
        }

    }
}
