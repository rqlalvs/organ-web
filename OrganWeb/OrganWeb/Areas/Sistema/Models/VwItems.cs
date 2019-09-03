﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Sistema.Models
{
    public class VwItems
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public double Quantidade { get; set; }
        [Display(Name = "Unidade de medida")]
        public string UnidadeMedida { get; set; }
        public string Categoria { get; set; }
    }
}