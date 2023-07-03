using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mail Adresi Giriniz")]
        [EmailAddress(ErrorMessage = "Email Adresini Doğru Giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }
    }
}
