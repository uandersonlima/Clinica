using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Models.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [Compare(nameof(Senha))]
        public string ConfirmacaoSenha { get; set; }
        
    }
}