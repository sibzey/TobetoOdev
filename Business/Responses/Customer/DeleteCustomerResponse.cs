namespace Business.Responses.Customer;

public class DeleteCustomerResponse
{
    public int Id { get; set; }
    public string FirstName;
    public string LastName;
    public DateTime DeletedAt { get; set; }
}