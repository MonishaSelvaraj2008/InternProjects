using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResourceManageGroup.Models;
using ResourceManageGroup.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Net.Mail;
using AliasConsole=System.Console;
namespace ResourceManageGroup.Controllers;
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public EmployeeController(ApplicationDbContext dbContext,IWebHostEnvironment hostEnvironment)
    {
        
        _dbContext = dbContext;
    } 
    
    [HttpGet]
    public IActionResult RegisterE()
    {
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterE(Employee employee,Validation validation)
    {
        ModelState.Remove("EmployeeVacationEndTime");
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeVacationReason");
        if(ModelState.IsValid){
            try{
                int emailcount = 0;
                int numcount = 0;
                if(_dbContext.EmployeeDetails!=null){
                    emailcount = _dbContext.EmployeeDetails.Where(c => c.EmployeeEmail == employee.EmployeeEmail).Count();
                    numcount = _dbContext.EmployeeDetails.Where(c => c.EmployeeNumber == employee.EmployeeNumber).Count();
                    if(employee.EmployeeEmail!=null &&  employee.EmployeeNumber!=null && employee.EmployeePassword!=null){
                        if(emailcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else if(numcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else{
                            employee.EmployeeTechnology = "Not Assigned";
                            employee.EmployeeProject = "Not Assigned";
                            employee.EmployeeWorkingStatus = "Not Assigned" ;
                            employee.EmployeeTrainingStartTime = "Not Assigned" ;
                            employee.EmployeeTrainingEndTime = "Not Assigned" ;
                            employee.EmployeeTrainerName = "Not Assigned" ;
                            employee.EmployeeVacationStartTime = "Not Assigned" ;
                            employee.EmployeeVacationEndTime = "Not Assigned" ;
                            employee.EmployeeVacationStatus =  "Not Assigned" ;
                            employee.EmployeeImage = null;  
                            employee.EmployeeVacationReason = "Not Assigned";                                                                    ViewData["Message"]="Succesfully Registered , Log in to Work";
                            ViewData["Message"]="Succesfully Registered , Log in to Work";
                            _dbContext.Add(employee);
                            await _dbContext.SaveChangesAsync();
                        }
                    }           
                }
            }
            catch(Exception exception){
                AliasConsole.WriteLine(exception.Message);
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        ModelState.AddModelError(String.Empty,$"Something Went Wrong Invalid Model"); 
        return View(employee);
    }
    
    [HttpGet("Employee/EmployeeViewE/{employeeId:regex(^\\d{{2}}EM\\d{{2,3}}$)}")]
    //[HttpGet("Employee/EmployeeViewE/{employeeId:length(8,9)}")]
    [CustomAuthorize]
    public async Task<IActionResult> EmployeeViewE(string employeeId)
    {
        if (_dbContext.EmployeeDetails != null)
        {
            var employees = await _dbContext.EmployeeDetails
                .Where(x => x.EmployeeId == employeeId)
                .FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> VacationRequestE(Employee employee)
    {
        string ? myData = TempData["EmpId"] as String;
        TempData.Keep("EmpId");
        employee.EmployeeId=myData;
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.EmployeeId == employee.EmployeeId ).FirstOrDefaultAsync();
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
    [HttpGet]
    [CustomAuthorize]
    public async Task<IActionResult> EditEmployeeE(Employee employee)
    {
        string ? myData = TempData["EmpId"] as String;
        TempData.Keep("EmpId");
        employee.EmployeeId=myData;
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.EmployeeId == employee.EmployeeId ).FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> EditEmployeeE(Employee employee, IFormFile image1)
    {
        string? myData = TempData["EmpId"] as string;
        TempData.Keep("EmpId");
        employee.EmployeeId = myData;
        ModelState.Remove("EmployeeVacationEndTime");
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeConfirmPassword");
        if (ModelState.IsValid)
        {
            try
            {
                if (_dbContext.EmployeeDetails != null)
                {
                    var employees = await _dbContext.EmployeeDetails.FindAsync(employee.EmployeeId);
                    if (employees != null)
                    {
                        employees.EmployeeName = employee.EmployeeName;
                        employees.EmployeeNumber = employee.EmployeeNumber;
                        employees.EmployeeEmail = employee.EmployeeEmail;
                        employees.EmployeeAge= employee.EmployeeAge;

                        if (image1 != null && image1.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await image1.CopyToAsync(memoryStream);
                                employees.EmployeeImage = memoryStream.ToArray();
                            }
                        }
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.EmployeeId });
                        if (url != null)
                        {
                            return Redirect(url);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee not found");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Database context is null");
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong: {exception.Message}");
            }
        }

        return View(employee);
    }
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> VacationRequestE(Employee employee,int a)
    {
        string ? myData = TempData["EmpId"] as string;
        TempData.Keep("EmpId");
        employee.EmployeeId = myData;
        ModelState.Remove("EmployeeTrainingEndTime");
        ModelState.Remove("EmployeeAge");
        ModelState.Remove("EmployeeConfirmPassword");
        if (ModelState.IsValid)
        {
            try
            {
                if(_dbContext.EmployeeDetails!=null){
                    var employees = await _dbContext.EmployeeDetails.FindAsync(employee.EmployeeId);
                    if (employees != null)
                    {
                        employees.EmployeeVacationStatus = "Not Yet";
                        employees.EmployeeVacationEndTime =employee.EmployeeVacationEndTime ;
                        employees.EmployeeVacationStartTime = employee.EmployeeVacationStartTime;
                        employees.EmployeeVacationReason=employee.EmployeeVacationReason;
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.EmployeeId });
                        if (url != null)
                        {
                            return Redirect(url);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee not found");
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong: {exception.Message}");
            }
        }
        return View(employee);
    }
    [CustomAuthorize]
    public ActionResult LogoutE()
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