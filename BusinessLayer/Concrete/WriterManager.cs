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
    public class WriterManager : IWriterService
    {
        IWriterDal WriterDal;

        public WriterManager(IWriterDal writerDal)
        {
            WriterDal = writerDal;
        }

        public List<Writer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return WriterDal.GetAll(x => x.WriterId == id);
        }

        public void TAdd(Writer t)
        {
            WriterDal.Insert(t);
        }

        public void TDel(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return WriterDal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
             Context context = new Context();
             WriterDal.Update(t);
             context.SaveChanges();
        }
    }
}
