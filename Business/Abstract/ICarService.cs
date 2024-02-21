using Business.Requests.Car;
using Business.Responses.Car;

namespace Business.Abstract;

public interface ICarService
{
    public GetCarListResponse GetList(GetCarListRequest request);

    public GetCarByIdResponse GetById(GetCarByIdRequest request);

    public AddCarResponse Add(AddCarRequest request);

    public UpdateCarResponse Update(UpdateCarRequest request);

    public DeleteCarResponse Delete(DeleteCarRequest request);
}