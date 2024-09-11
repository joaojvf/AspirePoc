using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspirePoc.Core.Interfaces;
using AspirePoc.Core.Entities.Base;

namespace AspirePoc.Core.Entities
{
    public class Book : Entity, IAggregateRoot
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
