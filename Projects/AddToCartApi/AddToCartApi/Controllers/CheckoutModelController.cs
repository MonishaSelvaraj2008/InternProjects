// CheckoutController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using AddToCartApi.Data; 
using AddToCartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AddToCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CheckoutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult>  Post([FromForm] CheckoutModel checkoutModels)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { errors = errors.ToList() });
            }
            if(_dbContext.Checkout_Details!=null){
            _dbContext.Checkout_Details.Add(checkoutModels);}
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
        
       
    