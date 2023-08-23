using Microsoft.AspNetCore.Mvc;
using SchoolSystemWeb.Data;
using SchoolSystemWeb.Models;
using System.Diagnostics;

namespace SchoolSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Student student1 = new Student
            {
                Gender = Gender.Female,
                FirstName = "Alice",
                MiddleName = "Marie",
                LastName = "Johnson",
                DateOfBirth = new DateTime(2001, 5, 12),
                Email = "alice@example.com",
                Phone = "123-456-7890",
                PhoneNumber = "987-654-3210",
                SocialSecurityNumber = "123-45-6789",
                GPA = 3.8f
            };

            Student student2 = new Student
            {
                Gender = Gender.Male,
                FirstName = "Bob",
                MiddleName = "Allen",
                LastName = "Smith",
                DateOfBirth = new DateTime(2000, 9, 30),
                Email = "bob@example.com",
                Phone = "555-123-4567",
                PhoneNumber = "789-456-1230",
                SocialSecurityNumber = "987-65-4321",
                GPA = 3.2f
            };

            Student student3 = new Student
            {
                Gender = Gender.Female,
                FirstName = "Eva",
                MiddleName = "Rose",
                LastName = "Williams",
                DateOfBirth = new DateTime(2002, 2, 18),
                Email = "eva@example.com",
                Phone = "777-888-9999",
                PhoneNumber = "555-666-7777",
                SocialSecurityNumber = "234-56-7890",
                GPA = 4.0f
            };

            Student student4 = new Student
            {
                Gender = Gender.Male,
                FirstName = "Daniel",
                MiddleName = "James",
                LastName = "Brown",
                DateOfBirth = new DateTime(2001, 11, 5),
                Email = "daniel@example.com",
                Phone = "999-555-3333",
                PhoneNumber = "111-222-3333",
                SocialSecurityNumber = "567-89-0123",
                GPA = 3.5f
            };
        List<Student> stdlist = new List<Student> { student1, student2, student3, student4 };
            _context.AddRange(stdlist);
            _context.SaveChanges();
            var students = _context.Students.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}