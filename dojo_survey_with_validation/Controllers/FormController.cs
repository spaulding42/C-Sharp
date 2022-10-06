// Controller

using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;
namespace DojoSurvey.Controllers;  

public class FormController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]       //type of request
    [Route("")]     //associated route string (exclude the leading /)
    public ViewResult Index()
    {
        return View();
    }
    
    [HttpPost]       //type of request   POST
    [Route("submit")]         
    public IActionResult Submit(Survey data)
    {
        if(ModelState.IsValid)
        {
            return View("Result", data);
            
        }
        return View("Index");
    }

    [HttpGet("result")]
    public IActionResult Result(Survey data)
    {
        
        return View("Result", data);
    }
    
}