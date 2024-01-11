using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResourceManageGroup.Models;
using ResourceManageGroup.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Net.Mail;
namespace ResourceManageGroup.Controllers;
public class ManagerController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;
    public ManagerController(ApplicationDbContext dbContext,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult RegisterM()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> RegisterM(Manager manager)
    {
        if(ModelState.IsValid){
            try{
                int emailcount = 0;
                int numcount = 0;
                if(_dbContext.ManagerDetails!=null){
                    emailcount = _dbContext.ManagerDetails.Where(c => c.ManagerEmail == manager.ManagerEmail).Count();
                    numcount = _dbContext.ManagerDetails.Where(c => c.ManagerNumber == manager.ManagerNumber).Count();
                    if(manager.ManagerEmail!=null  && manager.ManagerNumber!=null && manager.ManagerPassword!=null){
                        if(emailcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else if(numcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else{
                            _dbContext.Add(manager);
                            await _dbContext.SaveChangesAsync();
                            ViewData["Message"]="Succesfully Registered , Log in to Work";
                        }
                    }
                }           
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(manager);
    }
    
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> ProjectListM()
    {
        if(_dbContext.ProjectDetails!=null){
            var projects = await _dbContext.ProjectDetails.ToListAsync();
            return View(projects);
        }
        return View();
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> ManageProjectM(int id)
    { 
        string ? myData = TempData["email"] as string;
        if(myData!=null)
        TempData.Keep(myData);
        if(_dbContext.ProjectDetails!=null){
            var projects = await _dbContext.ProjectDetails.Where(x => x.ProjectId == id ).FirstOrDefaultAsync();
            if(projects!=null){
                TempData["myData"] = projects.ProjectName;
                return View(projects);
            }
        }
        return View();
    }
    [HttpGet]
    [CustomAuthorize]
    public IActionResult AddProjectM()
    {
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> AddProjectM(Project project)
    {
        if(ModelState.IsValid){
            try{
                string ? myData = TempData["email"] as string;
                if(myData!=null)
                TempData.Keep(myData);
                int namecount = 0;
                if(_dbContext.ProjectDetails!=null){
                    namecount = _dbContext.ProjectDetails.Where(c => c.ProjectName == project.ProjectName).Count();
                    if(namecount>0){
                        ViewData["Message"]="The Project Name Already Exists !!!!!";
                    }
                    else{
                        project.ProjectLead="Not Assigned";
                        project.ProjectType="Not Assigned";
                        _dbContext.Add(project);
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("ProjectListM", "Manager");
                        if (url != null){
                            return Redirect(url);
                        }
                    }
                }
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model");
        return View(project);
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> UpdateProjectM(int id,Project project,Validation validation)
    {
        validation.List.AddRange(new string[] {"Web Application","Mobile Application","Desktop Appliaion"});
        ViewBag.list = validation.List;
        if(_dbContext.ProjectDetails!=null){
            var projects = await _dbContext.ProjectDetails.Where(x => x.ProjectId == id ).FirstOrDefaultAsync();
            return View(projects);
        }
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> UpdateProjectM(Project project,Validation validation)
    {
        validation.List.AddRange(new string[] { "Web Application", "Mobile Application", "Desktop Appliaion" });
        ViewBag.list = validation.List;
        if(ModelState.IsValid){
            try{
                if(_dbContext.ProjectDetails!=null){
                    var projects = await _dbContext.ProjectDetails.Where(x => x.ProjectId == project.ProjectId ).FirstOrDefaultAsync();
                    if(projects != null){
                        projects.ProjectName= project.ProjectName;
                        projects.ProjectDescription= project.ProjectDescription;
                        projects.ProjectType=project.ProjectType;
                        projects.ProjectStartTime=project.ProjectStartTime;
                        projects.ProjectEndTime=project.ProjectEndTime;
                    }
                    await _dbContext.SaveChangesAsync();
                    var url = Url.Action("ManageProjectM", "Manager",new { id = project.ProjectId });
                    if (url != null){
                        return Redirect(url);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "ProjectDetails is null.");
                }
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model");
        return View(project);
        //return RedirectToAction("HandleErrorCode", "Error", new { statusCode = 500 });
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> DeleteProjectM(int id)
    {
        if(_dbContext.ProjectDetails!=null){
            var projects = await _dbContext.ProjectDetails.Where(x => x.ProjectId == id ).FirstOrDefaultAsync();
            return View(projects);
        }
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> DeleteProjectM(Project project)
    {
        ModelState.Remove("ProjectEndTime");
        if(ModelState.IsValid){
            try{
                if(_dbContext.ProjectDetails!=null){
                    var projects = _dbContext.ProjectDetails.FirstOrDefault(p => p.ProjectId == project.ProjectId);
                    if(projects != null){
                        _dbContext.Remove(projects);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction("ProjectListM");
                    }
                }
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(project);
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> ManagePeopleM()
    {
        string ? myData = TempData["myData"] as String;
        TempData.Keep("myData");
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(e => e.EmployeeProject == myData).ToListAsync();
            return View(employees);
        }
        return View();
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> AddPeopleM()
    {
        string ? myData = TempData["myData"] as String;
        TempData.Keep("myData");
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(e => e.EmployeeWorkingStatus == "Bench").ToListAsync();
            return View(employees);
        }
        return View();
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> AddEmployeeM(string id)
    {
        string ? myData = TempData["myData"] as String;
        TempData.Keep("myData");
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.EmployeeId == id ).FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    public IActionResult GetImage(string id)
    {
        if(_dbContext.EmployeeDetails!=null){
            var employee = _dbContext.EmployeeDetails.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null && employee.EmployeeImage != null)
            {
                return File(employee.EmployeeImage, "image/jpeg"); 
            }
        }
        return NotFound();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> AddEmployeeM(Employee employee)
    {
        ModelState.Remove("EmployeeVacationEndTime");
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeAge");
        ModelState.Remove("EmployeeConfirmPassword");
        if(ModelState.IsValid){
            try{
                string ? myData = TempData["myData"] as String;
                TempData.Keep("myData");
                if(_dbContext.EmployeeDetails!=null){
                    var employees = _dbContext.EmployeeDetails.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
                    if(employees != null){
                        employees.EmployeeProject=myData;
                        employees.EmployeeWorkingStatus="InProject";
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("ManagePeopleM", "Manager");
                        if (url != null){
                            return Redirect(url);
                        }
                    }
                }
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(employee);
    }

    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> RemovePeopleM(string id,Employee employee)
    {
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.EmployeeId == id ).FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> RemovePeopleM(Employee employee)
    {
        ModelState.Remove("EmployeeVacationEndTime");
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeAge");
        ModelState.Remove("EmployeeConfirmPassword");
        if(ModelState.IsValid){
            try{
                if(_dbContext.EmployeeDetails!=null){
                    var employees = _dbContext.EmployeeDetails.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
                    if(employees != null){
                        employees.EmployeeWorkingStatus="Bench";
                        employees.EmployeeProject="Not Assigned"; 
                    }
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ManagePeopleM");
                }
            }
            
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(employee);
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> AssignLeaderM(string id,Employee employee)
    {
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.EmployeeId == id ).FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> AssignLeaderM(Employee employee,Project project)
    {
        ModelState.Remove("ProjectEndTime");
        ModelState.Remove("EmployeeVacationEndTime");
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeAge");
        ModelState.Remove("EmployeeConfirmPassword");
        if(ModelState.IsValid){
            try{
                if(_dbContext.EmployeeDetails!=null&&_dbContext.ProjectDetails!=null){
                    var projects = _dbContext.ProjectDetails.FirstOrDefault();
                    string ? name = _dbContext.EmployeeDetails.Where(c => c.EmployeeId == employee.EmployeeId).Select(c => c.EmployeeName).FirstOrDefault();
                    if(projects!=null){
                        projects.ProjectLead=name;
                    }
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ManagePeopleM");
                }
            }
            
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(employee);
    }
    
    public ActionResult LogoutM()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login","Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}