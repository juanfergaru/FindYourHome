using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class Contract//Contrato
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de inicio")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de finalizacion")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Valor o monto del arriendo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Debe ser un número decimal válido con hasta 2 decimales")]
        public decimal RentAmount { get; set; }

        [Display(Name = "Estado del contrato")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ContractStatus { get; set; } = null!;

        //inmuebleID(FK → Inmueble.inmuebleID) 1 a 1
        public Ownership Ownership { get; set; }
        public int OwnershipId { get; set; }

        //arrendatarioID(FK → Arrendatario.arrendatarioID) 1 a 1
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }

        // 1 a N contratos a pagos
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        [Display(Name = "Pagos")]
        public int PaymentsNumber => Payments == null ? 0 : Payments.Count;

    }
}
