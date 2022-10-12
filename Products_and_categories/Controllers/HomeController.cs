using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products_and_categories.Models;

namespace Products_and_categories.Controllers;

public class HomeController : Controller
{
    
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
