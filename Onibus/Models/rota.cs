using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Onibus.Models
{
    public class rota
    {
        [Key]
        public int RotasId { get; set; }
        public string NomeRota { get; set; }
    }
}