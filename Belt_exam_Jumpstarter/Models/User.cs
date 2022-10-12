#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_exam_Jumpstarter.Models;
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
    
    [NotMapped]
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "does not match Password")]
    public string ConfirmPassword { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    

    // relationship fields -------------------
    // one to many  
    public List<Project> UserProjects { get; set; } = new List<Project>();

    // Many to Many - 
    public List<UserPledge> UsersPledges { get; set; } = new List<UserPledge>();
}