using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task AddAsync(ContactInfo contact);
        Task UpdateAsync(ContactInfo contact);
        Task DeleteAsync(int id);
    }
}
