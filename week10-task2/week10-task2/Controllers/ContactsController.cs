using Microsoft.AspNetCore.Mvc;
using week10_task2.Models;
using week10_task2.Repository;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;

    public ContactsController(IContactRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repo.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _repo.GetById(id);
        if (contact == null) return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Contact contact)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _repo.Add(contact);
        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Contact contact)
    {
        if (id != contact.Id) return BadRequest();

        _repo.Update(contact);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }
}