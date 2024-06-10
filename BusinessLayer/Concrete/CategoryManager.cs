using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return categoryDal.GetById(id); 
        }

        public void TAdd(Category t)
        {
            categoryDal.Insert(t);
        }

        public void TDel(Category t)
        {
            categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            categoryDal.Update(t);
        }
    }
}
