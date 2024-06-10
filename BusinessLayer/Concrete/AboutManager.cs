using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		IAboutDal aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			this.aboutDal = aboutDal;
		}

		public List<About> GetAll()
		{
			return aboutDal.GetAll();
		}

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(About t)
        {
            throw new NotImplementedException();
        }

        public void TDel(About t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            throw new NotImplementedException();
        }
    }
}
