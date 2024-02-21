using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager :IFuelService
{
    private readonly IFuelDal _fuelDal; // Bir entity service'i kendi entitysi dışında hiç bir entity'nin DAL'ını injekte etmemelidir.
    private readonly FuelBusinessRules _fuelBusinessRules;
    private readonly IMapper _mapper;

    public FuelManager(IFuelDal fuelDal,FuelBusinessRules fuelBusinessRules, IMapper mapper)
    {
        _fuelDal = fuelDal;
        _fuelBusinessRules = fuelBusinessRules;
        _mapper = mapper;
    }
    public GetFuelListResponse GetList(GetFuelListRequest request)
    {
        IList<Fuel> fuelList = _fuelDal.GetList(); 
        GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(fuelList); // Mapping
        return response;
    }

    public AddFuelResponse Add(AddFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelNameNotExists(request.Name);
        Fuel fuelToAdd = _mapper.Map<Fuel>(request); 
        _fuelDal.Add(fuelToAdd);

        AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
        return response;
    }
}