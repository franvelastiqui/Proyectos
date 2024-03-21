using AplicacionMembresiaClub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCamposAPI;

namespace AplicacionMembresiaClub.Campos_Validadores
{
    public class ValidadorRegistroUsuario : ICampoValidador
    {
        const int Tamanio_Min_Nombre = 2;
        const int Tamanio_Max_Nombre = 100;
        const int Tamanio_Min_Apellido = 2;
        const int Tamanio_Max_Apellido = 100;

        delegate bool ExisteEmailDelegado(string email);

        CampoValidadorDelegado ValidadorCamposDelegado;

        ValidacionRequeridaDelegado validacionRequeridaDelegado;
        ValidacionTamanioStringDelegado validacionTamanioStringDelegado;
        ValidacionFechaDelegado validacionFechaDelegado;
        ValidacionPatronDelegado validacionPatronDelegado;
        ValidacionComparacionCamposDelegado validacionComparacionCamposDelegado;

        ExisteEmailDelegado existeEmail;

        //Almacenar un array de valores de campo válidos ingresados por el usuario
        string[] arrayCampos;
        IRegistro registro;

        public string[] ArrayCampos
        {
            get
            {
                if (arrayCampos == null)
                {
                    arrayCampos = new string[Enum.GetValues(typeof(ConstantesCampo.CampoRegistroUsuario)).Length];
                }
                return arrayCampos;
            }
        }

        public CampoValidadorDelegado ValidadorDelegado => ValidadorCamposDelegado;

        public ValidadorRegistroUsuario(IRegistro registro)
        {
            this.registro = registro;
        }

        public void InicializarDelegadosValidadores()
        {
            ValidadorCamposDelegado = new CampoValidadorDelegado(ValidarCampo);
            existeEmail = new(registro.EmailExiste);

            validacionRequeridaDelegado = FuncionesValidadorasCamposComunes.ValidacionCampoRequeridoDelegado;
            validacionTamanioStringDelegado = FuncionesValidadorasCamposComunes.ValidacionTamanioStringCampoDelegado;
            validacionFechaDelegado = FuncionesValidadorasCamposComunes.ValidacionCampoFechaDelegado;
            validacionPatronDelegado = FuncionesValidadorasCamposComunes.ValidacionPatronDelegado;
            validacionComparacionCamposDelegado = FuncionesValidadorasCamposComunes.ValidacionComparacionCamposDelegado;
        }

        private bool ValidarCampo(int indiceCampo, string valorCampo, string[] arrayCampos, out string mensajeInvalido)
        {
            mensajeInvalido = "";

            ConstantesCampo.CampoRegistroUsuario campoRegistroUsuario = (ConstantesCampo.CampoRegistroUsuario)indiceCampo;

            switch(campoRegistroUsuario)
            {
                case ConstantesCampo.CampoRegistroUsuario.Email:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionPatronDelegado(valorCampo, PatronesValidacionExpresioesnRegularesComunes.Direccion_Email_Patron_RegEx)) ? $"Debe ingresar una dirección de email válida{Environment.NewLine}" : mensajeInvalido;
                    mensajeInvalido = (mensajeInvalido == "" && existeEmail(valorCampo)) ? $"Este email ya existe. PPor favor intente de nuevo{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.Nombre:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionTamanioStringDelegado(valorCampo, Tamanio_Min_Nombre, Tamanio_Max_Nombre)) ? $"El tamaño para el campo {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)} debe ser entre {Tamanio_Min_Nombre} y {Tamanio_Max_Nombre}{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.Apellido:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionTamanioStringDelegado(valorCampo, Tamanio_Min_Apellido, Tamanio_Max_Apellido)) ? $"El tamaño para el campo {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)} debe ser entre {Tamanio_Min_Apellido} y {Tamanio_Max_Apellido}{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.Contrasenia:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionPatronDelegado(valorCampo, PatronesValidacionExpresioesnRegularesComunes.Contrasenia_Fuerte_Patron_RegEx)) ? $"La contraseña debe contener por lo menos 1 letra minúscula, una letra mayúscula, 1 caracter especial y el tamaño debe ser entre 6 y 10 caracteres{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.ComparacionContrasenia:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionComparacionCamposDelegado(valorCampo, arrayCampos[(int)ConstantesCampo.CampoRegistroUsuario.Contrasenia])) ? $"El valor no ingresado no coincide con su contraseña{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.FechaNacimiento:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionFechaDelegado(valorCampo, out DateTime fechaValida)) ? $"Debe ingresar una fecha válida{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.NumeroTelefono:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionPatronDelegado(valorCampo, PatronesValidacionExpresioesnRegularesComunes.Telefono_Argentina_Patron_RegEx)) ? $"Debe ingresar un número de teléfono válido{Environment.NewLine}" : mensajeInvalido;
                    break;
                case ConstantesCampo.CampoRegistroUsuario.DireccionPrimeraLinea:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    break;
                case ConstantesCampo.CampoRegistroUsuario.DireccionSegundaLinea:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    break;
                case ConstantesCampo.CampoRegistroUsuario.DireccionCiudad:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    break;
                case ConstantesCampo.CampoRegistroUsuario.CodigoPostal:
                    mensajeInvalido = (!validacionRequeridaDelegado(valorCampo)) ? $"Debe ingresar un valor para el campo: {Enum.GetName(typeof(ConstantesCampo.CampoRegistroUsuario), campoRegistroUsuario)}{Environment.NewLine}" : "";
                    mensajeInvalido = (mensajeInvalido == "" && !validacionPatronDelegado(valorCampo, PatronesValidacionExpresioesnRegularesComunes.Codigo_Postal_Argentina_Patron_RegEx)) ? $"Debe ingresar un código postal válido{Environment.NewLine}" : mensajeInvalido;
                    break;
                default:
                    throw new ArgumentException("Este campo no existe");
            }

            return (mensajeInvalido == "");
        }
    }
}
