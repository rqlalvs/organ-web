﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Models.Endereco
{
    [Table("tbLogradouro")]
    public class Logradouro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("Bairro")]
        public int IdBairro { get; set; }

        public virtual Bairro Bairro { get; set; }
    }
}