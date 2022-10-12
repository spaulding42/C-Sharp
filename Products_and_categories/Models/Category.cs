#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_categories.Models;

public class Category
{
    [Key]
    public int CategoryId {get; set;}

    [Required]
    public string Name {get; set; }

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Product> catProducts {get; set; } = new List<Product>();
    public List<ProductToCategory> ProductAssociations {get; set; } = new List<ProductToCategory>();

}