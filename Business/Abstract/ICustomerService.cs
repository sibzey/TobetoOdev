using Business.Requests.Customer;
using Business.Responses.Customer;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomerService
{
    public GetCustomerListResponse GetList(GetCustomerListRequest request);

    public GetCustomerByIdResponse GetById(GetCustomerByIdRequest request);

    public AddCustomerResponse Add(AddCustomerRequest request);

    public UpdateCustomerResponse Update(UpdateCustomerRequest request);

    public DeleteCustomerResponse Delete(DeleteCustomerRequest request);
    Customer? GetById(int id); //TODO: Replace with DTO
}