using Core.Entities;

namespace Entities.Concrete;

public class IndividualCustomer: Entity<int>
{
    public int CustomerId;
    public string FirstName;
    public string LastName;
   
    public IndividualCustomer()
    {
        
    }

    public IndividualCustomer(int customerid,string firstname, string lastname)
    {
        CustomerId = customerid;
        FirstName = firstname;
        LastName = lastname;
        
    }
}