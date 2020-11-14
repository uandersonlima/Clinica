using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClinicaApi.Models;
using ClinicaApi.Models.DTO;
using ClinicaApi.Services.Interfaces;

namespace ClinicaApi.Libraries.Validations
{
    public sealed class CPFIsUsed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Digite o CPF!");
            }
            string cpf = (value as string).Trim();

            IClienteServices clienteRepos = (IClienteServices)validationContext.GetService(typeof(IClienteServices));
            List<Cliente> clientes = clienteRepos.GetUserByCPFAsync(cpf).Result;

            ClienteDTO objCliente = (ClienteDTO)validationContext.ObjectInstance;

            if (clientes.Count > 1)
            {
                return new ValidationResult("CPF já existente!");
            }
            if (clientes.Count == 1 && objCliente.CPF != clientes.First().CPF)
            {
                return new ValidationResult("CPF já existente!");
            }


            return ValidationResult.Success;            
        }
    }
}