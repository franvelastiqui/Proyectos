using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorCamposAPI
{
    public class PatronesValidacionExpresioesnRegularesComunes
    {
        public const string Direccion_Email_Patron_RegEx = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public const string Telefono_Argentina_Patron_RegEx = @"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$";

        public const string Codigo_Postal_Argentina_Patron_RegEx = @"^\d{4}|([A-HJ-NP-Z]|[a-hj-np-z])\d{4}";

        public const string Contrasenia_Fuerte_Patron_RegEx = @"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
    }
}
