using AplicacionMembresiaClub.Campos_Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Vistas
{
    public interface IVista
    {
        void CorrerVista();
        ICampoValidador CampoValidador { get; }

    }
}
