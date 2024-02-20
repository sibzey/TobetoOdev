using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfIndıvidualCustomerDal: EfEntityRepositoryBase<IndividualCustomer,int,RentACarContext>,IIndividualCustomerDal
{
    public EfIndıvidualCustomerDal(RentACarContext context) : base(context)
    {
    }
}