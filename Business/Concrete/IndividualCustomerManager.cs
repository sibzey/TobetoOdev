using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class IndividualCustomerManager: IIndividualCustomerService
{
    private readonly IIndividualCustomerDal _individualCustomerDal;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
    private readonly IMapper _mapper;

    public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal, IndividualCustomerBusinessRules individualCustomerBusinessRules,IMapper mapper)
    {
        _individualCustomerDal = individualCustomerDal;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
        _mapper = mapper;
    }
    public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request)
    {
        IList<IndividualCustomer> individualCustomerList = _individualCustomerDal.GetList(
            predicate: individualCustomer =>
                (request.FilterByCustomerId == null || individualCustomer.CustomerId == request.FilterByCustomerId)
        );

        // mapping & response
        var response = _mapper.Map<GetIndividualCustomerListResponse>(individualCustomerList);
        return response;
    }

    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
    {
        _individualCustomerBusinessRules.CheckIfIndividualCustomerFirstNameExists(request.FirstName);
        _individualCustomerBusinessRules.CheckIfIndividualCustomerLastNameExists(request.LastName);
        _individualCustomerBusinessRules.CheckIfCustomerExists(request.CustomerId);
        var individualCustomerToAdd = _mapper.Map<IndividualCustomer>(request);
        IndividualCustomer addedIndividualCustomer = _individualCustomerDal.Add(individualCustomerToAdd);
        var response = _mapper.Map<AddIndividualCustomerResponse>(addedIndividualCustomer);
        return response;
    }

    public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request)
    {
        IndividualCustomer? individualCustomerToUpdate = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id); // 0x123123
        _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToUpdate);
        _individualCustomerBusinessRules.CheckIfCustomerExists(request.CustomerId);
        

        individualCustomerToUpdate = _mapper.Map(request, individualCustomerToUpdate); // 0x123123
        IndividualCustomer updatedIndividualCustomer = _individualCustomerDal.Update(individualCustomerToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateIndividualCustomerResponse>(
            updatedIndividualCustomer // 0x123123
        );
        return response; 
    }

    public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request)
    {
        IndividualCustomer? individualCustomerToDelete = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id); // 0x123123
        _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToDelete); // 0x123123

        IndividualCustomer deletedIndividualCustomer = _individualCustomerDal.Delete(individualCustomerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteIndividualCustomerResponse>(
            deletedIndividualCustomer // 0x123123
        );
        return response;  
}
    }