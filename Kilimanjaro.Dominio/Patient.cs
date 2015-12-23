using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public string Rg { get; set; }

        public int Cpf { get; set; }

        public string MotherName { get; set; }

        public int PrimaryDdd { get; set; }

        public int PrimaryFone { get; set; }

        public int SecundaryDdd { get; set; }

        public int SecundaryFone { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastChangeDate { get; set; }

        public virtual IEnumerable<Address> Address { get; set; }

        public virtual IEnumerable<Record> Record { get; set; }
    }
}
