using AutoMapper;
using Business.Dtos.Car;
using Business.Requests.Car;
using Business.Responses.Car;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CarMapperProfiles :Profile
{
    public CarMapperProfiles()
    {
        CreateMap<AddCarRequest, Car>();
        CreateMap<Car, AddCarResponse>();

        CreateMap<Car, CarListItemDto>();
        CreateMap<IList<Car>, GetCarListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<Car, DeleteCarResponse>();

        CreateMap<Car, GetCarByIdResponse>();

        CreateMap<UpdateCarRequest, Car>();
        CreateMap<Car, UpdateCarResponse>();
    }
}