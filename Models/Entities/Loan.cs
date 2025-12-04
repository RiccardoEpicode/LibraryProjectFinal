using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public string UserEmail { get; set; } = "";

        public DateTime LoanDate { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; }

        public bool Returned { get; set; } = false;
    }
}
