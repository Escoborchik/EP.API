using System.ComponentModel.DataAnnotations;

namespace EP.DataAccess.Entities
{
    public class InstituteEntity
    {
        [Key]
        public Guid Uuid { get; set; }
        public string Title { get; set; }
    }
}
