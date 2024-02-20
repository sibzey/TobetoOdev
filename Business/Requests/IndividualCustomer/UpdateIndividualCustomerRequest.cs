namespace Business.Requests.IndividualCustomer;

public class UpdateIndividualCustomerRequest
{
    public int Id { get; set; }
    public int CustomerId;
    public string FirstName;
    public string LastName;
}