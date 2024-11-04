using SWP_Project.Models;
using System.Collections.Generic;

namespace SWP_Project.Repositories
{
    public interface IEventRepository
    {
        // Lấy sự kiện theo ID
        Event GetEventById(int id);

        // Lấy tất cả các sự kiện
        IEnumerable<Event> GetAllEvents();

        // Lấy danh sách sự kiện nổi bật
        IEnumerable<Event> GetHotEvents();

        // Lấy danh sách sự kiện sắp tới
        IEnumerable<Event> GetUpcomingEvents();
    }
}
