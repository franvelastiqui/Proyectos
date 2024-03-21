using AplicacionMembresiaClub.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Data
{
    public class LoginUsuario : ILogin
    {
        public Usuario Login(string direccionEmail, string contrasenia)
        {
            Usuario usuario;

            using (MembresiaClubDbContext dbContext = new MembresiaClubDbContext())
            {
                usuario = dbContext.Usuarios.FirstOrDefault(u => u.DireccionEmail.Trim().ToLower() == direccionEmail.Trim().ToLower() && u.Contrasenia.Equals(contrasenia));
            }
            return usuario;
        }
    }
}
