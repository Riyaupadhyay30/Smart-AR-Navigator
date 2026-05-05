using Microsoft.AspNetCore.Mvc;

namespace SmartARNavigator.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // FORM PAGE
        public IActionResult Form(string destination)
        {
            ViewBag.Destination = destination;
            return View();
        }

        // FORM SUBMIT
        [HttpPost]
        public IActionResult Submit(string Name, string Phone, string Email, string VisitType, string Destination)
        {
            // 🔴 VALIDATION
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(VisitType))
            {
                ViewBag.Error = "Please fill all required details";
                ViewBag.Destination = Destination;
                return View("Form");
            }

            // 🔥 SAVE TO DATABASE
            var user = new User
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                VisitType = VisitType,
                Destination = Destination
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            // ✅ GO TO NAVIGATION TYPE PAGE
            return RedirectToAction("NavigationType", "User", new { destination = Destination });
        }

        // 🔥 MISSING ACTION (IMPORTANT)
        public IActionResult NavigationType(string destination)
        {
            ViewBag.Destination = destination;
            return View();
        }
    }
}