namespace Business.Requests.Car;

public class GetCarListRequest
{
    public int? FilterByModelId { get; set; }
    public int? FilterByBrandId { get; set; }
    public int? FilterByFuelId { get; set; }
    public int? FilterByTransmissionId { get; set; }
}