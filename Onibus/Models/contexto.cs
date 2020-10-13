using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Onibus.Models
{
    public class contexto: DbContext
    {
        public DbSet<viagem> Viagens { get; set; }

        public DbSet<motorista> Motoristas { get; set; }

        public DbSet<trabalhador> trabalhadors { get; set; }

        public DbSet<rota> rotas { get; set; }
        
    }
}