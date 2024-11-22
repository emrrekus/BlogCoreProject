using System.ComponentModel.DataAnnotations;

namespace BlogCoreProject.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Lütfen Ad Giriniz")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Lütfen Soyad Giriniz")]
        public string Surname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Ad")]
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string Username { get; set; }
    }
}
