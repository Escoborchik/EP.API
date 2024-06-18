using EP.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EP.DataAccess.Entities
{
    public class EducationProgramEntity
    {
        [Key]
        public Guid Uuid { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Cypher { get; set; }
        public LevelEducation Level { get; set; }
        public StandardEducation Standard { get; set; }
        public InstituteEntity Institute { get; set; }
        public HeadEntity Head { get; set; }
        public DateOnly AccreditationTime { get; set; }
        public List<ModuleEntity> Modules { get; set; } = new();


    }
}
