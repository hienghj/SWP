using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SWP_Project.Data;
using SWP_Project.Models;

namespace SWP_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DBContext _context;

        public ProfileController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            return View();
        }
    }
}