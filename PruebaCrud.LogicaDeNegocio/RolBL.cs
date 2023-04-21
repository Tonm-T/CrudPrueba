using PruebaCrud.AccesoADatos;
using PruebaCrud.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCrud.LogicaDeNegocio
{
    public class RolBL
    {
        public async Task<int> CrearAsync (RolEN Prol)
        {
            return await RolDAL.CrearAsync(Prol);
        }
        public async Task<int> ModificarAsync (RolEN Prol)
        {
            return await RolDAL.ModificarAsync(Prol);
        }
        public async Task<int> EliminarAsync (RolEN prol)
        {
            return await RolDAL.EliminarAsync(prol);
        }
        public async Task<RolEN> ObtenerPorIdAsync (RolEN prol)
        {
            return await RolDAL.ObtenerPorIdAsync();
        }
    }
}
