using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStructure.ViewModels;
using CoreStructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreStructure.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirst("UserId").Value;

            var users = await _userManager.Users.Select(s => new UserViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email
                //}).ToListAsync();
                }).Where(s => s.Id != userId).ToListAsync();
            //}).Where(s => s.Id != "fdc93b86-82f0-4801-a69b-b90285c29693").ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.User.FindFirst("UserId").Value;

            var users = await _userManager.Users.Select(s => new UserViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email
                //}).ToListAsync();
            }).Where(s => s.Id == userId).FirstOrDefaultAsync();
            return View(users);
        }
    }
}