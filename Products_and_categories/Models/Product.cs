#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_categories.Models;

public class Product
{
    [Key]
    public int ProductId {get; set;}

    [Required]
    public string Name {get; set; }

    [Required]
    public string Description {get; set; }

    [Required]
    [Range(0,Int32.MaxValue,ErrorMessage ="must be a positive number")]
    public double Price {get; set; }

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Category> prodCategories {get; set;} = new List<Category>();

    public List<ProductToCategory> CategoryAssociations {get; set; } = new List<ProductToCategory>();
}