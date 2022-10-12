using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_and_categories.Models;

namespace Products_and_categories.Controllers;

public class CategoryController : Controller
{
    private Products_and_categoriesContext db;

    public CategoryController (Products_and_categoriesContext DB)
    {
        db = DB;
    }


    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> allCategories = new List<Category>();
        allCategories = db.Categories.ToList();
        return View("Categories", allCategories);
    }

    [HttpPost("/submit/category")]
    public IActionResult SubmitCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            db.Add(newCategory);
            db.SaveChanges();
            return RedirectToAction("Categories");
            
        }
        return View("Categories");
    }

    [HttpGet("/category/{categoryId}")]
    public IActionResult ViewOneCategory(int categoryId)
    {
        Category? oneCategory = db.Categories
        .Include(p=>p.catProducts)
        .FirstOrDefault(p=> p.CategoryId == categoryId);
        if (oneCategory == null)
        {
            return RedirectToAction("Categories");
        }
        List<Product> products = new List<Product>();
        products = db.Products.ToList();
        ViewBag.allProducts = products;
        return View("ViewOneCategory", oneCategory);
    }

    [HttpPost("/categories/products")]
    public IActionResult AddProdToCat(ProductToCategory newAsso)
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
        return ViewOneCategory(addedCat.CategoryId);
    }

}
