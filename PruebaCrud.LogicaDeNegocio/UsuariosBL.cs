using PruebaCrud.AccesoADatos;
using PruebaCrud.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCrud.LogicaDeNegocio
{
    public class UsuariosBL
    {
        public async Task<int> CrearAsync(UsuariosEN Pusuarios)
        {
            return await UsuariosDAL.CrearAsync(Pusuarios);
        }
        public async Task<int> ModificarAsync(UsuariosEN Pusuarios)
        {
            return await UsuariosDAL.ModificarAsync(Pusuarios);
        }
        public async Task<int> EliminarAsync(UsuariosEN Pusuarios)
        {
            return await UsuariosDAL.EliminarAsync(Pusuarios);
        }
        public async Task<UsuariosEN> ObtenerPorIdAsync(UsuariosEN Psusario)
        {
            return await UsuariosDAL.ObtenerPorIdAsync(Psusario);
        }

        public Task<int> CrearAsync(object pusuarios)
        {
            throw new NotImplementedException();
        }
    }
}
