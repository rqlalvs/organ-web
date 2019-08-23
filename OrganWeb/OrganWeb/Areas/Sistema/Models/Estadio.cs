﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrganWeb.Models;

namespace OrganWeb.Areas.Sistema.Models
{
    [Table("tbEstadio")]
    public class Estadio : Repository<Estadio>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 1)]
        public string Tempo { get; set; }

        [StringLength(300, MinimumLength = 10)]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey("Plantio")]
        public int IdPlantio { get; set; }

        public virtual Plantio Plantio { get; set; }
    }
}