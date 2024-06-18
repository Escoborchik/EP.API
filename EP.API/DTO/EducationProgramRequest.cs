using EP.Domain.Models;

namespace EP.API.DTO
{
    public class EducationProgramRequest
    {       
        public string Title { get; set; }
        public string Status { get; set; }
        public string Cypher { get; set; }
        public int Level { get; set; }
        public int Standard { get; set; }
        public Guid Institute { get; set; }
        public Guid Head { get; set; }
        public DateOnly AccreditationTime { get; set; }        
    }
}
