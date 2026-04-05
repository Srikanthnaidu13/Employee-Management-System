using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class SettingsController : Controller
    {
        // =========================
        // MAIN SETTINGS PAGE
        // =========================
        public IActionResult Index()
        {
            return View();
        }

        // =========================
        // PROFILE SETTINGS
        // =========================
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string username, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Username and Email are required.";
                return View("Profile");
            }

            // TODO: Save to database

            ViewBag.Message = "Profile updated successfully.";
            return View("Profile");
        }

        // =========================
        // SYSTEM PREFERENCES
        // =========================
        [HttpGet]
        public IActionResult Preferences()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SavePreferences(string theme, string language, bool notifications)
        {
            // TODO: Save preferences to DB or session

            ViewBag.Message = "Preferences saved successfully.";
            return View("Preferences");
        }

        // =========================
        // SECURITY SETTINGS
        // =========================
        [HttpGet]
        public IActionResult Security()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPass, string newPass)
        {
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                ViewBag.Error = "Both fields are required.";
                return View("Security");
            }

            if (newPass.Length < 6)
            {
                ViewBag.Error = "New password must be at least 6 characters.";
                return View("Security");
            }

            // TODO: Validate old password + update in DB

            ViewBag.Message = "Password changed successfully.";
            return View("Security");
        }

        // =========================
        // DATA MANAGEMENT
        // =========================
        [HttpGet]
        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Export()
        {
            // TODO: Replace with actual Excel export
            return Content("Employee data exported successfully.");
        }

        public IActionResult Backup()
        {
            // TODO: Replace with real DB backup logic
            return Content("Database backup created successfully.");
        }
        public IActionResult Department()
        {
            return View();
        }
    }
}
