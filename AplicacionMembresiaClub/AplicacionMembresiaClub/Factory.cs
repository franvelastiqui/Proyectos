using AplicacionMembresiaClub.Campos_Validadores;
using AplicacionMembresiaClub.Data;
using AplicacionMembresiaClub.Vistas;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub
{
    public class Factory
    {
        public static IVista GetObjetoVistaPrincipal()
        {
            ILogin login = new LoginUsuario();
            IRegistro registro = new RegistroUsuario();

            ICampoValidador campoValidador = new ValidadorRegistroUsuario(registro);
            campoValidador.InicializarDelegadosValidadores();

            IVista vistaRegistro = new VistaRegistroUsuario(registro, campoValidador);
            IVista vistaLogin = new VistaLoginUsuario(login);
            IVista vistaPrincipal = new VistaPrincipal(vistaRegistro, vistaLogin);

            return vistaPrincipal;
        }
    }
}
