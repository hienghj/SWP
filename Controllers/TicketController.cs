using Microsoft.AspNetCore.Mvc;
using SWP_Project.Models;
using System.Collections.Generic;
using System.Linq;

public class TicketController : Controller
{
    private static List<Ticket> tickets = new List<Ticket>();

    public IActionResult Index(string userId)
    {
        var userTickets = tickets.Where(t => t.UserId == userId && !t.IsCancelled).ToList();
        return View(userTickets);
    }

    [HttpPost]
    public IActionResult TransferTicket(int id)
    {
        var ticket = tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            ticket.IsTransferred = true;
        }
        return RedirectToAction("Index", new { userId = ticket?.UserId });
    }

    [HttpPost]
    public IActionResult CancelTicket(int id)
    {
        var ticket = tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            ticket.IsCancelled = true;
        }
        return RedirectToAction("Index", new { userId = ticket?.UserId });
    }

    public IActionResult PurchaseTicket(string userId, int eventId, decimal price, int quantity)
    {
        var newTicket = new Ticket
        {
            Id = tickets.Count + 1,
            UserId = userId,
            EventId = eventId, // Sử dụng EventId
            Price = price,
            Quantity = quantity
        };
        tickets.Add(newTicket);
        return RedirectToAction("Index", new { userId });
    }
}