using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]  //{0}
        [MaxLength(100, ErrorMessage = "Este campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public ICollection<State>? States { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
