using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Utility.Result;

namespace Business.Services.Abstract
{
   public interface IPostService
    {
        IDataResult<IList<Post>> GetList();
        IDataResult<IList<Post>> GetByCategory(int categoryId);
        IDataResult<IList<Post>> GetByAuthor(int appUserId);
        IResult Add(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<Post> GetById(int Id);
        
      
    }
}
