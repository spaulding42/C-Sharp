namespace Random_Passcode.Controllers;
#pragma warning disable CS8618


public class RandomPassword
{
    public string Password {get;set;}

    public RandomPassword()
    {
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
        string newPass = "";
        while (newPass.Length <14)
        {
            Random rand = new Random();
            int newrand = rand.Next(0,70);
            newPass += chars[newrand];
        }
        Password = newPass;
    }
}