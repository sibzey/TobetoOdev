using Business.Dtos.Customer;

namespace Business.Responses.Customer;

public class GetCustomerListResponse
{
    public ICollection<CustomerListItemDto> Items { get; set; }
}