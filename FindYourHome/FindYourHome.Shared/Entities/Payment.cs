using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FindYourHome.Shared.Entities
{
    public class Payment//Pagos
    {

        public int Id { get; set; }

        [Display(Name = "Fecha del pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DatePayment { get; set; }

        [Display(Name = "Valor o monto del pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[Range(1, int.MaxValue, ErrorMessage = "El valor debe ser un número entero válido")]
        public decimal PaymentPrice { get; set; }

        [Display(Name = "Medio de pago")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string PaymentMethod { get; set; } = null!;

        [Display(Name = "Estado del pago")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string PaymentStatus { get; set; } = null!;

        //contratoID(FK → Contrato.contratoID) 1 a N
        [JsonIgnore]
        public Contract Contract { get; set; }
        public int ContractId { get; set; }

    }
}
