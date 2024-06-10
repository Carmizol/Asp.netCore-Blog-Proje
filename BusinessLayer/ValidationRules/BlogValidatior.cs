using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidatior : AbstractValidator<Blog>
    {
        public BlogValidatior()
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Başlığı Boş Geçemezsiniz.");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("İçeriği Boş Geçemezsiniz.");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Görseli Boş Geçemezsiniz.");
            RuleFor(x=>x.BlogTitle).MaximumLength(100).WithMessage("en fazla 100 karakter giriniz.");
            RuleFor(x=>x.BlogTitle).MinimumLength(5).WithMessage("en az 5 karakter giriniz.");
        }
    }
}
