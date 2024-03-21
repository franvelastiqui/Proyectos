using AplicacionMembresiaClub.Campos_Validadores;
using AplicacionMembresiaClub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AplicacionMembresiaClub.Vistas
{
    public class VistaRegistroUsuario : IVista
    {
        ICampoValidador campoValidador;
        IRegistro registro;

        public ICampoValidador CampoValidador { get => campoValidador; }

        public VistaRegistroUsuario(IRegistro registro, ICampoValidador campoValidador)
        {
            this.registro = registro;
            this.campoValidador = campoValidador;
        }

        public void CorrerVista()
        {
            OutputTextoComun.EscribirHeadingPrincipal();
            OutputTextoComun.EscribirHeadingRegistro();

            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.Email] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.Email, "Por favor ingrese su dirección de email: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.Nombre] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.Nombre, "Por favor ingrese su nombre: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.Apellido] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.Apellido, "Por favor ingrese su apellido: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.Contrasenia] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.Contrasenia, $"Por favor ingrese su contraseña{Environment.NewLine}(Su contraseña debe contener al menos 1 letra minúscula,{Environment.NewLine}1 letra mayúscula, 1 dígito, 1 caracter especial{Environment.NewLine} y el tamaño debe ser entre 6 y 10 caracteres): ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.ComparacionContrasenia] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.ComparacionContrasenia, "Por favor reingrese su contraseña: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.FechaNacimiento] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.FechaNacimiento, "Por favor ingrese su fecha de nacimiento: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.NumeroTelefono] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.NumeroTelefono, "Por favor ingrese su número de teléfono: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionPrimeraLinea] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.DireccionPrimeraLinea, "Por favor ingrese el nombre de su calle (sin altura): ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionSegundaLinea] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.DireccionSegundaLinea, "Por favor ingrese su altura, piso y departamento o manzana (si corresponde): ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionCiudad] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.DireccionCiudad, "Por favor ingrese su ciudad: ");
            campoValidador.ArrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.CodigoPostal] = GetInputUsuario(ConstantesCampo.CampoRegistroUsuario.CodigoPostal, "Por favor ingrese su código postal: ");

            RegistrarUsuario();
        }

        public void RegistrarUsuario()
        {
            registro.Registro(campoValidador.ArrayCampos);

            OutputFormatoComun.CambiarColorFuente(TemaFuente.Exito);
            Console.WriteLine("Se ha registrado correctamente. Preisone cualquier tecla para ingresar");
            OutputFormatoComun.CambiarColorFuente(TemaFuente.Default);
            Console.ReadKey();
        }

        public string GetInputUsuario(ConstantesCampo.CampoRegistroUsuario campo, string texto)
        {
            string valorCampo = "";

            do
            {
                Console.Write(texto);
                valorCampo = Console.ReadLine();

            } while (!ValidarCampo(campo, valorCampo));

            return valorCampo;
        }

        private bool ValidarCampo(ConstantesCampo.CampoRegistroUsuario campo, string valorCampo)
        {
            if (!campoValidador.ValidadorDelegado((int)campo, valorCampo, campoValidador.ArrayCampos, out string mensajeInvalido))
            {
                OutputFormatoComun.CambiarColorFuente(TemaFuente.Peligro);

                Console.WriteLine(mensajeInvalido);

                OutputFormatoComun.CambiarColorFuente(TemaFuente.Default);

                return false;
            }

            return true;
        }
    }
}
