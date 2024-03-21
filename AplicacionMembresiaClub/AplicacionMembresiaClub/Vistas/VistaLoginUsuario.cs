using AplicacionMembresiaClub.Campos_Validadores;
using AplicacionMembresiaClub.Data;
using AplicacionMembresiaClub.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Vistas
{
    public class VistaLoginUsuario : IVista
    {
        ICampoValidador campoValidador;
        ILogin login;

        public ICampoValidador CampoValidador => null;

        public VistaLoginUsuario(ILogin login)
        {
            this.login = login;
        }

        public void CorrerVista()
        {
            OutputTextoComun.EscribirHeadingPrincipal();
            OutputTextoComun.EscribirHeadingLogin();

            Console.WriteLine("Ingrese su dirección de email");
            string direccionEmail = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña");
            string contrasenia = Console.ReadLine();

            Usuario usuario = login.Login(direccionEmail, contrasenia);

            if(usuario is not null)
            {
                VistaBienvenidaUsuario vista = new(usuario);
                vista.CorrerVista();
            }
            else
            {
                Console.Clear();
                OutputFormatoComun.CambiarColorFuente(TemaFuente.Peligro);
                Console.WriteLine("Los credenciales que ingresó no se encuentran en nuestros registros");
                OutputFormatoComun.CambiarColorFuente(TemaFuente.Default);
                Console.ReadKey();
            }
        }
    }
}
