using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EMessageRelationRepository : GenericRepository<MessageRelation>, IMessageRelationDal
    {
        public List<MessageRelation> GetByWriterMessage(int id)
        {
            using (var c = new Context())
            {
                return c.messageRelations.Include(x=>x.SenderUser).Where(x=>x.RecevierId==id).ToList();
            }
        }
    }
}
