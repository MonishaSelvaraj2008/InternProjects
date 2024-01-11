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
public class LoginController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public LoginController(ApplicationDbContext dbContext,IWebHostEnvironment hostEnvironment)
    {
        
        _dbContext = dbContext;
    } 
    [HttpGet]
    public IActionResult Login(Login login)
    {
        var cookieValue = Request.Cookies["MyAuthCookie"];
        if (cookieValue != null)
        {
            var decodedCookie = cookieValue.Split(":");
            login.UserEmail = decodedCookie[0];
            login.UserPassword = decodedCookie[1];
            ViewBag.email=login.UserEmail;
            ViewBag.password=login.UserPassword;
        }
        return View();
    }
    [HttpPost]
    public IActionResult Login(Login login,Validation validation)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if(login.UserEmail!=null){
                var dbpassworde = GetEmployeePassword(login.UserEmail);
                var dbpasswordm = GetManagerPassword(login.UserEmail);
                var dbpasswordh = GetRecruiterPassword(login.UserEmail);

                if (!string.IsNullOrEmpty(dbpassworde) && dbpassworde.Equals(login.UserPassword))
                {
                    //Storing values of employee model in json file named "users" in session
                    HttpContext.Session.SetObjectAsJson("users", login);
                            //Cookies 
                    var cookieValue = $"{login.UserEmail}:{login.UserPassword}";
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(30),
                        HttpOnly = true
                    };
                    Response.Cookies.Append("MyAuthCookie", cookieValue, cookieOptions);
                    string ? empId;
                    if(_dbContext.EmployeeDetails!=null){
                        empId = _dbContext.EmployeeDetails.Where(c => c.EmployeeEmail == login.UserEmail).Select(c => c.EmployeeId).FirstOrDefault();
                        TempData["EmpId"]=Convert.ToString(empId);
                        return RedirectToAction("EmployeeViewE", "employee", new { employeeId = empId });
                    }
                }
                else if (!string.IsNullOrEmpty(dbpasswordm) && dbpasswordm.Equals(login.UserPassword))
                {
                    //Storing values of employee model in json file named "users" in session
                    HttpContext.Session.SetObjectAsJson("users", login);
                    //Cookies 
                    var cookieValue = $"{login.UserEmail}:{login.UserPassword}";
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(30),
                        HttpOnly = true
                    };
                    Response.Cookies.Append("MyAuthCookie", cookieValue, cookieOptions);
                    
                    return RedirectToAction("ProjectListM", "Manager");
                }
                else if (!string.IsNullOrEmpty(dbpasswordh) && dbpasswordh.Equals(login.UserPassword))
                {
                    //Storing values of employee model in json file named "users" in session
                    HttpContext.Session.SetObjectAsJson("users", login);
                    //Cookies 
                    var cookieValue = $"{login.UserEmail}:{login.UserPassword}";
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(30),
                        HttpOnly = true
                    };
                    Response.Cookies.Append("MyAuthCookie", cookieValue, cookieOptions);
                    return RedirectToAction("EmployeeListR", "Recruiter");
                    
                }
                else
                {
                    ViewData["Message"] = "Invalid Email or Password";
                }
            }
            }
            catch (Exception exception)
            {
                AliasConsole.WriteLine(exception.Message);
                ModelState.AddModelError(String.Empty, $"Something Went Wrong: {exception.Message}");
            }
        }

        return View(login);
    }
    
    [HttpGet]
    public IActionResult VerifyUser()
    {
        return View();
    }
    [HttpPost]
    public IActionResult VerifyUser(Validation validation,Login login)
    {
        string ? myData = TempData["verificationcode"] as String;
        string ? email = TempData["email"] as String;
        if(myData==validation.VerifyCode){
            login.UserEmail=email;
            HttpContext.Session.SetObjectAsJson("users", login);
            if(login.UserEmail!=null){
                string userRole = GetUserRole(login.UserEmail);
                if (userRole == "Manager")
                {
                    // Redirect to Manager's page
                    return RedirectToAction("ProjectListM", "Manager");
                }
                else if (userRole == "Recruiter")
                {
                    // Redirect to Recruiter's page
                    return RedirectToAction("EmployeeListR", "Recruiter");
                }
                else if (userRole == "Employee")
                {
                    // Redirect to Employee's page
                    string ? empId;
                    if(_dbContext.EmployeeDetails!=null){
                        empId = _dbContext.EmployeeDetails.Where(c => c.EmployeeEmail == login.UserEmail).Select(c => c.EmployeeId).FirstOrDefault();
                        TempData["EmpId"]=Convert.ToString(empId);
                        return RedirectToAction("EmployeeViewE", "employee", new { employeeId = empId });
                    }
                }
            }
        }
        else{
            ViewBag.message="OTP is Invalid";
        }
        return View();
    }

    [HttpGet]
    public IActionResult forgotPassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult forgotPassword(Login login)
    {
        if(ModelState.IsValid){
            try{
                int count = 0;
                count = _dbContext.EmployeeDetails?.Count(c => c.EmployeeEmail == login.UserEmail) ?? 0;
                if (count == 0)
                {
                    count = _dbContext.ManagerDetails?.Count(c => c.ManagerEmail == login.UserEmail) ?? 0;
                }
                if (count == 0)
                {
                    count = _dbContext.RecruiterDetails?.Count(c => c.RecruiterEmail == login.UserEmail) ?? 0;
                }
                if(login.UserEmail!=null){
                    if(count>0){
                        try
                        {
                            Random random = new Random();
                            string code = random.Next(100000, 999999).ToString();
                            TempData["verificationcode"] = code;
                            TempData["email"] = login.UserEmail;
                            string from, pass, messageBody;
                            MailMessage message = new MailMessage();
                            from = "kishorevijaykumar26@gmail.com";
                            pass = "otdkzpvmdebguxla";
                            messageBody = "Your Verification Code is " + code;
                            if(login.UserEmail != null)
                            {
                                message.To.Add(new MailAddress(login.UserEmail));
                            }
                            else
                            {
                                throw new Exception("User email is null or invalid.");
                            }
                            message.From = new MailAddress(from);
                            message.Body = messageBody;
                            message.Subject = "Otp To Login ";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(from, pass);                  
                            smtp.Send(message);
                            ViewData["Message"] = "Verification Code sent successfully";
                            return RedirectToAction("VerifyUser", "Login");
                        }
                        catch (Exception ex)
                        {
                            ViewData["Message"] = "Error sending verification code: " + ex.Message;
                        }
                    }
                }
                else{
                    ViewData["Message"]="Check Your E-Mail";
                }
            }
            catch(Exception exception){
                ModelState.AddModelError(String.Empty,$"Something Went Wrong{exception.Message}"); 
            }
        }
        return View(login);
    }
    private string GetEmployeePassword(string userEmail)
    {
        return _dbContext.EmployeeDetails?
            .Where(c => c.EmployeeEmail == userEmail)
            .Select(c => c.EmployeePassword)
            .FirstOrDefault() ?? string.Empty;
    }

    private string GetManagerPassword(string userEmail)
    {
        return _dbContext.ManagerDetails?
            .Where(c => c.ManagerEmail == userEmail)
            .Select(c => c.ManagerPassword)
            .FirstOrDefault() ?? string.Empty;
    }

    private string GetRecruiterPassword(string userEmail)
    {
        return _dbContext.RecruiterDetails?
            .Where(c => c.RecruiterEmail == userEmail)
            .Select(c => c.RecruiterPassword)
            .FirstOrDefault() ?? string.Empty;
    }

    private string GetUserRole(string userEmail)
    {
        if (_dbContext.EmployeeDetails?.Any(c => c.EmployeeEmail == userEmail) ?? false)
        {
            return "Employee";
        }
        if (_dbContext.ManagerDetails?.Any(c => c.ManagerEmail == userEmail) ?? false)
        {
            return "Manager";
        }
        if (_dbContext.RecruiterDetails?.Any(c => c.RecruiterEmail == userEmail) ?? false)
        {
            return "Recruiter";
        }

        return "Unknown";
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}