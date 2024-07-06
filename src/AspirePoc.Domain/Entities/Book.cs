using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspirePoc.Core.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string Tittle { get; set; }
        public required string Description { get; set; }
        public required DateTime ReleaseDate { get; set; }
        public required string AuthorName { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
