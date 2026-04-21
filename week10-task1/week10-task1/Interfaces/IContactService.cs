
using week10_task1.Models;

namespace ContactManagement.Interfaces;

public interface IContactService
{
    void AddContact(Contact contact);
    void UpdateContact(Contact contact);
    void DeleteContact(int id);
    List<Contact> GetAllContacts();
}