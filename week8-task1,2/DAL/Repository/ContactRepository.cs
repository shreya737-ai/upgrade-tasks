using DAL.DapperContext;
using DAL.Models;
using DAL.Repository;
using Dapper;

namespace DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbConnectionFactory _context;

        public ContactRepository(DbConnectionFactory context)
        {
            _context = context;
        }

        public List<ContactInfo> GetAllContacts()
        {
            string query = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    comp.CompanyName,
                    dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                INNER JOIN Department dept ON c.DepartmentId = dept.DepartmentId";

            using var connection = _context.CreateConnection();
            return connection.Query<ContactInfo>(query).ToList();
        }

        public ContactInfo? GetContactById(int id)
        {
            string query = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    comp.CompanyName,
                    dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                INNER JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                WHERE c.ContactId = @Id";

            using var connection = _context.CreateConnection();
            return connection.QueryFirstOrDefault<ContactInfo>(query, new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            string query = @"
                INSERT INTO ContactInfo
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES
                (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            string query = @"
                UPDATE ContactInfo
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    EmailId = @EmailId,
                    MobileNo = @MobileNo,
                    Designation = @Designation,
                    CompanyId = @CompanyId,
                    DepartmentId = @DepartmentId
                WHERE ContactId = @ContactId";

            using var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }

        public void DeleteContact(int id)
        {
            string query = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using var connection = _context.CreateConnection();
            connection.Execute(query, new { Id = id });
        }

        public List<Company> GetAllCompanies()
        {
            string query = "SELECT CompanyId, CompanyName FROM Company";

            using var connection = _context.CreateConnection();
            return connection.Query<Company>(query).ToList();
        }

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT DepartmentId, DepartmentName FROM Department";

            using var connection = _context.CreateConnection();
            return connection.Query<Department>(query).ToList();
        }
    }
}