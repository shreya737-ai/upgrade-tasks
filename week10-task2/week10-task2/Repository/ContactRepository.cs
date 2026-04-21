using week10_task2.Models;

namespace week10_task2.Repository
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> contacts = new List<Contact>();

        public IEnumerable<Contact> GetAll() => contacts;

        public Contact GetById(int id) =>
            contacts.FirstOrDefault(c => c.Id == id);

        public void Add(Contact contact)
        {
            contact.Id = contacts.Count + 1;
            contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = GetById(contact.Id);
            if (existing != null)
            {
                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;
            }
        }

        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
                contacts.Remove(contact);
        }
    }
}
