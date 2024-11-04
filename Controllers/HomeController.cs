using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_Project.Data;
using SWP_Project.Models;
using System.Diagnostics;

namespace SWP_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Truy vấn sự kiện hot, bao gồm cả trường hợp IsHot có giá trị null
            List<Event> hotEvents = await _context.Event
    .Where(e => e.IsHot == true || e.IsHot == null)  // Handle null IsHot values
    .ToListAsync();


            // Truy vấn các sự kiện sắp tới
            List<Event> upcommingEvents = await _context.Event
                .Where(e => e.ShowDate > DateTime.Now)  // Lọc các sự kiện sắp tới
                .OrderBy(e => e.ShowDate)  // Sắp xếp theo ngày
                .ToListAsync();

            // Tạo đối tượng EventForHome để truyền dữ liệu vào View
            EventForHome eventForHome = new EventForHome
            {
                HotEvents = hotEvents,
                UpcommingEvents = upcommingEvents
            };

            // Trả về View với dữ liệu
            return View(eventForHome);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
