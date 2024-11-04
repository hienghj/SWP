using SWP_Project.Models;
using System.Collections.Generic;
using System.Linq;
using SWP_Project.Data;

namespace SWP_Project.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DBContext _context;

        // Inject ApplicationDbContext vào EventRepository
        public EventRepository(DBContext context)
        {
            _context = context;
        }

        // Lấy sự kiện theo ID
        public Event GetEventById(int id)
        {
            return _context.Event.FirstOrDefault(e => e.Id == id);
        }

        // Lấy tất cả các sự kiện
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Event.ToList();
        }

        // Lấy sự kiện nổi bật
        public IEnumerable<Event> GetHotEvents()
        {
            // Use the null-coalescing operator to treat null as false
            return _context.Event.Where(e => e.IsHot ?? false).ToList();
        }

        // Lấy sự kiện sắp tới
        public IEnumerable<Event> GetUpcomingEvents()
        {
            return _context.Event.Where(e => e.ShowDate >= DateTime.Now).ToList();
        }
    }
}
