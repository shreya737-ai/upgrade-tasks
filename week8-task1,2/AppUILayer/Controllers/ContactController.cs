using DAL.Models;
using DAL.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUILayer.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactRepository.GetContactById(id);
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
                _contactRepository.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        [HttpGet("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
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
                _contactRepository.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        [HttpGet("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost("DeleteConfirmed/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactRepository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_contactRepository.GetAllCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_contactRepository.GetAllDepartments(), "DepartmentId", "DepartmentName");
        }
    }
}