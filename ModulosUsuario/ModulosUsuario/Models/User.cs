using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Login não pode ser vazio!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha não pode ser vazia!")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Endereço de email inválido!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome não pode ser vazio!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sobrenome não pode ser vazio!")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "CPF inválido!")]
        [MinLength(11)]
        [MaxLength(11)]
        [CPFValidator]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Número de celular não pode ser vazio!")]
        [RegularExpression("^\\d{11}$", ErrorMessage = "Número de celular inválido!")]
        [Display(Name = "Celular")]
        public string Phone { get; set; }

        public List<AddressUser> Addresses { get; set; }
        
    }
    public class CPFValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(validationContext.DisplayName + " não pode ser nulo");
            }
            string cpf = value.ToString();
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return new ValidationResult(validationContext.DisplayName + " inválido");
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            if (cpf.EndsWith(digito))
                return ValidationResult.Success;
            return new ValidationResult(validationContext.DisplayName + " inválido");
        }
    }
    
}
