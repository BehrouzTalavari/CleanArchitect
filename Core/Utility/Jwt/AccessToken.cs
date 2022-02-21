using System;

namespace Core.Utility.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
