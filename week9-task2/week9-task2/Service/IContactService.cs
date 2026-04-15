using week9_task2.Models;

namespace week9_task2.Service
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
