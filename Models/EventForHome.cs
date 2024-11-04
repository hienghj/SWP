namespace SWP_Project.Models
{
    public class EventForHome
    {
        public List<Event> HotEvents { get; set; } = new List<Event>();
        public List<Event> UpcommingEvents { get; set; } = new List<Event>();
    }
}
