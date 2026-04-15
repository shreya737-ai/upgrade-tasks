
using Microsoft.AspNetCore.Mvc;
using week9_task2.Service;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET /api/contacts
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllContacts());
        }

        // GET /api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetContactById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}