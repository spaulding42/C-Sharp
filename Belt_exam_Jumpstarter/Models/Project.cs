#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_exam_Jumpstarter.Models;

public class Project
{
    [Key]
    public int ProjectId {get; set; }

    [Required]
    [MinLength(2,ErrorMessage ="must be 2 or more characters")]
    public string Title {get; set; }

    [Required]
    [Range(0,Int32.MaxValue, ErrorMessage ="Must be a positive number")]
    public int Goal {get; set; }

    [Required]
    public DateTime EndDate {get; set; }

    [Required]
    [MinLength(20, ErrorMessage = "must be at least 20 characters")]
    public string Description {get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // public int Raised {get; set; }

    // relationship data
    public int UserId {get; set; }
    public User? Creator {get; set; } 

    public List<UserPledge> DonorList {get; set; } = new List<UserPledge>();

}