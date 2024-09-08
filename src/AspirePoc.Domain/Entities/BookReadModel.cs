using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
