using Core.Entities;

namespace Entities.Concrete;

public class Car:Entity<int>
{
    public int ModelId { get; set; }
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public short Year { get; set; }

    public Car()
    {
        
    }

    public Car(int modelid, int brandid, decimal price, short year)
    {
        ModelId = modelid;
        BrandId = brandid;
        Price = price;
        Year = year;
    }
}