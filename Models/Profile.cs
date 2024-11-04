namespace SWP_Project.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<HistoryTicket> HistoryTickets { get; set; } = new List<HistoryTicket>();
    }
}
