using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class FuelBusinessRules
{
    private readonly IFuelDal _fuelDal;

    public FuelBusinessRules(IFuelDal fuelDal)
    {
        _fuelDal = fuelDal;
    }

    public void CheckIfFuelNameNotExists(string fuelName)
    {
        bool isExists = _fuelDal.Get(fuel => fuel.Name == fuelName) is not null;
        if (isExists)
        {
            throw new BusinessException("Fuel already exists.");
        }
    } 
}