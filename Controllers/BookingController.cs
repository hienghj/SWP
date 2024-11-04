using Microsoft.AspNetCore.Mvc;
using SWP_Project.Models;
using SWP_Project.Data;
using System.Threading.Tasks;
using SWP_Project.Areas.Identity.Data;


namespace SWP_Project.Controllers
{
    public class BookingController : Controller
    {
        private readonly DBContext _context; 

        public BookingController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Booking(int eventId, int seatNumber)
        {
            var eventDetail = _context.Event.Find(eventId);
            if (eventDetail == null)
            {
                return NotFound();
            }

            var model = new BookingViewModel
            {
                EventId = eventId,
                EventTitle = eventDetail.Title,
                SeatNumber = seatNumber,
                TotalPrice = eventDetail.Price ?? 0
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> CompleteBooking([FromBody] BookingViewModel payment)
        {
            if (ModelState.IsValid)
            {
                bool paymentSuccess = ProcessPayment(payment);

                if (paymentSuccess)
                {
                    var ticket = new Ticket
                    {
                        EventId = payment.EventId,
                        SeatNumber = payment.SeatNumber,
                        PaymentMethod = payment.PaymentMethod,
                        Price = payment.TotalPrice
                    };

                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }
            }

            return Json(new { success = false, message = "Payment failed or invalid data" });
        }

        private bool ProcessPayment(BookingViewModel payment)
        {
            return true;
        }
    }
}
