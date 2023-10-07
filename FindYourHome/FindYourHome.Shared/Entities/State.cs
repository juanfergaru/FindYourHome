using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FindYourHome.Shared.Entities
{
    public class State
        {
            public int Id { get; set; }

            [Display(Name = "Departamento/Estado")]
            [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Name { get; set; }
            [JsonIgnore]

            public int CountryId { get; set; }
            [JsonIgnore]

            public Country Country { get; set; }
            [JsonIgnore]

            public ICollection<City> Cities { get; set; }

            [Display(Name = "Ciudades")]
            public int CitiesNumber => Cities == null ? 0 : Cities.Count;

        }

    }
