

namespace EP.API.DTO
{
    public class EducationProgramResponse
    {
        public Guid Uuid { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Cypher { get; set; }
        public int Level { get; set; }
        public int Standard { get; set; }
        public InstituteResponse Institute { get; set; }
        public HeadResponse Head { get; set; }
        public DateOnly AccreditationTime { get; set; }        
    }
}
