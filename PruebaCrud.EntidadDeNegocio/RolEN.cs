using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCrud.EntidadDeNegocio
{
    public class RolEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 Caracteres")]

        public string Nombre { get; set;}
        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 Caracteres")]

        public string Descripcion { get; set;}
        [NotMapped]
        public int top_aux { get; set; }

        public List<UsuariosEN> usuarios { get; set; }
    }
}
