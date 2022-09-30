using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Random_Passcode.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? Count = HttpContext.Session.GetInt32("count");
        if (Count == null)
        {
            HttpContext.Session.SetInt32("count", 1);
        }
        else{
            HttpContext.Session.SetInt32("count", (int)Count +1);
        }
        RandomPassword newPass = new RandomPassword();
        ViewBag.Password = newPass;
        return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
