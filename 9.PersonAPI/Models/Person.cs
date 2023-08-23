using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Telephone { get; set; }
        [Required]
        public string? DoB {get; set;}
        
        public int YearsAlive {get {
            var today = DateTime.Today;

            var splitDoB = DoB!.Split("-");

            return today.Year - int.Parse(splitDoB[0]);

        }}

        public string? House {get; set;}
    }
}