using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Dtos
{
    public abstract class PersonBaseDto // abstract to do not user directly
    {
        [Required]
        public string? FirstName {get; set; }

        [Required]
        public string? LastName {get; set; }

        [Required]
        public string? Telephone { get; set; }

        [Required]
        public string? DoB {get; set;}
    }
}