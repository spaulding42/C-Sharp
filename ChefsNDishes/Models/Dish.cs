#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish 
{
    [Key]
    
    public int DishId { get; set; }

    [Required]
    [MinLength(2,ErrorMessage = " must be 2+ characters long")]
    [Display(Name ="Name of Dish")]
    public string Name { get; set; } 

    [Required]
    public int Tastiness { get; set; }

    [Required]
    [Range(1,10000,ErrorMessage ="must be 1 or more calories")]
    public int Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    public int ChefId {get;set;}

    public Chef? Creator {get; set; }
}