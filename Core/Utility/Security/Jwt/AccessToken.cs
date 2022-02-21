using System;

namespace Core.Utility.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
