using System.ComponentModel.DataAnnotations;

namespace EP.DataAccess.Entities
{
    public class ModuleEntity
    {
        [Key]
        public Guid Uuid { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }          
        public List<EducationProgramEntity> EducationPrograms { get; set; }
    }
}
