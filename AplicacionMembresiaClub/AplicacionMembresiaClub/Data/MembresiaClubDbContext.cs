using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AplicacionMembresiaClub.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicacionMembresiaClub.Data
{
    public class MembresiaClubDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=DESKTOP-FFTBHH9;Initial Catalog=MembresiaClub;Integrated Security=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
