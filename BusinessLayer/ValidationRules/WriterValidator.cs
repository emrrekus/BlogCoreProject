using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Ad kısmı boş geçilemez")
           .MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz")
           .MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad kısmı boş geçilemez");

            RuleFor(x => x.WriterPassword)
                .NotEmpty().WithMessage("Şifre kısmı boş geçilemez")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                .Matches(@"[^\w\d\s:]").WithMessage("Şifre en az bir özel karakter içermelidir")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır"); 

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail kısmı boş geçilemez")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");
        }

    }
}
