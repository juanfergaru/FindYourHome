using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class Advisor//Asesor
    {
        public int Id { get; set; }


        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; } = null!;

        [Display(Name = "Foto")]
        public string Photo { get; set; }

        public ICollection<Ownership>? Ownerships { get; set; } = new List<Ownership>();

        [Display(Name = "Inmueble")]
        public int OwnershipsNumber => Ownerships == null ? 0 : Ownerships.Count;
    }
}
