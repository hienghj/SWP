namespace SWP_Project.Models
{
    public class BookingViewModel
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int SeatNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
    }
}
