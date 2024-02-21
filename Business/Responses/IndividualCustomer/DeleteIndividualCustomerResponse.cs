namespace Business.Responses.IndividualCustomer;

public class DeleteIndividualCustomerResponse
{
    public int Id { get; set; }
    public int CustomerId;
    public string FirstName;
    public string LastName;
    public DateTime DeletedAt { get; set; }}