namespace EP.Domain.Models
{
    public class Head
    {
        private Head(Guid uuid, string fullName)
        {
            Uuid = uuid;
            FullName = fullName;
        }

        public Guid Uuid { get; set; }
        public string FullName { get; set; }
        
        public static Head Create(Guid uuid, string fullName)
        {
            return new Head(uuid, fullName);
        }
    }
}
