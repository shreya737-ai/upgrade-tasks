using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        [Required]
        public string Designation { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }   // optional FK

        // Navigation Properties
        public Company Company { get; set; }
        public Department Department { get; set; }
    }
}