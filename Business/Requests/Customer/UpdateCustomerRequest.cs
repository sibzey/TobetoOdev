namespace Business.Requests.Customer;

public class UpdateCustomerRequest
{
    public int Id { get; set; }
    public string FirstName;
    public string LastName;
    public object Email;
    public int Password;
}