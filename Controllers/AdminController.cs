using Microsoft.AspNetCore.Mvc;

[Route("admin")]
public class AdminController : Controller
{
    // Báo cáo doanh thu cho từng sự kiện
    [HttpGet("report")]
    public IActionResult Report()
    {
        // Lấy dữ liệu từ service và gửi đến view
        var reports = new List<Report>(); // Replace with service data retrieval
        return View("Report", reports);
    }

    // Thống kê doanh thu cho từng sự kiện
    [HttpGet("statistics")]
    public IActionResult Statistics()
    {
        // Lấy dữ liệu thống kê từ service và gửi đến view
        var statistics = new List<Statistics>(); // Replace with service data retrieval
        return View("Statistics", statistics);
    }

    // Quản lý tài khoản khách hàng
    [HttpGet("user-management")]
    public IActionResult UserManagement()
    {
        // Lấy danh sách tài khoản từ service và gửi đến view
        var userAccounts = new List<UserAccount>(); // Replace with service data retrieval
        return View("UserManagement", userAccounts);
    }

    // Xử lý khiếu nại của khách hàng
    [HttpGet("complaints")]
    public IActionResult Complaints()
    {
        // Lấy danh sách khiếu nại từ service và gửi đến view
        var complaints = new List<Complaint>(); // Replace with service data retrieval
        return View("Complaints", complaints);
    }
}
