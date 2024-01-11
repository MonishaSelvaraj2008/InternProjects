using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Angularapi.Models;

namespace Angularapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckoutController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public CheckoutController(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }
    [HttpGet]
    public JsonResult Get()
    {

        string query = @"
                                select Name, Address, PhoneNumber, PaymentMethod from
                                dbo.Checkout";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult(table);
    }

    [HttpPost]
    public JsonResult Post(Checkout checkout)
    {

        string query = @"
                         insert into 
                         dbo.Checkout(Name, Address,PhoneNumber, PaymentMethod)
                          values(@Name, @Address, @PhoneNumber, @PaymentMethod)";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", checkout.Name);
                myCommand.Parameters.AddWithValue("@Address", checkout.Address);
                myCommand.Parameters.AddWithValue("@PhoneNumber", checkout.PhoneNumber);
                myCommand.Parameters.AddWithValue("@PaymentMethod", checkout.PaymentMethod);

                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult("Added Succesfully");
    }


    [HttpPut]
    public JsonResult Put(Checkout checkout)
    {

        string query = @"
                         update 
                         dbo.Checkouts 
                         set Name=@Name,
                          Address =  @Address,
                          PhoneNumber = @PhoneNumber,
                          PaymentMethod = @PaymentMethod"
                        ;

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", checkout.Name);
                myCommand.Parameters.AddWithValue("@Address", checkout.Address);
                myCommand.Parameters.AddWithValue("@PhoneNumber", checkout.PhoneNumber);
                myCommand.Parameters.AddWithValue("@PaymentMethod", checkout.PaymentMethod);


                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult("Updated Succesfully");
    }
}