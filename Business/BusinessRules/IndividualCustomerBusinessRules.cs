using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerDal _individualCustomerDal;
    private readonly ICustomerService _customerService;


    public IndividualCustomerBusinessRules(IIndividualCustomerDal individualCustomerDal,ICustomerService customerService )
    {
        _individualCustomerDal = individualCustomerDal;
        _customerService = customerService;

    }

    public void CheckIfIndividualCustomerFirstNameExists(string firstname)
    {
        bool isFirstNameExists = _individualCustomerDal.Get(m => m.FirstName == firstname) != null;
        if (isFirstNameExists)
            throw new BusinessException("Individual customer's first name already exists.");
    }
    public void CheckIfIndividualCustomerLastNameExists(string lastname)
    {
        bool isLastNameExists = _individualCustomerDal.Get(m => m.LastName == lastname) != null;
        if (isLastNameExists)
            throw new BusinessException("Individual Customer's last name already exists.");
    }

    public void CheckIfIndividualCustomerExists(IndividualCustomer? individualCustomer)
    {
        if (individualCustomer is null)
            throw new NotFoundException("Individual Customer not found.");
    }

   
    public void CheckIfCustomerExists(int customerId)
    {

        Customer? customer = _customerService.GetById(customerId);
        if (customer is null)
            throw new Exception("Böyle bir müşteri yok.");
    }
}