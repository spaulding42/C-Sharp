#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_categories.Models;

public class ProductToCategory
{
    [Key]
    public int AssociationId {get; set;}

    
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    // Relationship Properties

    public int ProductId {get; set;}
    public Product? ProductAss {get; set;}

    public int CategoryId {get; set; }
    public Category? CategoryAss {get; set;}
}