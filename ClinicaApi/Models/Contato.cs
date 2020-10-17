using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Models
{
    public class Contato
    {
        [Key]
        public int Codigo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}