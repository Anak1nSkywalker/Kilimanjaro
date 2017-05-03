using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kilimanjaro.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "CPF")]
        public int Cpf { get; set; }

        [Display(Name = "DDD")]
        public int Ddd { get; set; }

        [Display(Name = "Telefone")]
        public int Fone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "O email informado não é válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Última Atualização")]
        public DateTime? LastChangeDate { get; set; }

        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Precisa ser entre 5 e 255 caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Preencha a senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Precisa ser entre 5 e 255 caracteres", MinimumLength = 5)]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmationPassword { get; set; }

        public bool ServiceProvider { get; set; } = false;

        public bool Status { get; set; } = true;

    }
}
