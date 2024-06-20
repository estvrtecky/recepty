using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recepty.Data;
using UserModel;

namespace Recepty.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before saving to the database
                user.Password = HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            // Hash the provided password for comparison
            string hashedPassword = HashPassword(user.Password);

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == hashedPassword);
            if (existingUser != null)
            {
                // Authentication successful, redirect to home page or dashboard
                return RedirectToAction("Index", "Recepts");
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(user);
        }

        // Helper method to hash the password using SHA256 algorithm
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
