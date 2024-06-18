namespace EP.Domain.Models
{
    public class Institute
    {
        private Institute(Guid uuid, string title)
        {
            Uuid = uuid;
            Title = title;
        }

        public Guid Uuid { get; set; }
        public string Title { get; set; }

        public static Institute Create(Guid uuid, string title)
        {
            return new Institute(uuid, title);
        }
    }
}
