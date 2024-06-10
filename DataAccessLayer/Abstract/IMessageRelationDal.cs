using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageRelationDal:IGenericDal<MessageRelation>
    {
        List<MessageRelation> GetByWriterMessage(int id);
    }
}
