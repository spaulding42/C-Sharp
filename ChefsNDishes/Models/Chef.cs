#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="must be 2 or more characters")]
    public string FirstName {get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage ="must be 2 or more characters")]
    public string LastName {get; set; }

    [Required]
    [Display(Name ="Date of Birth")]
    [MinimumAge(18,ErrorMessage ="18+ required")]
    public DateTime DoB {get;set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();
}

