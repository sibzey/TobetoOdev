using Business.Requests.Fuel;
using Business.Responses.Fuel;

namespace Business.Abstract;

public interface IFuelService
{
    public GetFuelListResponse GetList(GetFuelListRequest request);
    public AddFuelResponse Add(AddFuelRequest request);

}