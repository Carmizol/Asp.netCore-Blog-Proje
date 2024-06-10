using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CatergoryName).NotEmpty().WithMessage("Kategori Boş Geçilemez.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
            RuleFor(x => x.CatergoryName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.CatergoryName).MinimumLength(2).WithMessage("En az 2 Karakter Olmalı.");

        }
    }
}
