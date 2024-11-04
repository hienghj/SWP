using SWP_Project.Models;
using System.Collections.Generic;

namespace SWP_Project.Data
{
    public static class TicketData
    {
        public static List<Ticket> GetSampleTickets()
        {
            return new List<Ticket>
            {
                new Ticket { Id = 1, UserId = "user1", EventId = 1, IsTransferred = false, IsCancelled = false }, // Thay đổi
                new Ticket { Id = 2, UserId = "user1", EventId = 2, IsTransferred = false, IsCancelled = false }  // Thay đổi
            };
        }
    }
}
