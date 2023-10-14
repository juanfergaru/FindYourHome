using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FindYourHome.Shared.Entities
{
    public class Contract//Contrato
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de finalizacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Valor o monto del arriendo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[Range(1, int.MaxValue, ErrorMessage = "El valor debe ser un número entero válido")]
        public decimal RentPrice { get; set; }

        [Display(Name = "Estado del contrato")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string ContractStatus { get; set; } = null!;

        ////inmuebleID(FK → Inmueble.inmuebleID) 1 a 1
        [JsonIgnore]
        public Ownership? Ownership { get; set; }
        public int OwnershipId { get; set; }

        ////arrendatarioID(FK → Arrendatario.arrendatarioID) 1 a 1
        [JsonIgnore]
        public Tenant? Tenant { get; set; }
        public int TenantId { get; set; }

        //// 1 a N contratos a pagos
        [JsonIgnore]
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
       // [Display(Name = "Pagos")]
      //  public int PaymentsNumber => Payments == null ? 0 : Payments.Count;

    }
}
