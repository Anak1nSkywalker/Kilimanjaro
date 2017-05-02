using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        public string Gender { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "CPF")]
        public int Cpf { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string MotherName { get; set; }

        [Display(Name = "DDD 1")]
        public int PrimaryDdd { get; set; }

        [Display(Name = "Telefone 1")]
        public int PrimaryFone { get; set; }

        [Display(Name = "DDD 2")]
        public int? SecundaryDdd { get; set; }

        [Display(Name = "Telefone 2")]
        public int? SecundaryFone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Última Atualização")]
        public DateTime? LastChangeDate { get; set; }

        public virtual IEnumerable<Address> Address { get; set; }

        public virtual IEnumerable<Record> Record { get; set; }
    }
}
