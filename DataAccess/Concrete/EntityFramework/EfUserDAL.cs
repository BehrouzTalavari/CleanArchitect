using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDAL:EfEntityRepositoryBase<User, EShopContext>,IUserDAL
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using var context = new EShopContext();

            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select operationClaim;

            return result.ToList();
        }
    }
}
