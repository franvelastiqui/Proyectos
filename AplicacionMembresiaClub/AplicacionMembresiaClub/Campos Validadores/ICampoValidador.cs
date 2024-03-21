using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Campos_Validadores
{
    /*Referencia metodos que valida campos de cualquier form. Esta definición de delegado se usará para crear
    un delegado que hace referencia a un método que valida campos presentados al usuario en nuestra clase
    de vista de registro de usuario*/
    public delegate bool CampoValidadorDelegado(int indiceCampo, string valorCampo, string[] arrayCampos, out string mensajeInvalido);
    public interface ICampoValidador
    {
        void InicializarDelegadosValidadores();
        string[] ArrayCampos { get; }
        CampoValidadorDelegado ValidadorDelegado { get; }
    }
}
