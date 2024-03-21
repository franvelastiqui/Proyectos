using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMembresiaClub.Modelos
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DireccionEmail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroTelefono { get; set; }
        public string DireccionPrimeraLina { get; set; }
        public string DireccionSegundaLina { get; set; }
        public string DireccionCiudad { get; set; }
        public string CodigoPostal { get; set; }

    }
}
