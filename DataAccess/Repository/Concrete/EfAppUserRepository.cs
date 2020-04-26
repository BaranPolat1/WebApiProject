using Core.Repository.Concrete;
using DAL.Context;
using DataAccess.Repository.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Concrete
{
   public class EfAppUserRepository:EfEntityRepositoryBase<AppUser,ProjectContext>,IAppUserRepository
    {
        
    }
}
