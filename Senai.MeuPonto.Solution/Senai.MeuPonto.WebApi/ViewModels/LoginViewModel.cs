using System.ComponentModel.DataAnnotations;

namespace Senai.MeuPonto.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
