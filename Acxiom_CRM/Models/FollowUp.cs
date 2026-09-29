using System.ComponentModel.DataAnnotations;

namespace Acxiom_CRM.Models
{
    public class FollowUp
    {
        public int FollowUpId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime FollowUpDate { get; set; }

        [Required]
        public string FollowUpType { get; set; } = "Call";

        [StringLength(500)]
        public string Remarks { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Pending";
    }
}
