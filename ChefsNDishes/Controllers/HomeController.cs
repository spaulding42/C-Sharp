using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{

     private ChefsNdishesContext db;

    public HomeController (ChefsNdishesContext DB)
    {
        db = DB;
    }
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        List<Chef> dbChefs = db.Chefs.Include(c=>c.CreatedDishes).ToList();
        return View("Index", dbChefs);
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> dbDishes = db.Dishes.Include(d=>d.Creator).ToList();
        if(dbDishes.Count == 0)
        {
            return Redirect("/dishes/new");
        }
        return View("Dishes",dbDishes);
    }

    [HttpGet("/chefs/new")]
    public IActionResult AddChef()
    {
        return View("AddChef");
    }

    [HttpPost("submit/chef")]
    public IActionResult SubmitChef(Chef submittedChef)
    {
        if (ModelState.IsValid)
        {
            db.Chefs.Add(submittedChef);
            db.SaveChanges();
            return Index();
        }
        return AddChef();
    }

    [HttpGet("/dishes/new")]
    public IActionResult AddDish()
    {
        List<Chef> chefs = db.Chefs.ToList();
        if(chefs.Count == 0)
        {
            return View("ChefFirst");
        }
        ViewBag.data = chefs;
        return View("AddDish");
    }

    [HttpPost("/submit/dish")]
    public IActionResult SubmitDish(Dish submittedDish)
    {
        if(ModelState.IsValid)
        {
            db.Dishes.Add(submittedDish);
            db.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return AddDish();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
