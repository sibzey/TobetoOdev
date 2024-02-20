using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfTransmissionDal: EfEntityRepositoryBase<Transmission, int, RentACarContext>
{
    public EfTransmissionDal(RentACarContext context) : base(context)
    {
    }
}