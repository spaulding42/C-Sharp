namespace ViewModel_Fun.Models;
#pragma warning disable CS8618
public class User
{
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public User(string firstName)
    {
        FirstName = firstName;
        LastName = "";
    }

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}