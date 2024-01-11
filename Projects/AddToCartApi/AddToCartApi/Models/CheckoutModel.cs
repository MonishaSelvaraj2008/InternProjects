// CheckoutModel.cs
using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AddToCartApi.Models
{
    public class CheckoutModel
    {
       
        
        public string phoneNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
       
        public string email { get; set; }
        public string address { get; set; }
      
    }
}
