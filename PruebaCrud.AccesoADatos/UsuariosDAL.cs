using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.EntidadDeNegocio;
using PruebaCrud.AccesoADatos;

namespace PruebaCrud.AccesoADatos
{
    public class UsuariosDAL
    {
        public static async Task<int> CrearAsync(UsuariosEN Pusuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(Pusuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(UsuariosEN Pusuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.roles.FirstOrDefaultAsync(c => c.Id == Pusuario.Id);
                usuario.Nombre = usuario.Nombre;
                usuario.Descripcion = usuario.Descripcion;

                bdContexto.Update(Pusuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(UsuariosEN Pusuario)
        {
            var resut = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.roles.FirstOrDefaultAsync(c => c.Id == Pusuario.Id);
                bdContexto.roles.Remove(usuario);
                resut = await bdContexto.SaveChangesAsync();
            }
            return resut;
        }
        public static async Task<UsuariosEN> ObtenerPorIdAsync(UsuariosEN Pusuario)
        {
            var usuario = new UsuariosEN();
            using (var bDContexto = new BDContexto())
            {
                usuario = await bDContexto.Usuarios.FirstOrDefaultAsync(c => c.Id == Pusuario.Id);
            }
            return usuario;
        }
    }
}
