using Core.Entities;

namespace Entities.Concrete;

public class CorporateCustomer:Entity<int>
{
    public int CustomerId;
    public string FirstName;
    public string LastName;
   
    public CorporateCustomer()
    {
        
    }

    public CorporateCustomer(int customerid, string firstname, string lastname)
    {
        CustomerId = customerid;
        FirstName = firstname;
        LastName = lastname;
       
    }
    
}