﻿using System;
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

        [Display(Name = "Peso")]
        public float Weight { get; set; }

        [Display(Name = "Altura")]
        public float Height { get; set; }
        
        [Display(Name = "Largura")]
        public float Width { get; set; }

        [Display(Name = "Comprimento")]
        public float Length { get; set; }
        
        [Display(Name = "Altura")]
        public float? UsefulAreaHeight { get; set; }

        [Display(Name = "Largura")]
        public float? UsefulAreaWidth { get; set; }

        [Display(Name = "Comprimento")]
        public float? UsefulAreaLength { get; set; }
        
        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Última Atualização")]
        public DateTime? LastChangeDate { get; set; }

        public bool Status { get; set; } = true;

        //public virtual IEnumerable<Brand> Address { get; set; }

        //public virtual IEnumerable<Model> Record { get; set; }

        //public virtual IEnumerable<VehicleType> Record { get; set; }

        public virtual IEnumerable<Customer> Record { get; set; }        
        
    }
}
