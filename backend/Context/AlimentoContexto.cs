using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AlimentoContexto : DbContext
    {
        public AlimentoContexto(DbContextOptions<AlimentoContexto> options) : base(options)
        {

        }

        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<EnergiaKJModels> Energia { get; set; }
    }
}