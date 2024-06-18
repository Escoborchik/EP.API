using System.ComponentModel.DataAnnotations;

namespace EP.DataAccess.Entities
{
    public class HeadEntity
    {
        [Key]
        public Guid Uuid { get; set; }
        public string FullName { get; set; }
        
    }
}
