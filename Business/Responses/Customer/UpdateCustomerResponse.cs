namespace Business.Responses.Customer;

public class UpdateCustomerResponse
{
    public int Id { get; set; }
    public string FirstName;
    public string LastName;
    public object Email;
    public int Password;
    public DateTime UpdatedAt { get; set; }
}