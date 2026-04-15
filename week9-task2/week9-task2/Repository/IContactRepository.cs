
using week9_task2.Models;

namespace week9_task2.Repository.IContactRepository
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}