using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserRoleDal: EfEntityRepositoryBase<UserRole, int, RentACarContext>, IUserRoleDal
{
    public EfUserRoleDal(RentACarContext context) : base(context)
    {
    }
    
}