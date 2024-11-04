using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ComplaintController : Controller
{
    public IActionResult Index()
    {
        // Danh sách khiếu nại mẫu
        var complaints = new List<Complaint>
        {
            new Complaint { ComplaintId = 1, CustomerName = "Customer A", Description = "Issue with service", DateSubmitted = DateTime.Now, IsResolved = false },
            new Complaint { ComplaintId = 2, CustomerName = "Customer B", Description = "Billing issue", DateSubmitted = DateTime.Now.AddDays(-5), IsResolved = true }
        };
        return View(complaints);
    }
}
