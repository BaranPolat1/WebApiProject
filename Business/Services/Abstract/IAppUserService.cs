using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Result;

namespace Business.Services.Abstract
{
    public interface IAppUserService
    {
        IDataResult<IList<AppUser>> GetList();
        IResult Add(AppUser appUser);
        IResult Delete(AppUser appUser);
        IResult Update(AppUser appUser);
        IDataResult<AppUser> GetById(int Id);
        bool CheckCredentials(string userName, string password);
        IDataResult<AppUser> FindByUserName(string userName);
        IDataResult<AppUser> GetByMail(string eMail);
    }
}
