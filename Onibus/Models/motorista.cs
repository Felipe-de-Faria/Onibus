using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onibus.Models
{
    public class motorista
    {
        [Key]
        public int VeiculoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [Display(Name = "Itens Adicionais")]
        public string ItensAdd { get; set; }
    }
}