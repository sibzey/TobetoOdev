using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CorporateCustomerManager :ICorporateCustomerService
{
    private readonly ICorporateCustomerDal _corporateCustomerDal;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
    private readonly IMapper _mapper;

    public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal, CorporateCustomerBusinessRules corporateCustomerBusinessRules,IMapper mapper)
    {
        _corporateCustomerDal = corporateCustomerDal;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        _mapper = mapper;
    }
    public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request)
    {
        IList<CorporateCustomer> corporateCustomerList = _corporateCustomerDal.GetList(
            predicate: corporateCustomer =>
                (request.FilterByCustomerId == null || corporateCustomer.CustomerId == request.FilterByCustomerId)
        );

        // mapping & response
        var response = _mapper.Map<GetCorporateCustomerListResponse>(corporateCustomerList);
        return response;
    }

    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
    {
        _corporateCustomerBusinessRules.CheckIfCorporateCustomerFirstNameExists(request.FirstName);
        _corporateCustomerBusinessRules.CheckIfCorporateCustomerLastNameExists(request.LastName);
        _corporateCustomerBusinessRules.CheckIfCustomerExists(request.CustomerId);
        var corporateCustomerToAdd = _mapper.Map<CorporateCustomer>(request);
        CorporateCustomer addedCorporateCustomer = _corporateCustomerDal.Add(corporateCustomerToAdd);
        var response = _mapper.Map<AddCorporateCustomerResponse>(addedCorporateCustomer);
        return response;
    }

    public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request)
    {
        CorporateCustomer? corporateCustomerToUpdate = _corporateCustomerDal.Get(predicate: corporateCustomer => corporateCustomer.Id == request.Id); // 0x123123
        _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToUpdate);
        _corporateCustomerBusinessRules.CheckIfCustomerExists(request.CustomerId);
        

        corporateCustomerToUpdate = _mapper.Map(request, corporateCustomerToUpdate); // 0x123123
        CorporateCustomer updatedCorporateCustomer = _corporateCustomerDal.Update(corporateCustomerToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateCorporateCustomerResponse>(
            updatedCorporateCustomer // 0x123123
        );
        return response; 
    }

    public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
    {
        CorporateCustomer? corporateCustomerToDelete = _corporateCustomerDal.Get(predicate: corporateCustomer => corporateCustomer.Id == request.Id); // 0x123123
        _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToDelete); // 0x123123

        CorporateCustomer deletedCorporateCustomer = _corporateCustomerDal.Delete(corporateCustomerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteCorporateCustomerResponse>(
            deletedCorporateCustomer // 0x123123
        );
        return response;
    }
}