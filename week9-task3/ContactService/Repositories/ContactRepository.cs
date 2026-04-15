using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _db;
        public ContactRepository(ContactDbContext db) { _db = db; }

        public async Task<Contact> Add(Contact contact)
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
            return contact;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.Contacts.FindAsync(id);
            if (entity != null)
            {
                _db.Contacts.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _db.Contacts.AsNoTracking().ToListAsync();
        }

        public async Task<Contact?> GetById(int id)
        {
            return await _db.Contacts.AsNoTracking().FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task Update(Contact contact)
        {
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync();
        }
    }
}