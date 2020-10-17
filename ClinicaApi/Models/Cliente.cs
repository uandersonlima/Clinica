using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaApi.Models
{
    public class Cliente
    {
        [Key]
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Birthday { get; set; }
        public string Sexo { get; set; }

        public int ConsultaCodigo { get; set; }
        public Consulta Consulta { get; set; }

        public int ContatoCodigo { get; set; }
        public Contato Contato { get; set; }



        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

    }
}