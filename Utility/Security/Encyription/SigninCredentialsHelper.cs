using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Security.Encyription
{
    public class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
