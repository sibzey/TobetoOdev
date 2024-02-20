using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

internal class EfBrandDal : EfEntityRepositoryBase<Brand, int,RentACarContext>,IBrandDal
{
    public EfBrandDal(RentACarContext context) : base(context)
    {
    }
}
   
}
