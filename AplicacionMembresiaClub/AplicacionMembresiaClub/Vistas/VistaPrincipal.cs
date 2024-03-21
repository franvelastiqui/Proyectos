using AplicacionMembresiaClub.Campos_Validadores;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Vistas
{
    public class VistaPrincipal : IVista
    {
        IVista registro;
        IVista login;

        public VistaPrincipal(IVista registro, IVista login)
        {
            this.registro = registro;
            this.login = login;
        }

        public ICampoValidador CampoValidador => null;

        public void CorrerVista()
        {
            OutputTextoComun.EscribirHeadingPrincipal();

            Console.WriteLine("Por favor, presione 'i' para ingresar o si no esta registrado, presione 'r'");

            ConsoleKey key = Console.ReadKey().Key;
            
            if(key == ConsoleKey.I)
            {
                login.CorrerVista();
            }
            else if(key == ConsoleKey.R)
            {
                registro.CorrerVista();
                login.CorrerVista();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hasta luego");
                Console.ReadKey();
            }
        }
    }
}
