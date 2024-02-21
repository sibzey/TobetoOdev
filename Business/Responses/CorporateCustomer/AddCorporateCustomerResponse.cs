namespace Business.Responses.CorporateCustomer;

public class AddCorporateCustomerResponse
{
    public int CustomerId;
    public string FirstName;
    public string LastName;
    public DateTime CreatedAt { get; set; }
}