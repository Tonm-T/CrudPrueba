using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.EntidadDeNegocio;

namespace PruebaCrud.AccesoADatos
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(RolEN PRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(PRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(RolEN PRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var roles= await bdContexto.roles.FirstOrDefaultAsync(c => c.Id == PRol.Id);
                roles.Nombre = roles.Nombre;
                roles.Descripcion = roles.Descripcion;

                bdContexto.Update(PRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(RolEN PRol)
        {
            var resut = 0;
            using (var bdContexto = new BDContexto())
            {
                var roles = await bdContexto.roles.FirstOrDefaultAsync(c => c.Id == PRol.Id);
                bdContexto.roles.Remove(roles);
                resut = await bdContexto.SaveChangesAsync();
            }
            return resut;
        }
        public static async Task<RolEN> ObtenerPorIdAsync()
        {
            var roles = new RolEN();
            using (var bdContexto = new BDContexto())
            {
                roles = await bdContexto.roles.FirstOrDefaultAsync(c => c.Id == roles.Id);
            }
            return roles;
        }
    }
}
