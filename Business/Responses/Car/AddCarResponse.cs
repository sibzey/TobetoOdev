namespace Business.Responses.Car;

public class AddCarResponse
{
    public int ModelId { get; set; }
    public int BrandId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public decimal Price { get; set; }
    public short Year { get; set; }
    public DateTime CreatedAt { get; set; }
}