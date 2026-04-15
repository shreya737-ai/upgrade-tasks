using Microsoft.Extensions.Caching.Memory;
using week9_task2.Models;
using week9_task2.Repository.IContactRepository;
using week9_task2.Service;

namespace ContactManagementAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string cacheKey = "contact_list";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                // ❌ Cache Miss → Fetch from DB
                contacts = _repo.GetAll();

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, options);

                Console.WriteLine("✅ Data stored in CACHE");
            }
            else
            {
                // ✅ Cache Hit
                Console.WriteLine("⚡ Data fetched from CACHE");
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                // ❌ Cache Miss
                contact = _repo.GetById(id);

                if (contact != null)
                {
                    var options = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, options);

                    Console.WriteLine($"✅ Contact {id} stored in CACHE");
                }
            }
            else
            {
                // ✅ Cache Hit
                Console.WriteLine($"⚡ Contact {id} fetched from CACHE");
            }

            return contact;
        }
    }
}