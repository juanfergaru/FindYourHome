using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindYourHome.Shared.Entities
{
    public class Advisor//Asesor
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public ICollection<Ownership>? Ownerships { get; set; } = new List<Ownership>();

        [Display(Name = "Inmueble")]
        public int OwnershipsNumber => Ownerships == null ? 0 : Ownerships.Count;
    }
}
