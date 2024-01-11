using System.Security;
using System.Text.RegularExpressions;
public class Validation
{
    public bool validateName(string name)
    {
        Regex regex = new Regex(@"^[a-zA-Z]{1,44}$");
        return regex.IsMatch(name);
    }
    
    public bool validateNumber(string number)
    {
        Regex regex = new Regex(@"^+?[1-9][0-9]{9,11}$");
        return regex.IsMatch(number);
    }
    public bool validateEmail(string email)
    {
        Regex regex = new Regex(@"^([a-z\d\-]+)@([a-z\d-]+)\.([a-z]{2,8})(\.[a-z]{2,8})?$");
        return regex.IsMatch(email);
    }
    public bool validatePassword(string password)
    {
        Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,44}$");
        return regex.IsMatch(password);
    }


    public static SecureString maskInputString()
    {
        SecureString password = new SecureString();
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            if (!char.IsControl(keyInfo.KeyChar))
            {
                password.AppendChar(keyInfo.KeyChar);
                Console.Write("*");
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);
        {
            return password;
        }
    }
}
