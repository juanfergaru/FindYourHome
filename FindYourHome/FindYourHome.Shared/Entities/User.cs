using FindYourHome.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class User : IdentityUser
    {
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

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }


        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";




        public ICollection<Owner>? Owners { get; set; } = new List<Owner>();

       [Display(Name = "Propietario")]
       public int OwnerNumber => Owners == null ? 0 : Owners.Count;



        public ICollection<Advisor>? Advisors { get; set; } = new List<Advisor>();

        [Display(Name = "Asesor")]
        public int AdvisorNumber => Advisors == null ? 0 : Advisors.Count;
    

 
        public ICollection<Tenant>? Tenants { get; set; } = new List<Tenant>();

       [Display(Name = "Arrendatario")]
       public int TenantsNumber => Tenants == null ? 0 : Tenants.Count;




        /*
[JsonIgnore]
[Display(Name = "Ciudad")]
[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
public int CityId { get; set; }

*/

        // public City City { get; set; }


    }
}
