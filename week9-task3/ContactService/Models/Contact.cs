using System.ComponentModel.DataAnnotations;

namespace ContactService.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        // Reference only, no FK, no validation
        public int? CategoryId { get; set; }
    }
}