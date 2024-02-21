using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Customer;
using Business.Responses.Customer;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager :ICustomerService
{
     private readonly ICustomerDal _customerDal;
    private readonly CustomerBusinessRules _customerBusinessRules;
    private readonly IMapper _mapper;

    public CustomerManager(ICustomerDal customerDal, CustomerBusinessRules customerBusinessRules, IMapper mapper)
    {
        _customerDal = customerDal;
        _customerBusinessRules = customerBusinessRules;
        _mapper = mapper;
    }

    public AddCustomerResponse Add(AddCustomerRequest request)
    {
       // ValidationTool.Validate(new AddModelRequestValidator(), request);
        _customerBusinessRules.CheckIfCustomerFirstNameExists(request.FirstName);
        _customerBusinessRules.CheckIfCustomerLastNameExists(request.LastName);
        var customerToAdd = _mapper.Map<Customer>(request);
        Customer addedCustomer = _customerDal.Add(customerToAdd);
        var response = _mapper.Map<AddCustomerResponse>(addedCustomer);
        return response;
    }

    public DeleteCustomerResponse Delete(DeleteCustomerRequest request)
    {
        Customer? customerToDelete = _customerDal.Get(predicate: customer => customer.Id == request.Id); // 0x123123
        _customerBusinessRules.CheckIfCustomerExists(customerToDelete); // 0x123123

        Customer deletedCustomer = _customerDal.Delete(customerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteCustomerResponse>(
            deletedCustomer // 0x123123
        );
        return response;
    }

    public GetCustomerListResponse GetList(GetCustomerListRequest request)
    {

        IList<Customer> customerList = _customerDal.GetList();

        // mapping & response
        var response = _mapper.Map<GetCustomerListResponse>(customerList);
        return response;
    }
    public GetCustomerByIdResponse GetById(GetCustomerByIdRequest request)
    {
        Customer? customer = _customerDal.Get(predicate: customer => customer.Id == request.Id);
        _customerBusinessRules.CheckIfCustomerExists(customer);

        var response = _mapper.Map<GetCustomerByIdResponse>(customer);
        return response;
    }
    public Customer? GetById(int id)
    {
        return _customerDal.Get(i => i.Id == id);
    }

    public UpdateCustomerResponse Update(UpdateCustomerRequest request)
    {
        Customer? customerToUpdate = _customerDal.Get(predicate: customer => customer.Id == request.Id); // 0x123123
        _customerBusinessRules.CheckIfCustomerExists(customerToUpdate);


        customerToUpdate = _mapper.Map(request, customerToUpdate); // 0x123123
        Customer updatedCustomer = _customerDal.Update(customerToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateCustomerResponse>(
            updatedCustomer // 0x123123
        );
        return response;
    }
}