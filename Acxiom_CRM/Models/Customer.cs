using System.ComponentModel.DataAnnotations;
namespace Acxiom_CRM.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100)]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage = "Enter a valid phone number")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company name is required")]
    [StringLength(100)]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{6}$",
        ErrorMessage = "Pincode must contain exactly 6 digits")]
    public string Pincode { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

}
