

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaApi.Models

{
    public class Medico
    {
        [Key]
        public string CRM { get; set; }
        public string Nome { get; set; }
        public int ConsultaCodigo { get; set; }
        public Consulta Consulta { get; set; }


        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}