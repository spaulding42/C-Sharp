using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

// Using statements
    
public class HomeController : Controller
{
    private MyContext _context;
    
    // here we can "inject" our context service into the constructor
    public HomeController(MyContext context)
    {
        _context = context;
    }
    
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        Console.WriteLine($"Items in DB: {AllDishes.Count}");
        if(AllDishes.Count == 0) return Redirect("create");
        return View(AllDishes);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("submit")]
    public IActionResult Submit(Dish newDish)
    {
        Console.WriteLine("Made it here!");
        if(ModelState.IsValid)
        {
            // We can take the Dish object created from a form submission
            // And pass this object to the .Add() method
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Create");
    }
    
    [HttpGet("/dishes/{dishID}")]
    public IActionResult GetOneDish(int dishID)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d=>d.DishId == dishID);

        if (dish == null)
        {
            return RedirectToAction("/");
        }
        return View("Details",dish);
    }

    [HttpPost("/dishes/{dishID}/delete")]
    public IActionResult DeleteDish(int dishID)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d=>d.DishId == dishID);
        if(dish != null)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");

    }

    [HttpGet("/dishes/{dishID}/edit")]
    public IActionResult Edit(int dishID)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d=>d.DishId == dishID);

        if(dish == null)
        {
            return RedirectToAction("Index");
        }
        return View("Edit", dish);
    }

    [HttpPost("/dishes/{dishID}/update")]
    public IActionResult Update(Dish editedDish, int dishID)
    {
        if(ModelState.IsValid == false)
        {
            return Edit(dishID);
        }
        Dish? dish = _context.Dishes.FirstOrDefault(d=>d.DishId == dishID);

        if(dish == null)
        {
            return RedirectToAction("Index");
        }
        dish.Name = editedDish.Name;
        dish.Chef = editedDish.Chef;
        dish.Calories = editedDish.Calories;
        dish.Tastiness = editedDish.Tastiness;
        dish.Description = editedDish.Description;
        dish.UpdatedAt = DateTime.Now;
        _context.Dishes.Update(dish);
        _context.SaveChanges();

        return RedirectToAction("GetOneDish", new {dishID = dish.DishId});
    }
}