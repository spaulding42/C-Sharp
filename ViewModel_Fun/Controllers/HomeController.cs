using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost("message")]
    public IActionResult Message(string message)
    {
        Console.WriteLine(message);
        return View("Message", message);
    }

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        List<int> nums = new List<int>() {1,2,3,10,43,5};
        return View(nums);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> names = new List<User>();
        names.Add(new User("Moose","Phillips"));
        names.Add(new User("Goose","Phillips"));
        names.Add(new User("Phillips","Sixtysix"));
        names.Add(new User("Dev","DaDevil Dev"));
        names.Add(new User("Cher"));
        names.Add(new User("Sunny"));
        return View(names);
    }

    [HttpGet("user")]
    public IActionResult OneUser()
    {
        User name = new User("Dev", "DaDevil Dev");
        return View("User", name);
    }
}
