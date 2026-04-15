
using ContactManagementAPI.Repositories.Interfaces;
using week9_task2.Models;

namespace ContactManagementAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public ContactRepository()
        {
            _contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Shreya", Email = "shreya@gmail.com" },
                new Contact { Id = 2, Name = "Rahul", Email = "rahul@gmail.com" },
                new Contact { Id = 3, Name = "Anjali", Email = "anjali@gmail.com" }
            };
        }

        public List<Contact> GetAll()
        {
            Console.WriteLine("👉 Fetching from DATABASE");
            return _contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine($"👉 Fetching Contact {id} from DATABASE");
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}