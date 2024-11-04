using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        // Danh sách tài khoản mẫu
        var accounts = new List<Account>
        {
            new Account { AccountId = 1, Username = "user1", Email = "user1@example.com", IsActive = true },
            new Account { AccountId = 2, Username = "user2", Email = "user2@example.com", IsActive = false }
        };
        return View(accounts);
    }
}
