// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

namespace Wedding_planner.Models;

public class UserWeddingRSVP // Many to Many "through"/"join" table
{
    [Key]
    public int UserWeddingRSVPId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // Relationship properties below

    public int UserId { get; set; }
    public User? User { get; set; }
    public int WeddingId { get; set; }
    public Wedding? Wedding { get; set; }
}