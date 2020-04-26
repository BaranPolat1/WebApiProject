using Business.Contants;
using Business.Services.Abstract;
using DataAccess.Repository.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Utility.Result;
using Utility.Result.SuccessResult;

namespace Business.Services.Concrete
{
    public class PostService : IPostService
    {
        private IPostRepository _postService;
        public PostService(IPostRepository postService)
        {
            _postService = postService;
        }
        public IResult Add(Post post)
        {
            _postService.Add(post);
            return new SuccesResult(Messages.AddedPost);
        }

       

        public IResult Delete(Post post)
        {
            _postService.Delete(post);
            return new SuccesResult(Messages.DeletedPost);
        }

        public IDataResult<IList<Post>> GetByAuthor(int appUserId)
        {
            return new SuccessDataResult<IList<Post>>(_postService.GetList(x=>x.AppUserId == appUserId));
        }

        public IDataResult<IList<Post>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<IList<Post>>(_postService.GetList(x => x.CategoryId == categoryId));
        }

        public IDataResult<Post> GetById(int Id)
        {
            return new SuccessDataResult<Post>(_postService.Get(x => x.Id == Id));
        }

        public IDataResult<IList<Post>> GetList()
        {
            return new SuccessDataResult<IList<Post>>(_postService.GetList());
        }

        public IResult Update(Post post)
        {
           _postService.Update(post);
            return new SuccesResult(Messages.UpdatedPost);
        }
    }
}
