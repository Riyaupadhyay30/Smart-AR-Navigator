using Microsoft.AspNetCore.Mvc;

namespace SmartARNavigator.Controllers
{
    public class NavigationController : Controller
    {
        // 1️⃣ Destination Page
        public IActionResult Select()
        {
            return View();
        }

        // 2️⃣ Location Page ✅ FIXED
        public IActionResult Location(string destination, string mode)
        {
            ViewBag.Destination = destination;
            ViewBag.Mode = mode; // 🔥 IMPORTANT LINE
            return View();
        }

        // 3️⃣ Map Page (Normal Navigation)
        public IActionResult Map(string location, string destination)
        {
            ViewBag.Location = location;
            ViewBag.Destination = destination;
            return View();
        }

        // 4️⃣ AR Navigation Page
        public IActionResult AR(string location, string destination)
        {
            ViewBag.Location = location;
            ViewBag.Destination = destination;
            return View();
        }
    }
}