using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        // Relazione con Author
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        // Relazione con Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string? CoverImg { get; set; }
    }
}
