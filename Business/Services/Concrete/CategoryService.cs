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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryService;
        public CategoryService(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public IResult Add(Category category)
        {
            _categoryService.Add(category);
            return new SuccesResult(Messages.AddedCategory);
        }

        public IResult Delete(Category category)
        {
            _categoryService.Delete(category);
            return new SuccesResult(Messages.DeletedCategory);
        }

        public IDataResult<Category> GetById(int Id)
        {
            return new SuccessDataResult<Category>(_categoryService.Get(x=>x.Id == Id));
        }

        public IDataResult<IList<Category>> GetList()
        {
            return new SuccessDataResult<IList<Category>>(_categoryService.GetList());
        }

        public IResult Update(Category category)
        {
            _categoryService.Update(category);
            return new SuccesResult(Messages.UpdatedCategory);
        }
    }
}
