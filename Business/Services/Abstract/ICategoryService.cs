using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Result;

namespace Business.Services.Abstract
{
   public interface ICategoryService
    {
        IDataResult<IList<Category>> GetList();
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<Category> GetById(int Id);
    }
}
