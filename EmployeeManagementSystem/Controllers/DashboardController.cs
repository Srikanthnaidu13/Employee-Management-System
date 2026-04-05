using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 🔐 Check if user logged in
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 📊 Dashboard Data
            var totalEmployees = await _context.Employees.CountAsync();

            var recentEmployees = await _context.Employees
                .OrderByDescending(e => e.Id)
                .Take(5)
                .ToListAsync();

            ViewBag.TotalEmployees = totalEmployees;
            ViewBag.RecentEmployees = recentEmployees;

            return View();
        }
    }
}