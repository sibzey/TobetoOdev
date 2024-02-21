namespace Business.Responses.Car;

public class GetCarByIdResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public int BrandId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public decimal Price { get; set; }
    public short Year { get; set; }
    
}