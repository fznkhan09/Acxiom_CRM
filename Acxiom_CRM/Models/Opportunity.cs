using System.ComponentModel.DataAnnotations;

namespace Acxiom_CRM.Models
{
    public class Opportunity
    {
        public int OpportunityId { get; set; }

        [Required]
        [StringLength(150)]
        public string OpportunityName { get; set; } = string.Empty;

        [Range(0.01, 1000000000,
            ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Range(0, 100,
            ErrorMessage = "Probability must be between 0 and 100")]
        public int Probability { get; set; }

        [Required]
        public string SalesStage { get; set; } = "Qualification";

        [Required]
        public string Status { get; set; } = "Open";

        [DataType(DataType.Date)]
        public DateTime ExpectedCloseDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
