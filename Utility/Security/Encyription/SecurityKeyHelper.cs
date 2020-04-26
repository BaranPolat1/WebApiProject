using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Security.Encyription
{
   public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));

        }
    }
}
