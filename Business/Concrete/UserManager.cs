using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDAL.GetClaim(user);
        }
        public void Add(User user)
        {
            _userDAL.Add(user);
        }
        public User GetByMail(string email)
        {
            return _userDAL.Get(u => u.Email.Contains(email));
        }
    }
}
