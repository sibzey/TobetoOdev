namespace Business.Requests.CorporateCustomer;

public class UpdateCorporateCustomerRequest
{
    public int Id { get; set; }
    public int CustomerId;
    public string FirstName;
    public string LastName;
}