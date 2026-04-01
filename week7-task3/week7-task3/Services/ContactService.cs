
using week7_task3.Models;

namespace ContactManagementApp.Services
{
    public class ContactService : IContactService
    {
        // Static list allowed ONLY inside service class
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Shreya",
                LastName = "Banerjee",
                CompanyName = "ABC Infotech",
                EmailId = "shreya@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Riya",
                LastName = "Sen",
                CompanyName = "XYZ Ltd",
                EmailId = "riya@gmail.com",
                MobileNo = 9123456780,
                Designation = "Tester"
            }
        };

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }
    }
}