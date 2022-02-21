using Core.Entities.Concrere;
using System.Collections.Generic;

namespace Core.Utility.Jwt
{
    public interface ITokenHelper
    {
        AccessToken Create(User user,List<OperationClaim> operationClaims);
    }
}
