using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidadorCamposAPI
{
    public delegate bool ValidacionRequeridaDelegado(string campoAValidar);
    public delegate bool ValidacionTamanioStringDelegado(string campoAValidar, int min, int max);
    public delegate bool ValidacionFechaDelegado(string campoAValidar, out DateTime fechaValida);
    public delegate bool ValidacionPatronDelegado(string campoAValidar, string patron);
    public delegate bool ValidacionComparacionCamposDelegado(string campoAValidar, string campoAComparar);

    public class FuncionesValidadorasCamposComunes
    {
        private static ValidacionRequeridaDelegado validacionRequeridaDelegado;
        private static ValidacionTamanioStringDelegado validacionTamanioStringDelegado;
        private static ValidacionFechaDelegado validacionFechaDelegado;
        private static ValidacionPatronDelegado validacionPatronDelegado;
        private static ValidacionComparacionCamposDelegado validacionComparacionCamposDelegado;

        #region Propiedad read-only para exponer a cada delagado a su método

        /*Dentro de cada método, se crea un nuevo objeto del tipo de delegado apropiado y se pasa
        el nombre del método correspondiente al constructor del tipo de delegado.
        Nos aseguramos tambien que solo se pueda crear una instancia de estos objetos delegado*/

        public static ValidacionRequeridaDelegado ValidacionCampoRequeridoDelegado
        {
            get
            {
                if (validacionRequeridaDelegado == null)
                    validacionRequeridaDelegado = new ValidacionRequeridaDelegado(ValidacionCampoRequerida);

                return validacionRequeridaDelegado;
            }
        }

        public static ValidacionTamanioStringDelegado ValidacionTamanioStringCampoDelegado
        {
            get
            {
                if (validacionTamanioStringDelegado == null)
                    validacionTamanioStringDelegado = new ValidacionTamanioStringDelegado(ValidacionLargoCampoString);

                return validacionTamanioStringDelegado;
            }
        }

        public static ValidacionFechaDelegado ValidacionCampoFechaDelegado
        {
            get
            {
                if (validacionFechaDelegado == null)
                    validacionFechaDelegado = new ValidacionFechaDelegado(ValidacionCampoFecha);

                return validacionFechaDelegado;
            }
        }

        public static ValidacionPatronDelegado ValidacionPatronDelegado
        {
            get
            {
                if (validacionPatronDelegado == null)
                    validacionPatronDelegado = new ValidacionPatronDelegado(ValidacionPatron);

                return validacionPatronDelegado;
            }
        }

        public static ValidacionComparacionCamposDelegado ValidacionComparacionCamposDelegado
        {
            get
            {
                if (validacionComparacionCamposDelegado == null)
                    validacionComparacionCamposDelegado = new ValidacionComparacionCamposDelegado(ValidacionComparacionCampos);

                return validacionComparacionCamposDelegado;
            }
        }
        #endregion

        #region Implementaciones de métodos para los delegados 
        private static bool ValidacionCampoRequerida(string campoAValidar)
        {
            if (!string.IsNullOrEmpty(campoAValidar))
                return true;

            return false;

        }

        private static bool ValidacionLargoCampoString(string campoAValidar, int min, int max)
        {
            if (campoAValidar.Length >= min && campoAValidar.Length <= max)
                return true;

            return false;

        }

        private static bool ValidacionCampoFecha(string fecha, out DateTime fechaValida)
        {
            if (DateTime.TryParse(fecha, out fechaValida))
                return true;

            return false;

        }

        private static bool ValidacionPatron(string campoAValidar, string patronExpresionRegular)
        {
            Regex regex = new Regex(patronExpresionRegular);

            if (regex.IsMatch(campoAValidar))
                return true;

            return false;

        }

        private static bool ValidacionComparacionCampos(string campoUno, string campoDos)
        {
            if (campoUno.Equals(campoDos))
                return true;

            return false;
        }
        #endregion
    }
}
