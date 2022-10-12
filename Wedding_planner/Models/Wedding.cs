#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_planner.Models;
public class Wedding
{
    [Key]
    public int WeddingId {get; set;}

    [Required]
    [MinLength(2, ErrorMessage ="must be 2 or more characters")]
    public string WedderOne {get; set;}
    
    [Required]
    [MinLength(2, ErrorMessage ="must be 2 or more characters")]
    public string WedderTwo {get; set;}

    [Required]
    public DateTime Date {get; set;}

    [Required]
    public string Address {get; set; }

    // relationship fields
    
    // who is planning this wedding?
    public int UserId {get; set;}
    public User? Planner {get; set; }

    // who is attending this wedding?
    public List<UserWeddingRSVP> WeddingAttendees {get; set; } = new List<UserWeddingRSVP>();

}