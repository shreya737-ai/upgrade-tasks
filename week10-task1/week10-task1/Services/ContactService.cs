using ContactManagement.Interfaces;

using week10_task1.Models;

namespace ContactManagement.Services;

public class ContactService : IContactService
{
    private readonly List<Contact> _contacts = new();

    public void AddContact(Contact contact)
    {
        ValidateContact(contact);

        if (_contacts.Any(c => c.Id == contact.Id))
        {
            throw new InvalidOperationException("Contact with same ID already exists.");
        }

        _contacts.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        ValidateContact(contact);

        var existingContact = FindContactById(contact.Id);

        existingContact.Name = contact.Name;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;
    }

    public void DeleteContact(int id)
    {
        var contact = FindContactById(id);
        _contacts.Remove(contact);
    }

    public List<Contact> GetAllContacts()
    {
        return _contacts;
    }

    // 🔹 Private Helper Methods (reduces duplication & complexity)

    private Contact FindContactById(int id)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == id);

        if (contact is null)
        {
            throw new KeyNotFoundException($"Contact with Id {id} not found.");
        }

        return contact;
    }

    private static void ValidateContact(Contact contact)
    {
        if (contact is null)
            throw new ArgumentNullException(nameof(contact));

        if (string.IsNullOrWhiteSpace(contact.Name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(contact.Email))
            throw new ArgumentException("Email is required.");
    }
}