using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kilimanjaro.Domain
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Identificação")]
        public string Identification { get; set; }

        [Display(Name = "Chassi")]
        public string Chassis { get; set; }
        
        [Display(Name = "Ano")]
        public int Year { get; set; }
        
        [Display(Name = "Peso"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Weight { get; set; }

        [Display(Name = "Altura")]
        public decimal Height { get; set; }
        
        [Display(Name = "Largura")]
        public decimal Width { get; set; }

        [Display(Name = "Comprimento")]
        public decimal Length { get; set; }
        
        [Display(Name = "Area Útil Altura")]
        public decimal? UsefulAreaHeight { get; set; }

        [Display(Name = "Area Útil Largura")]
        public decimal? UsefulAreaWidth { get; set; }

        [Display(Name = "Area Útil Comprimento")]
        public decimal? UsefulAreaLength { get; set; }
        
        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Última Atualização")]
        public DateTime? LastChangeDate { get; set; }

        public bool Status { get; set; } = true;

        //public virtual IEnumerable<Brand> Address { get; set; }

        //public virtual IEnumerable<Model> Record { get; set; }

        //public virtual IEnumerable<VehicleType> Record { get; set; }

        //public virtual IEnumerable<Customer> Record { get; set; }        
        
    }
}
