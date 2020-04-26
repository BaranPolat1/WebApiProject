using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Auth.VM;
using Utility.Result;
using Utility.Security.Jwt;

namespace Business.Services.Abstract
{
   public interface IAuthService
    {
        IDataResult<AppUser> Register(RegisterVM register, string password);
        IDataResult<AppUser> Login(LoginVM loginVM);
        IResult UserExist(string eMail);
        IDataResult<AccesToken> CreateAccesToken(AppUser appUser);
        IDataResult<AppUser> GetByEmail(string eMail);


    }
}
