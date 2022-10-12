#pragma warning disable CS8618
/* 
Disabled Warning: "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable."
We can disable this safely because we know the framework will assign non-null values when it constructs this class for us.
*/
using Microsoft.EntityFrameworkCore;
namespace Products_and_categories.Models;
// the ChefsNdishesContext class representing a session with our MySQL database, allowing us to query for or save data
public class Products_and_categoriesContext : DbContext 
{ 
    public Products_and_categoriesContext(DbContextOptions options) : base(options) { }
    // the "User" table name will come from the DbSet property name
    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories {get;set; }
    public DbSet<ProductToCategory> Associations {get;set; }

    
}