using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager :ICarService
{
    private readonly ICarDal _carDal;
    private readonly CarBusinessRules _carBusinessRules;
    private readonly IMapper _mapper;

    public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules, IMapper mapper)
    {
        _carDal = carDal;
        _carBusinessRules = carBusinessRules;
        _mapper = mapper;
    }

    public AddCarResponse Add(AddCarRequest request)
    {
        _carBusinessRules.CheckIfBrandExists(request.BrandId);
        _carBusinessRules.CheckIfModelExists(request.ModelId);
        
        var carToAdd = _mapper.Map<Car>(request);
        Car addedCar = _carDal.Add(carToAdd);
        var response = _mapper.Map<AddCarResponse>(addedCar);
        return response;
    }

    public DeleteCarResponse Delete(DeleteCarRequest request)
    {
        Car? carToDelete = _carDal.Get(predicate: car => car.Id == request.Id); // 0x123123
        _carBusinessRules.CheckIfCarExists(carToDelete); // 0x123123

        Car deletedCar = _carDal.Delete(carToDelete!); // 0x123123

        var response = _mapper.Map<DeleteCarResponse>(
            deletedCar // 0x123123
        );
        return response;
    }

    public GetCarByIdResponse GetById(GetCarByIdRequest request)
    {
        Car? car = _carDal.Get(predicate: car => car.Id == request.Id);
        _carBusinessRules.CheckIfCarExists(car);

        var response = _mapper.Map<GetCarByIdResponse>(car);
        return response;
    }

    public GetCarListResponse GetList(GetCarListRequest request)
    {
        IList<Car> carList = _carDal.GetList(
            predicate: car =>
                (request.FilterByBrandId == null || car.BrandId == request.FilterByBrandId)
                && (request.FilterByFuelId == null || car.FuelId == request.FilterByFuelId)
                && (request.FilterByTransmissionId == null || car.TransmissionId == request.FilterByTransmissionId)
                && (request.FilterByModelId == null || car.BrandId == request.FilterByModelId)
        );

        // mapping & response
        var response = _mapper.Map<GetCarListResponse>(carList);
        return response;
    }
    
    public UpdateCarResponse Update(UpdateCarRequest request)
    {
        Car? carToUpdate = _carDal.Get(predicate: car => car.Id == request.Id); // 0x123123
        _carBusinessRules.CheckIfCarExists(carToUpdate);
        _carBusinessRules.CheckIfBrandExists(request.BrandId);
        _carBusinessRules.CheckIfModelExists(request.ModelId);

        carToUpdate = _mapper.Map(request, carToUpdate); // 0x123123
        Car updatedCar = _carDal.Update(carToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateCarResponse>(
            updatedCar // 0x123123
        );
        return response;
    }
    
}