using System.ComponentModel.DataAnnotations;
namespace Form_Submission.Models;
#pragma warning disable CS8618

public class User
{
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(3)]
    public string LastName { get; set; }

    [Required]
    [Range(0,150)]
    public int Age { get; set; }
 
    [Required]
    [EmailAddress]
    public string Email { get; set; }
 
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}