using Newtonsoft.Json;

namespace FindYourHome.Shared.Entities
{
    public class Tenant//Arrendatario
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
