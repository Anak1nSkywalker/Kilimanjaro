using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace Kilimanjaro.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o login")]
        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "O login deve possuir somente letras e deve ter de 5 a 15 caracteres")]
        //[Remote("UniqueLogin", "User", ErrorMessage = "Esse nome de login já existe")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Selecione o sexo")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Preencha o rg")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Preencha o cpf")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o ddd")]
        public int PrimaryDdd { get; set; }

        [Required(ErrorMessage = "Preencha o telefone")]
        public int PrimaryFone { get; set; }

        public int? SecondaryDdd { get; set; }

        public int? SecondaryFone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        public string Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmationPassword { get; set; }

        public UserType UserType { get; set; }

        public virtual IEnumerable<Address> Address { get; set; }

        public virtual IEnumerable<Record> Record { get; set; }
    }
}
