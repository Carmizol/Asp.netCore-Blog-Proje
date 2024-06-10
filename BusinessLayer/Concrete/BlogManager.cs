using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}
        public List<Blog> GetListWithCategoryByWriterBlog(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}

		public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

		public List<Blog> GetBlogId(int id)
		{
            return _blogDal.GetAll(x => x.BlogId == id);

		}
        public List<Blog> GetLastBlogPost() 
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }

        public void TAdd(Blog t)
        {
            Context context = new Context();
            _blogDal.Insert(t);
            context.SaveChanges();
        }

        public void TDel(Blog t)
        {
           _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            Context context = new Context();
            _blogDal.Update(t);
            context.SaveChanges();
        }
    }
}
