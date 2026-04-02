using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}