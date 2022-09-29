// Controller

using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers;     //be sure to use your own project's namespace!
public class FormController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]       //type of request
    [Route("")]     //associated route string (exclude the leading /)
    public ViewResult Index()
    {
        return View();
    }
    [HttpGet]       //type of request
    [Route("/result")]     //associated route string (exclude the leading /)
    public ViewResult Result()
    {
        return View();
    }
    [HttpPost]
    [Route("result")]
    public IActionResult Result(string Name, string Location, string Language, string Message)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Message = Message;
        return View("Result");
    }
    
}