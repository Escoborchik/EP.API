namespace EP.Domain.Models
{
    public class Module
    {
        private Module(Guid uuid, string title, string type)
        {
            Uuid = uuid;
            Title = title;
            Type = type;
        }

        public Guid Uuid { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }     
        
        public static (Module,string) Create(Guid uuid, string title, string type)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(type))
            {
                error = "Имя и тип не должны быть пустыми!";
            }
            
            return (new Module(uuid, title, type),error);
        }
    }
}
