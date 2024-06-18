

namespace EP.Domain.Models
{
    public class EducationProgram
    {
        private EducationProgram(Guid uuid, string title, string status, string cypher, LevelEducation level, StandardEducation standard, Institute institute, Head head, DateOnly accreditationTime, List<Module> modules) 
            : this(uuid, title, status, cypher, level, standard, institute, head, accreditationTime)
        {
            Modules = modules;
        }

        private EducationProgram(Guid uuid, string title, string status, string cypher, LevelEducation level, StandardEducation standard,
            Institute institute, Head head, DateOnly accreditationTime)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(cypher))
            {
                throw new Exception("Значения не должны быть пустыми!");
            }

            Uuid = uuid;
            Title = title;
            Status = status;
            Cypher = cypher;
            Level = level;
            Standard = standard;
            Institute = institute;
            Head = head;
            AccreditationTime = accreditationTime;          
        }

        public Guid Uuid { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Cypher { get; set; }
        public LevelEducation Level { get; set; }
        public StandardEducation Standard { get; set; }
        public Institute Institute { get; set; }
        public Head Head { get; set; }
        public DateOnly AccreditationTime { get; set; }
        public List<Module> Modules { get; set; } = new();


        public static (EducationProgram,string) Create(Guid uuid, string title, string status, string cypher, LevelEducation level, StandardEducation standard,
            Institute institute, Head head, DateOnly accreditationTime)
        {
            var error = string.Empty;
            var result = default(EducationProgram);

            try
            {
                result = new EducationProgram(uuid, title, status, cypher, level, standard, institute, head, accreditationTime);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return (result,error);
        }

        public static (EducationProgram,string) Create(Guid uuid, string title, string status, string cypher, LevelEducation level, StandardEducation standard,
            Institute institute, Head head, DateOnly accreditationTime, List<Module> modules)
        {
            var error = string.Empty;
            var result = default(EducationProgram);

            try
            {
                result = new EducationProgram(uuid, title, status, cypher, level, standard, institute, head, accreditationTime, modules);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return (result, error);                        
        }
    }
}
