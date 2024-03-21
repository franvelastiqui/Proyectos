using AplicacionMembresiaClub.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Data
{
    public interface ILogin
    {
        Usuario Login(string direccionEmail, string contrasenia);
    }
}
