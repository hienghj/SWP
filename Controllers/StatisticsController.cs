using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class StatisticsController : Controller
{
    public IActionResult Index()
    {
        // Dữ liệu thống kê mẫu
        var statistics = new List<Statistics>
        {
            new Statistics { EventId = 1, EventName = "Event A", Attendees = 100, TotalRevenue = 5000 },
            new Statistics { EventId = 2, EventName = "Event B", Attendees = 200, TotalRevenue = 7000 }
        };
        return View(statistics);
    }
}
