using AplicacionMembresiaClub.Campos_Validadores;
using AplicacionMembresiaClub.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Data
{
    public class RegistroUsuario : IRegistro
    {
        public bool EmailExiste(string direccionEmail)
        {
            bool existeEmail;

            using (MembresiaClubDbContext dbContext = new MembresiaClubDbContext())
            {
                existeEmail = dbContext.Usuarios.Any(u => u.DireccionEmail.ToLower().Trim() == direccionEmail.ToLower().Trim());
            }

            return existeEmail;
        }

        public bool Registro(string[] campos)
        {
            using(MembresiaClubDbContext dbContext = new MembresiaClubDbContext())
            {
                Usuario usuario = new Usuario
                {
                    DireccionEmail = campos[(int)ConstantesCampo.CampoRegistroUsuario.Email],
                    Nombre = campos[(int)ConstantesCampo.CampoRegistroUsuario.Nombre],
                    Apellido = campos[(int)ConstantesCampo.CampoRegistroUsuario.Apellido],
                    Contrasenia = campos[(int)ConstantesCampo.CampoRegistroUsuario.Contrasenia],
                    FechaNacimiento = DateTime.Parse(campos[(int)ConstantesCampo.CampoRegistroUsuario.FechaNacimiento]),
                    NumeroTelefono = campos[(int)ConstantesCampo.CampoRegistroUsuario.NumeroTelefono],
                    DireccionPrimeraLina = campos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionPrimeraLinea],
                    DireccionSegundaLina = campos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionSegundaLinea],
                    DireccionCiudad = campos[(int)ConstantesCampo.CampoRegistroUsuario.DireccionCiudad],
                    CodigoPostal = campos[(int)ConstantesCampo.CampoRegistroUsuario.CodigoPostal],
                };

                dbContext.Usuarios.Add(usuario);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
