﻿using OrganWeb.Areas.Sistema.Models.Armazenamento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Sistema.Models.Financas
{
    [Table("tbItensVendidos")]
    public class ItensVendidos
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Venda")]
        public int IdVenda { get; set; }
        
        [Key, Column(Order = 2)]
        [ForeignKey("Estoque")]
        public int IdEstoque { get; set; }

        [Range(0.01, 999.99)]
        [Display(Name = "Desconto do produto")]
        public double DescontoProd { get; set; }

        [Required]
        public double QtdVendida { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual Estoque Estoque { get; set; }
    }
}