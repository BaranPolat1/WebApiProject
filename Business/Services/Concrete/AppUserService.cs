using Business.Contants;
using Business.Services.Abstract;
using DataAccess.Repository.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Result;
using Utility.Result.SuccessResult;

namespace Business.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _userRepository;
        public AppUserService(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult Add(AppUser appUser)
        {
            _userRepository.Add(appUser);
            return new SuccesResult(Messages.AddedUser);
        }

        public bool CheckCredentials(string userName, string password)
        {
            return _userRepository.Any(x => x.UserName == userName && x.Password == password);
        }

        public IResult Delete(AppUser appUser)
        {
            _userRepository.Delete(appUser);
            return new SuccesResult(Messages.DeletedUser);
        }

        public IDataResult<AppUser> FindByUserName(string userName)
        {
            return new SuccessDataResult<AppUser>(_userRepository.Get(x => x.UserName == userName)) ;
        }

        public IDataResult<AppUser> GetById(int Id)
        {
            return new SuccessDataResult<AppUser>(_userRepository.Get(x => x.Id == Id));
        }

        public IDataResult<AppUser> GetByMail(string eMail)
        {
            return new SuccessDataResult<AppUser>(_userRepository.Get(x=>x.Email == eMail));
        }

        public IDataResult<IList<AppUser>> GetList()
        {
            return new SuccessDataResult<IList<AppUser>>(_userRepository.GetList());
        }

        public IResult Update(AppUser appUser)
        {
            _userRepository.Update(appUser);
            return new SuccesResult(Messages.UpdatedUser);
        }
    }
}
