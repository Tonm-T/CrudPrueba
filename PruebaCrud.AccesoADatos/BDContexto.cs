using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.EntidadDeNegocio;

namespace PruebaCrud.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<RolEN> roles { get; set; }
        public DbSet<UsuariosEN> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3IPN15V\SQLEXPRESS;Initial Catalog=PracticaCrud;Integrated Security=True; trust Server Certificate=True");
        }
    }
}
