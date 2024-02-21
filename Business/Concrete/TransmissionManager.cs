using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransmissionManager :ITransmissionService
{
    private readonly ITransmissionDal _transmissionDal; // Bir entity service'i kendi entitysi dışında hiç bir entity'nin DAL'ını injekte etmemelidir.
    private readonly TransmissionBusinessRules _transmissionBusinessRules;
    private readonly IMapper _mapper;

    public TransmissionManager(ITransmissionDal transmissionDal,TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
    {
        _transmissionDal = transmissionDal;
        _transmissionBusinessRules = transmissionBusinessRules;
        _mapper = mapper;
    }
    public GetTransmissionListResponse GetList(GetTransmissionListRequest request)
    {
        IList<Transmission> transmissionList = _transmissionDal.GetList(); 
        GetTransmissionListResponse response = _mapper.Map<GetTransmissionListResponse>(transmissionList); // Mapping
        return response;
    }

    public AddTransmissionResponse Add(AddTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfTransmissionNameNotExists(request.Name);
        Transmission transmissionToAdd = _mapper.Map<Transmission>(request); 
        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }
}