using week7_task3.Models;
using ContactManagementApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace week7_task3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Show all contacts
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // Search contact by ID
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // GET: AddContact form
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        // POST: AddContact submit
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}