using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class Ownership//inmueble
    {

        public int Id { get; set; }

        /*
        [ForeignKey("Ciudad")] // FK → Ciudad.ciudadID
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CityID { get; set; }
        public virtual City City { get; set; }
         */


        [Display(Name = "Dirección")]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }


        [Display(Name = "Código Postal")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PostalCode { get; set; }


        [Display(Name = "Número de Habitaciones")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int NumberOfRooms { get; set; }


        [Display(Name = "Número de Baños")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int NumberOfBathrooms { get; set; }


        [Display(Name = "Precio Mensual")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal MonthlyPrice { get; set; }


        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Status { get; set; }


        [JsonIgnore]
      //  [ForeignKey("Propietario")]
      //  [Display(Name = "Propietario")]
      //  [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int OwnerId { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

       
        [JsonIgnore]
       // [ForeignKey("Asesor")]
      //  [Display(Name = "Asesor")]
      //  [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int AdvisorId { get; set; }

        [JsonIgnore]
        public Advisor Advisor { get; set; }

    }
}