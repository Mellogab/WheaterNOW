using System.ComponentModel.DataAnnotations;

namespace WheaterAPI.Model
{
    public class User : UserBase
    {
        public int Selector { get; set; } // 0 to read and 1 to write
        [Key]
        public new int Id { get; set; }

        [Required(ErrorMessage ="Por Favor, Preencha o nome")]
        [MaxLength(90,ErrorMessage ="Este campos deve conter entre 30 e 90 caracteres")]
        [MinLength(15, ErrorMessage = "Este campos deve conter entre 30 e 90 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por Favor, Preecha o campo Email")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por Favor, Preencha o Usuário")]
        public new string Username { get; set; }
        
        [Required(ErrorMessage = "Por Favor, Preencha o Senha")]
        public new string Password { get; set; }
    }
}
