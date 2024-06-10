using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidatior : AbstractValidator<Writer>
	{
		public WriterValidatior()
		{

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim kısmı Boş olamaz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısmı Boş olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(6).WithMessage("En az 6 karakter Girilmeli");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girilebilir.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Alanı boş Olamaz.");
            RuleFor(x => x.WriterPassword).Matches(@"^(?=.*[a-z])(?=.*[A-Z]).{8,}$").WithMessage("Şifrenizde En az 1 büyük, küçük Harf içermeli ve en az 8 karakterden oluşmalı");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Resim Boş Olamaz.");

        }
    }
}
