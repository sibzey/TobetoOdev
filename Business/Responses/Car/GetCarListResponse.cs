using Business.Dtos.Car;

namespace Business.Responses.Car;

public class GetCarListResponse
{
    public ICollection<CarListItemDto> Items { get; set; }
}