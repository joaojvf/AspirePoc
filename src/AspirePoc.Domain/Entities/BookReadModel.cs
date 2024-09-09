using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace AspirePoc.Core.Entities
{
    public class BookReadModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string SerializedObject { get; set; }

        [NotMapped]
        public Book DeserializedBook => JsonSerializer.Deserialize<Book>(SerializedObject);
    }
}
