using System.ComponentModel.DataAnnotations;

namespace Angularapi.Models;
public class Checkout
{
    public string Address {get; set;}
    public int PhoneNumber{get;set;}
    public string PaymentMethod {get;set;}
    public string Name { get; set; }
}