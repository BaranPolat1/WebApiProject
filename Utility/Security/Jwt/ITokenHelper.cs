using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Security.Jwt
{
   public interface ITokenHelper
    {
        AccesToken CreateToken(AppUser user);
        

    }
}
