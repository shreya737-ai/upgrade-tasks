using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _repo.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            await _repo.AddAsync(contact);
            return Created("", contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            if (id != contact.ContactId) return BadRequest();
            await _repo.UpdateAsync(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
