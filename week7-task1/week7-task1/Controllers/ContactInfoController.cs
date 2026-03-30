using Microsoft.AspNetCore.Mvc;
using week7_task1.Models;

namespace week7_task1.Controllers
{
    [Route("ContactInfo")]
    public class ContactInfoController : Controller
    {
        // Static list to maintain contact details in memory
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Amit",
                LastName = "Sharma",
                CompanyName = "ABC Infotech",
                EmailId = "amit.sharma@abc.com",
                MobileNo = 9876543210,
                Designation = "Manager"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Neha",
                LastName = "Verma",
                CompanyName = "XYZ Solutions",
                EmailId = "neha.verma@xyz.com",
                MobileNo = 9123456780,
                Designation = "Developer"
            }
        };

        // 1. Show all contacts
        [Route("ShowContacts")]
        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        // 2. Search contact by ID
        [Route("GetContactById/{id:int}")]
        public ActionResult GetContactById(int id)
        {
            ContactInfo contact = contacts.FirstOrDefault(c => c.ContactId == id);

            return View(contact);
        }

        // 3. GET: AddContact
        [HttpGet]
        [Route("AddContact")]
        public ActionResult AddContact()
        {
            return View();
        }

        // 4. POST: AddContact
        [HttpPost]
        [Route("AddContact")]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }
    }
}
