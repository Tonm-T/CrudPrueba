using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCrud.EntidadDeNegocio
{
    public class UsuariosEN
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50 , ErrorMessage = "El largo Maximo es de 50 caracteres")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Appelido es requerido")]
        [MaxLength(50, ErrorMessage = "El largo Maximo es de 50 caracteres")]

        public string Apellido { get; set;}

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(50, ErrorMessage = "El largo Maximo es de 50 caracteres")]

        public string Correo { get; set;}

        [Required(ErrorMessage = "El Password es requerido")]
        [MaxLength(50, ErrorMessage = "El largo Maximo es de 50 caracteres")]

        public string Password { get; set;}

        public string rol { get; set;}

        [NotMapped]
        public int top_aux { get; set; }
    }
}
