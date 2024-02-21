using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class CustomerBusinessRules
{
    private readonly ICustomerDal _customerDal;
    

    public CustomerBusinessRules(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public void CheckIfCustomerFirstNameExists(string firstname)
    {
        bool isFirstNameExists = _customerDal.Get(m => m.FirstName == firstname) != null;
        if (isFirstNameExists)
            throw new BusinessException("Customer first name already exists.");
    }
    public void CheckIfCustomerLastNameExists(string lastname)
    {
        bool isLastNameExists = _customerDal.Get(m => m.LastName == lastname) != null;
        if (isLastNameExists)
            throw new BusinessException("Customer last name already exists.");
    }

    public void CheckIfCustomerExists(Customer? customer)
    {
        if (customer is null)
            throw new NotFoundException("Customer is not found.");
    }
    
  
}