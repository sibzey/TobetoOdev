namespace Business.Responses.CorporateCustomer;

public class UpdateCorporateCustomerResponse
{
    public int Id { get; set; }
    public int CustomerId;
    public string FirstName;
    public string LastName;
    public DateTime UpdatedAt { get; set; }
}