// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

namespace Belt_exam_Jumpstarter.Models;

public class UserPledge // Many to Many "through"/"join" table
{
    [Key]
    public int UserPledgeId { get; set; }

    [Required]
    [Range(1,Int32.MaxValue,ErrorMessage ="must be a dollar or more")]
    public int donationAmt {get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // Relationship properties below

    public int UserId { get; set; }
    public User? User { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}