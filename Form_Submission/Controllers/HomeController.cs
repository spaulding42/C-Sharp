using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Form_Submission.Models;

namespace Form_Submission.Controllers;

public class HomeController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("NewUser")]
    public IActionResult NewUser()
    {
        return View();
    }
    [HttpPost("Create")]
    public IActionResult Create(User user)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("show",user);
        }
        else
        {
            return View("NewUser");
        }
    }

    [HttpGet("show")]
    public IActionResult Show(User user)
    {
        return View("Create",user);
    }
  
}
