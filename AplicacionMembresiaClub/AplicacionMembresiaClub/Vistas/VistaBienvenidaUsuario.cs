using AplicacionMembresiaClub.Campos_Validadores;
using AplicacionMembresiaClub.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Vistas
{
    public class VistaBienvenidaUsuario : IVista
    {
        Usuario usuario;

        public VistaBienvenidaUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public ICampoValidador CampoValidador => null;

        public void CorrerVista()
        {
            Console.Clear();
            OutputTextoComun.EscribirHeadingPrincipal();

            OutputFormatoComun.CambiarColorFuente(TemaFuente.Exito);
            Console.WriteLine($"Hi {usuario.Nombre}!{Environment.NewLine}Bienvenido/a al Club Ciclista!");
            OutputFormatoComun.CambiarColorFuente(TemaFuente.Default);
            Console.ReadKey();
        }
    }
}
