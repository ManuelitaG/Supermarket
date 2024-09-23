using System.ComponentModel.DataAnnotations;

namespace taller.Supermarket.Data.Entities
{
    public class Administrador
    {
        [Key]
        public int Cedula { get; set; }

        [MaxLength(32, ErrorMessage = "El campo '{0}' debe tener máximo '{1}' caracter ")]
        [Required(ErrorMessage = "El campo '{0}' es requerido")]
        public string Name  { get; set; }

        [MaxLength(32, ErrorMessage = "El campo '{0}' debe tener máximo '{1}' caracter ")]
        [Required(ErrorMessage = "El campo '{0}' es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo '{0}' es requerido")]
        public int Age { get; set; }

        [Required(ErrorMessage = "El campo '{0}' es requerido")]
        public float salary { get; set; }


    }
}
