namespace ToDoAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? tax { get; set; }
        public double? fee { get; set; }
    }
}