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
    public class MessageRelationManager:IMessageRelationService
    {
        IMessageRelationDal messageRelationDal;
        Context context=new Context();
        public MessageRelationManager(IMessageRelationDal messageRelationDal)
        {
            this.messageRelationDal = messageRelationDal;
        }

        public List<MessageRelation> GetAll()
        {
            return messageRelationDal.GetAll();
        }

        public List<MessageRelation> GetInboxAllWithWriter(int id)
        {
            return messageRelationDal.GetByWriterMessage(id);
        }

        public void TAdd(MessageRelation t)
        {
            messageRelationDal.Insert(t);
            context.SaveChanges();
        }

        public void TDel(MessageRelation t)
        {
            throw new NotImplementedException();
        }

        public MessageRelation TGetById(int id)
        {
           return messageRelationDal.GetById(id);
        }

        public void TUpdate(MessageRelation t)
        {
            throw new NotImplementedException();
        }
    }
}
