using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public List<Book> Books { get; set; } = new();
    }
}
