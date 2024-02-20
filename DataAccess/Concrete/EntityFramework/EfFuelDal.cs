using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfFuelDal: EfEntityRepositoryBase<Fuel,int,RentACarContext>
{
    public EfFuelDal(RentACarContext context) : base(context)
    {
    }
}