using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Models
{
    public class Especialidade
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}