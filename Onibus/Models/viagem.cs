using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onibus.Models
{
    public class viagem
    {
        [Key]
        public int Codigo { get; set; }

        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        public virtual motorista Veiculos { get; set; }

        [Display(Name = "Motorista")]
        public int TrabalhadorId { get; set; }
        public virtual trabalhador Trabalhador { get; set; }

        [Display(Name = "Horario da Viagem")]
        public string HorarioViagem { get; set; }
        public decimal Custo { get; set; }

        [Display(Name = "Posição do Veículo")]
        public string PosicaoVeiculo { get; set; }

        [Display(Name = "Data")]
        public string DataViagem { get; set; }

        [Display(Name = "Rota")]
        public int RotasId { get; set; }
        public virtual rota Rotas { get; set; }

    }
}