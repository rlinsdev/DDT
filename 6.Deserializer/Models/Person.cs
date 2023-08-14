using System.Text.Json.Serialization;

namespace Deserializer.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        [JsonPropertyName("ChangeLatName")]
        public string? LastName { get; set;}
        public int Age { get; set; }

        [JsonIgnore]
        public bool IsAlive { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Address? Address {get; set;}
        public IList<Phone>? Phones{ get; set;}
    }
}