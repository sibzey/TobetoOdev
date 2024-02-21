namespace Business.Responses.IndividualCustomer;

public class AddIndividualCustomerResponse
{
    public int CustomerId;
    public string FirstName;
    public string LastName;
    public DateTime CreatedAt { get; set; }
}