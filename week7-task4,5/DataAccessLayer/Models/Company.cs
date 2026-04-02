using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}