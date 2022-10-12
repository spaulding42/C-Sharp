using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_planner.Models;

namespace Wedding_planner.Controllers;

public class WeddingsController : Controller
{
    private WeddingPlanContext db;

    public WeddingsController (WeddingPlanContext DB)
    {
        db = DB;
    }

    [HttpGet("/weddings")]
    public IActionResult AllWeddings()
    {
         // if not logged in redirect
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");
        
        List<Wedding> allWeddings = db.Weddings
        .Include(w=>w.WeddingAttendees).ToList();
        User? LoggedUser = db.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("UUID"));
        ViewBag.user = LoggedUser;
        return View("AllWeddings", allWeddings);
    }

    [HttpGet("/weddings/new")]
    public IActionResult NewWedding()
    {
        // if not logged in redirect
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        User? LoggedUser = db.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("UUID"));
        if (LoggedUser != null)
        {
            ViewBag.user = LoggedUser;
        }
        else
        ViewBag.user = "";
        return View("AddWedding");
    }

    [HttpPost("/submit")]
    public IActionResult Submit(Wedding formWedding)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");
        
        if(ModelState.IsValid)
        {
            formWedding.UserId = (int)uid;
            db.Weddings.Add(formWedding);
            db.SaveChanges();
            return RedirectToAction("AllWeddings", "Weddings");
        }
            Console.WriteLine("invalid submission");
        return NewWedding();
    }

    [HttpPost("/delete/{weddingId}")]
    public IActionResult Delete(int weddingId)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        Wedding? deleteWedding = db.Weddings.FirstOrDefault(w=>w.WeddingId == weddingId);
        if (deleteWedding == null || uid != deleteWedding.UserId)
        {
            return RedirectToAction("AllWeddings");
        }
        db.Weddings.Remove(deleteWedding);
        db.SaveChanges();
        return AllWeddings();
    }

    [HttpPost("/weddings/{weddingId}/rsvp")]
    public IActionResult RSVP(int weddingId)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        UserWeddingRSVP? existingRSVP = db.WeddingAttendees
            .FirstOrDefault(wa => wa.WeddingId == weddingId && wa.UserId == (int)uid);

        if(existingRSVP==null)
        {
            UserWeddingRSVP newAttendee = new UserWeddingRSVP() {
                UserId = (int)uid,
                WeddingId = weddingId
            };
            db.WeddingAttendees.Add(newAttendee);
        }
        else
        {
            db.WeddingAttendees.Remove(existingRSVP);
        }

        db.SaveChanges();
        return AllWeddings();
    }
    // logout and redirect to the login screen
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        Console.WriteLine("Logging out");
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Users");
    }

    [HttpGet("/weddings/{weddingId}")]
    public IActionResult ViewOne(int weddingId)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");
        
        User? dbUser = db.Users.FirstOrDefault(u=>u.UserId == uid);

        Wedding? oneWedding = db.Weddings
        .Include(w=>w.Planner)
        .Include(w=>w.WeddingAttendees)
        .ThenInclude(uw => uw.User)
        .FirstOrDefault(w=>w.WeddingId == weddingId);
        if (oneWedding != null)
        {
            if(dbUser != null) ViewBag.user = dbUser;
            return View("ViewOne", oneWedding);
        }
        return RedirectToAction("AllWeddings");
    }
}
