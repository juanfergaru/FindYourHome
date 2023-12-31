﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace FindYourHome.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        public ICollection<User>? Users { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

       [JsonIgnore]
       public State? State { get; set; }
        public int StateId { get; set; }
    }
}
