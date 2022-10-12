using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_and_categories.Models;

namespace Products_and_categories.Controllers;

public class ProductController : Controller
{
    private Products_and_categoriesContext db;

    public ProductController (Products_and_categoriesContext DB)
    {
        db = DB;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> productList = db.Products.ToList();
        return View("Index", productList);
    }

    [HttpPost("/submit/product")]
    public IActionResult SubmitProduct(Product SubmittedProduct)
    {
        if (ModelState.IsValid)
        {
            db.Add(SubmittedProduct);
            db.SaveChanges();
        }
        return Index();
    }

    [HttpGet("/products/{productId}")]
    public IActionResult ViewOne(int productId)
    {
        Product? oneProduct = db.Products
        .Include(p=>p.prodCategories)
        .FirstOrDefault(p=> p.ProductId == productId);
        if (oneProduct == null)
        {
            return RedirectToAction("Index");
        }
        // need to pass down a list of all categoreis available to choose from
        List<Category> categories = new List<Category>();
        categories = db.Categories.ToList();
        ViewBag.allCategories = categories;
        // List<Category> currentCategories = oneProduct.ProdCategories;

        // ViewBag.otherCategories = categories.Where(c=>c.CategoryId != currentCategories);

        return View("ViewOne", oneProduct);
    }

    [HttpPost("/products/categories")]
    public IActionResult AddCatToProd(ProductToCategory newAsso)
    {
        Category? addedCat = db.Categories.FirstOrDefault(c=>c.CategoryId == newAsso.CategoryId);
        Product? addedProd = db.Products.FirstOrDefault(p=>p.ProductId == newAsso.ProductId);
        if(ModelState.IsValid)
        {
            if(addedCat != null && addedProd != null)
            {
                addedCat.catProducts.Add(addedProd);
                addedProd.prodCategories.Add(addedCat);
                db.Update(addedCat);
                db.Update(addedProd);
                db.Add(newAsso);
                db.SaveChanges();
            }
            
        }
        return ViewOne(addedProd.ProductId);
    }
}