using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace FindYourHome.Shared.Entities
{
    public class Payment//Pagos
    {

        public int Id { get; set; }

        [Display(Name = "Fecha del pago")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DatePayment { get; set; }

        [Display(Name = "Valor o monto del pago")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Debe ser un número decimal válido con hasta 2 decimales")]
        public decimal PaymentAmount { get; set; }

        [Display(Name = "Medio de pago")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PaymentMethod { get; set; } = null!;

        [Display(Name = "Estado del pago")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PaymentStatus { get; set; } = null!;

        //contratoID(FK → Contrato.contratoID) 1 a N              
        public Contract Contract { get; set; }
        public int ContractId { get; set; }

    }
}
