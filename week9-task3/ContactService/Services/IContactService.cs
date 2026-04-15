using ContactService.Models;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<Contact> Add(Contact contact);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact?> GetById(int id);
        Task Update(Contact contact);
        Task Delete(int id);
    }
}