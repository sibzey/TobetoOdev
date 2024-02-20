using Core.Entities;

namespace Entities.Concrete;

public class Customer: Entity<int>
{
    public string FirstName;
    public string LastName;
    public object Email;
    public int Password;

    public Customer()
    {
        
    }

    public Customer(string firstname, string lastname, object email, int password)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Password = password;

    }
}
