using Microsoft.AspNetCore.Mvc;
using SWP_Project.Data;
using SWP_Project.Models;
using Microsoft.EntityFrameworkCore;
using SWP_Project.Repositories;

namespace SWP_Project.Controllers
{
    public class EventDetailController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventDetailController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult EventDetail(int id)
        {
            var eventDetail = _eventRepository.GetEventById(id);

            if (eventDetail == null)
            {
                return NotFound(); 
            }

            return View("~/Views/EventDetail/EventDetail.cshtml", eventDetail);
        }
    }
}
