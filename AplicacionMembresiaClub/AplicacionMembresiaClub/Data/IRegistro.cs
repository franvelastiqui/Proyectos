using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Data
{
    public interface IRegistro
    {
        //Contiene un array de strings con data de campos validos ingresados por el usuario
        //y esta data de campos será guardara en la tabla de usuarios de la BD
        bool Registro(string[] fields);

        //Definicion de método que sera referenciado por un delegado de validación que se
        //ejecutará para chequear que el email ingresado ya exista en la tabla de la BD
        bool EmailExiste(string emailAddress);
    }
}
