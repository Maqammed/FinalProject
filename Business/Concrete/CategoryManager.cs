using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            var result = _categoryDal.GetAll();
            return result;

        }

        public Category GetById(int categortId)
        {
            return _categoryDal.Get(c=> c.CategoryId==categortId);
        }
    }
}
