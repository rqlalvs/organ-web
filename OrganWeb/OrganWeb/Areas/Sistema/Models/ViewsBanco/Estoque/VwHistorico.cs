﻿using OrganWeb.Areas.Sistema.Models.zBanco;
using OrganWeb.Areas.Sistema.Models.zRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Sistema.Models.ViewsBanco.Estoque
{
    [Table("vwHistorico")]
    public class VwHistorico : HistoricoRepository
    {
        [Key]
        public int Id { get; set; }
        public int IdItem { get; set; }
        public string Nome { get; set; }
        public double QtdAntiga { get; set; }
        public double QtdAtual { get; set; }
        public string DataAlteracao { get; set; }
        public string Descricao { get; set; }
    }
}