#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_planner.Models;
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


    // relationship fields -------------------
    // one to many  
    public List<Wedding> UserWeddings { get; set; } = new List<Wedding>();

    // Many to Many - 
    public List<UserWeddingRSVP> UserRSVPs { get; set; } = new List<UserWeddingRSVP>();
}