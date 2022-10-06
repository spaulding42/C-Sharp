#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Registration.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be 2 or more characters")]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "must be 2 or more characters")]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "must be a valid email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be 8 or more characters!")]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    [NotMapped]
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "does not match Password")]
    public string ConfirmPassword { get; set; }


    
    
}