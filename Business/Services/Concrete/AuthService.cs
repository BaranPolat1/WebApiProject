using Business.Contants;
using Business.Services.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Auth.VM;
using Utility.Result;
using Utility.Result.ErrorResult;
using Utility.Result.SuccessResult;
using Utility.Security.Hashing;
using Utility.Security.Jwt;

namespace Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private IAppUserService userService;
        private ITokenHelper tokenHelper;
        public AuthService(IAppUserService _userService, ITokenHelper _tokenHelper)
        {
            userService = _userService;
            tokenHelper = _tokenHelper;
        }
        public IDataResult<AccesToken> CreateAccesToken(AppUser appUser)
        {
          var accestoken=  tokenHelper.CreateToken(appUser);
            return new SuccessDataResult<AccesToken>(accestoken, Messages.AccesTokenHasCreated);
        }

        public IDataResult<AppUser> GetByEmail(string eMail)
        {
            return userService.GetByMail(eMail);
        }

        public IDataResult<AppUser> Login(LoginVM loginVM)
        {
            var userCheck = userService.GetByMail(loginVM.Email);

            if (userCheck == null)
            {
                return new ErrorDataResult<AppUser>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(loginVM.Password,userCheck.Data.passwordhash,userCheck.Data.passwordsalt))
            {
                return new ErrorDataResult<AppUser>(Messages.PasswordError);
            }
            return new SuccessDataResult<AppUser>(userCheck.Data);
        }

        

        public IDataResult<AppUser> Register(RegisterVM register, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new AppUser
            {
                Email = register.Email,
                FullName = register.FullName,
                UserName = register.UserName,
                passwordhash = passwordHash,
                passwordsalt = passwordSalt,
                Status = 0

            };
            userService.Add(user);
            return new SuccessDataResult<AppUser>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string eMail)
        {
            if (userService.GetByMail(eMail)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccesResult();
        }
    }
}
