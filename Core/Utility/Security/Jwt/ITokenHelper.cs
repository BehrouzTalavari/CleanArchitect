using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Utility.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
        JwtSecurityToken CreateSecurityToken(User user, SigningCredentials signingCredential, List<OperationClaim> operationClaims);
    }
}
