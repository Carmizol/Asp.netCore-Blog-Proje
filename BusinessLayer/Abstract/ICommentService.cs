using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void CommentAdd(Comment comment);
		//void CommentDel(Comment comment);
		//void CommentUpdate(Comment comment);
		List<Comment> GetAll(int id);
		//Comment GetById(int id);

	}
}
