﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Utility.Exceptions
{
    public static class ClaimsPrincipalesExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal.Claims(ClaimTypes.Role);
    }
}
