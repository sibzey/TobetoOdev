namespace Business.Dtos.Car;

public class CarListItemDto
{
    public int ModelId { get; set; }
    public string ModelName { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public int TransmissionId { get; set; }
    public string TransmissionName { get; set; }
    public int FuelId { get; set; }
    public string FuelName { get; set; }
    public decimal Price { get; set; }
    public short Year { get; set; }
}