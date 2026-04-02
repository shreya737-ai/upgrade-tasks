using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUILayer.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _repository.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpGet("AddContact")]
        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repository.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        [HttpGet("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return NotFound();

            LoadDropdowns();
            return View(contact);
        }

        [HttpPost("EditContact")]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        [HttpGet("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_repository.GetAllCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repository.GetAllDepartments(), "DepartmentId", "DepartmentName");
        }
    }
}