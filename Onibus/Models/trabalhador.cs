using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onibus.Models
{
    public class trabalhador
    {
        [Key]
        public int TrabalhadorId{ get; set; }
        public string Nome { get; set; }
    }
}