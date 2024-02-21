using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class CarBusinessRules
{
    private readonly ICarDal _carDal;
    private readonly IBrandService _brandService;
    private readonly IModelService _modelService;
    public CarBusinessRules(ICarDal carDal, IBrandService brandService,IModelService modelService )
    {
        _carDal = carDal;
        _brandService = brandService;
        _modelService = modelService;

    }

    public void CheckIfCarExists(Car? car)
    {
        if (car is null)
            throw new NotFoundException("Car is not found.");
    }

    public void CheckIfModelExists(int modelId)
    {

        Model? model = _modelService.GetById(modelId);
        if (model is null)
            throw new Exception("Böyle bir model yok.");
    }
    public void CheckIfBrandExists(int brandId)
    {

        Brand? brand = _brandService.GetById(brandId);
        if (brand is null)
            throw new Exception("Böyle bir marka yok.");
    }
}