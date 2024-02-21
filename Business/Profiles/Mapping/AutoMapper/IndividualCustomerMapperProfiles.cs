using AutoMapper;
using Business.Dtos.IndividualCustomer;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class IndividualCustomerMapperProfiles :Profile
{
    public IndividualCustomerMapperProfiles()
    {
        CreateMap<AddIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, AddIndividualCustomerResponse>();

        CreateMap<IndividualCustomer, IndividualCustomerListItemDto>();
        CreateMap<IList<IndividualCustomer>, GetIndividualCustomerListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<IndividualCustomer, DeleteIndividualCustomerResponse>();

        CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
    }
   
}