using System;
using System.ComponentModel.DataAnnotations;
using ClinicaApi.Libraries.Validations;

namespace ClinicaApi.Models.DTO
{
    public class ClienteDTO
    {
        [Required]
        [CPF]
        [CPFIsUsed]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Sexo { get; set; }
        public bool isDeleted { get; set; }
       
        public int ContatoCodigo { get; set; }
        public Contato Contato { get; set; }
    }
}