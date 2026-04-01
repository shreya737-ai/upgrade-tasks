using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        // Temporary static variables to hold submitted data
        // (Since Model/Database/TempData are not allowed)
        private static string studentName;
        private static int studentAge;
        private static string studentCourse;

        // GET: student/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: student/register
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            // Store submitted data in static variables
            studentName = name;
            studentAge = age;
            studentCourse = course;

            // Redirect to display action
            return RedirectToAction("Display");
        }

        // GET: student/display
        [HttpGet("display")]
        public IActionResult Display()
        {
            // Pass data using ViewBag
            ViewBag.StudentName = studentName;
            ViewBag.StudentAge = studentAge;
            ViewBag.StudentCourse = studentCourse;

            return View();
        }
    }
}