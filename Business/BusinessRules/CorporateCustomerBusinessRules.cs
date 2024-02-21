using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerDal _corporateCustomerDal;
    private readonly ICustomerService _customerService;


    public CorporateCustomerBusinessRules(ICorporateCustomerDal corporateCustomerDal,ICustomerService customerService )
    {
        _corporateCustomerDal = corporateCustomerDal;
        _customerService = customerService;

    }

    public void CheckIfCorporateCustomerFirstNameExists(string firstname)
    {
        bool isFirstNameExists = _corporateCustomerDal.Get(m => m.FirstName == firstname) != null;
        if (isFirstNameExists)
            throw new BusinessException("Corporate customer's first name already exists.");
    }
    public void CheckIfCorporateCustomerLastNameExists(string lastname)
    {
        bool isLastNameExists = _corporateCustomerDal.Get(m => m.LastName == lastname) != null;
        if (isLastNameExists)
            throw new BusinessException("CorporateCustomer's last name already exists.");
    }

    public void CheckIfCorporateCustomerExists(CorporateCustomer? corporateCustomer)
    {
        if (corporateCustomer is null)
            throw new NotFoundException("Corporate Customer not found.");
    }

   
    public void CheckIfCustomerExists(int customerId)
    {

        Customer? customer = _customerService.GetById(customerId);
        if (customer is null)
            throw new Exception("Böyle bir müşteri yok.");
    }
}