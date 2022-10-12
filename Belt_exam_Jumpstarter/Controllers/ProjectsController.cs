
using Microsoft.AspNetCore.Mvc;
using Belt_exam_Jumpstarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Belt_exam_Jumpstarter.Controllers;

public class ProjectsController : Controller
{
    private UserPledgeContext db;

    public ProjectsController (UserPledgeContext DB)
    {
        db = DB;
    }

    [HttpGet("/projects")]
    public IActionResult AllProjects()
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");
        
        List<Project> allProjects = db.Projects
        .Include(p=>p.DonorList)
        .Include(p=>p.Creator).ToList();
        User? LoggedUser = db.Users.FirstOrDefault(u=>u.UserId == uid);
        
        int fundedProjects = 0;
        int totalRaised = 0;
        int totalPledges = 0;
        foreach(Project proj in allProjects)
        {
            int raised = 0;
            foreach(UserPledge pledge in proj.DonorList)
            {
                raised += pledge.donationAmt;
                totalRaised += pledge.donationAmt;
                totalPledges++;
            }
            if (raised >= proj.Goal)
            {
                fundedProjects++;
            }
        }
        ViewBag.user = LoggedUser;
        ViewBag.FundedProjects = fundedProjects;
        ViewBag.TotalRaised = totalRaised;
        ViewBag.totalPledges = totalPledges;
        return View("AllProjects", allProjects);
    }

    [HttpGet("/projects/new")]
    public IActionResult NewProject()
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        
        return View("NewProject");
    }

    [HttpPost("/submit")]
    public IActionResult SubmitProject(Project newProject)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        if(ModelState.IsValid)
        {
            if(newProject.EndDate < DateTime.Now)
            {
                ModelState.AddModelError("EndDate","must be in the future");
                return View("NewProject");
            }
            newProject.UserId = (int)uid;
            db.Add(newProject);
            db.SaveChanges();

            return Redirect($"/projects/{newProject.ProjectId}");
        }

        return NewProject();
    }

    [HttpGet("/projects/{projectId}")]
    public IActionResult ViewOne(int projectId)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        Project? OneProject = db.Projects.Include(p=>p.Creator).Include(p=>p.DonorList).FirstOrDefault(p=>p.ProjectId == projectId);
        if (OneProject == null)
        {
            return RedirectToAction("AllProjects");
        }
        int raised = 0;
        foreach(UserPledge pledge in OneProject.DonorList)
        {
            raised += pledge.donationAmt;
            Console.WriteLine("foundPledge");
        }
        ViewBag.RaisedAmt = raised;
        ViewBag.projId = OneProject.ProjectId;
            
        float goal = OneProject.Goal;
        float goalPercent = (float)((raised/goal) *100);
        if (goalPercent > 100)
        {
            goalPercent = 100;
        } 
            
        ViewBag.GoalPercent = goalPercent;
        return View("ViewOne", OneProject);
    }

    [HttpPost("/projects/pledge")]
    public IActionResult Pledge(Pledge newPledge)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");
        if(ModelState.IsValid)
        {
            User? loggedUser = db.Users.FirstOrDefault(u=>u.UserId == uid);
            Project?  dbProject = db.Projects.Include(p=>p.Creator).FirstOrDefault(p=>p.ProjectId == newPledge.ProjectId);
            // User? ProjectCreator = dbProject.
            if(dbProject != null && loggedUser != null)
            {
                UserPledge newDBPledge = new UserPledge() {
                    UserId = (int)uid,
                    ProjectId = newPledge.ProjectId,
                    donationAmt = newPledge.PledgeAmt
                };
                
                dbProject.Creator.UserProjects.Add(dbProject);
                dbProject.DonorList.Add(newDBPledge);
                db.Update(dbProject);
                db.Add(newDBPledge);
                db.SaveChanges();

            }
        }
        return ViewOne(newPledge.ProjectId);
    }

    [HttpPost("/delete/{projectId}")]
    public IActionResult Delete(int projectId)
    {
        int? uid = HttpContext.Session.GetInt32("UUID");
        if (uid == null) return RedirectToAction("Index", "Users");

        Project? deleteProject = db.Projects.FirstOrDefault(p=>p.ProjectId == projectId);
        if(deleteProject == null || uid != deleteProject.UserId)
        {
            return RedirectToAction("AllProjects");
        }
        db.Projects.Remove(deleteProject);
        db.SaveChanges();
        return AllProjects();

    }
}