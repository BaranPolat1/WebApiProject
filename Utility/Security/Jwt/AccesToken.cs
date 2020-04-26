using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Security.Jwt
{
    public class AccesToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
