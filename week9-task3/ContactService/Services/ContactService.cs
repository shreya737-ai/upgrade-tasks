using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactServiceImpl : IContactService
    {
        private readonly IContactRepository _repo;
        public ContactServiceImpl(IContactRepository repo) { _repo = repo; }

        public Task<Contact> Add(Contact contact) => _repo.Add(contact);
        public Task Delete(int id) => _repo.Delete(id);
        public Task<IEnumerable<Contact>> GetAll() => _repo.GetAll();
        public Task<Contact?> GetById(int id) => _repo.GetById(id);
        public Task Update(Contact contact) => _repo.Update(contact);
    }
}