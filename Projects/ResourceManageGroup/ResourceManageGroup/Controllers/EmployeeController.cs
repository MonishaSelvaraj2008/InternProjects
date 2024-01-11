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
        ModelState.Remove("employeeVacationEndTime");
        ModelState.Remove("employeeTrainingEndTime");
        ModelState.Remove("employeeVacationReason");
        if(ModelState.IsValid){
            try{
                int emailcount = 0;
                int numcount = 0;
                if(_dbContext.EmployeeDetails!=null){
                    emailcount = _dbContext.EmployeeDetails.Where(c => c.employeeEmail == employee.employeeEmail).Count();
                    numcount = _dbContext.EmployeeDetails.Where(c => c.employeeNumber == employee.employeeNumber).Count();
                    if(employee.employeeEmail!=null &&  employee.employeeNumber!=null && employee.employeePassword!=null){
                        if(emailcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else if(numcount>0){
                            ViewData["Message"]="The User Already Exists !!!!!";
                        }
                        else{
                            employee.employeeTechnology = "Not Assigned";
                            employee.employeeProject = "Not Assigned";
                            employee.employeeWorkingStatus = "Not Assigned" ;
                            employee.employeeTrainingStartTime = "Not Assigned" ;
                            employee.employeeTrainingEndTime = "Not Assigned" ;
                            employee.employeeTrainerName = "Not Assigned" ;
                            employee.employeeVacationStartTime = "Not Assigned" ;
                            employee.employeeVacationEndTime = "Not Assigned" ;
                            employee.employeeVacationStatus =  "Not Assigned" ;
                            employee.employeeImage = null;  
                            employee.employeeVacationReason = "Not Assigned";                                                                    ViewData["Message"]="Succesfully Registered , Log in to Work";
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
                .Where(x => x.employeeId == employeeId)
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
        employee.employeeId=myData;
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.employeeId == employee.employeeId ).FirstOrDefaultAsync();
            return View(employees);
        }
        return View();
    }
    public IActionResult GetImage(string id)
    {
        if(_dbContext.EmployeeDetails!=null){
            var employee = _dbContext.EmployeeDetails.FirstOrDefault(e => e.employeeId == id);
            if (employee != null && employee.employeeImage != null)
            {
                return File(employee.employeeImage, "image/jpeg"); 
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
        employee.employeeId=myData;
        if(_dbContext.EmployeeDetails!=null){
            var employees = await _dbContext.EmployeeDetails.Where(x => x.employeeId == employee.employeeId ).FirstOrDefaultAsync();
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
        employee.employeeId = myData;
        ModelState.Remove("employeeVacationEndTime");
        ModelState.Remove("employeeTrainingEndTime");
        ModelState.Remove("employeeConfirmPassword");
        if (ModelState.IsValid)
        {
            try
            {
                if (_dbContext.EmployeeDetails != null)
                {
                    var employees = await _dbContext.EmployeeDetails.FindAsync(employee.employeeId);
                    if (employees != null)
                    {
                        employees.employeeName = employee.employeeName;
                        employees.employeeNumber = employee.employeeNumber;
                        employees.employeeEmail = employee.employeeEmail;
                        employees.employeeAge= employee.employeeAge;

                        if (image1 != null && image1.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await image1.CopyToAsync(memoryStream);
                                employees.employeeImage = memoryStream.ToArray();
                            }
                        }
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.employeeId });
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
        employee.employeeId = myData;
        ModelState.Remove("employeeTrainingEndTime");
        ModelState.Remove("employeeAge");
        ModelState.Remove("employeeConfirmPassword");
        if (ModelState.IsValid)
        {
            try
            {
                if(_dbContext.EmployeeDetails!=null){
                    var employees = await _dbContext.EmployeeDetails.FindAsync(employee.employeeId);
                    if (employees != null)
                    {
                        employees.employeeVacationStatus = "Not Yet";
                        employees.employeeVacationEndTime =employee.employeeVacationEndTime ;
                        employees.employeeVacationStartTime = employee.employeeVacationStartTime;
                        employees.employeeVacationReason=employee.employeeVacationReason;
                        await _dbContext.SaveChangesAsync();
                        var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.employeeId });
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
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}