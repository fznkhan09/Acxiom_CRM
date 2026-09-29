using System.ComponentModel.DataAnnotations;

namespace Acxiom_CRM.Models
{
    public class Lead
    {
        public int LeadId { get; set; }

        [Required]
        [StringLength(100)]
        public string LeadName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string LeadSource { get; set; } = "Website";

        [Required]
        public string LeadStatus { get; set; } = "New";

        [Range(0.01, 100000000,
            ErrorMessage = "Expected value must be greater than zero")]
        public decimal ExpectedValue { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
