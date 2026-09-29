namespace Acxiom_CRM.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public int EntityId { get; set; }

        public string? UserName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
