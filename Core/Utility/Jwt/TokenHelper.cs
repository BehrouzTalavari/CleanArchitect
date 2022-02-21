using Core.ClaimExtensions;
using Core.Entities.Concrere;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utility.Jwt
{
    public class TokenHelper : ITokenHelper
    {
        private IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOption = _configuration.GetSection("TokenOption").Get<TokenOption>();
        }

        private DateTime _accessTokenExpiration;
        private TokenOption _tokenOption;

        public AccessToken Create(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = new DateTime().AddMinutes(_tokenOption.AccessTokenExpiration);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateSecurityToken(user, signingCredential, operationClaims);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                ExpireTime = _accessTokenExpiration,
                Token = token
            };
        }
        public JwtSecurityToken CreateSecurityToken(User user, SigningCredentials signingCredential, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                expires: _accessTokenExpiration,
                notBefore: System.DateTime.Now,
                claims: setClaims(user, operationClaims),
                signingCredentials: signingCredential);
            return jwt;
        }
        private IEnumerable<Claim> setClaims(User user, List<OperationClaim> userOperationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName}.{user.LastName}");
            claims.AddRole(userOperationClaims.Select(x => x.Name).ToArray());

            return claims;
        }
    }
}
