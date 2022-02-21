using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetByMail(string email);
        void Add(User user);
        List<OperationClaim> GetClaims(User user);
    }
}
