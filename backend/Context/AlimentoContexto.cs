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
        public AlimentoContexto(DbContextOptions<AlimentoContexto> options) : base(options) { }

        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<EnergiaKJModels> Energia { get; set; }
        public DbSet<EnergiaKcalModels> Energiakcal { get; set; }
        public DbSet<UmidadeModels> Umidade { get; set; }
        public DbSet<CarboidratoTotalModels> CarboidratoTotals { get; set; }
        public DbSet<CarboidradoDisponivelModels> CarboidratoDisponivel { get; set; }
        public DbSet<ProteinaModels> Proteinas { get; set; }
        public DbSet<LipidiosModels> Lipidios { get; set; }
        public DbSet<FibraAlimentarModels> FibraAlimentar { get; set; }
        public DbSet<AlcoolModels> Alcool { get; set; }
        public DbSet<CinzasModels> Cinzas { get; set; }
        public DbSet<ColesterolModels> Colesterol { get; set; }
        public DbSet<AcidosGraxosSaturadosModels> AcidosGraxosSaturados { get; set; }
        public DbSet<AcidosGraxosPoliinsaturadosModels> AcidosGraxosPoliinsaturados { get; set; }
        public DbSet<AcidosGraxosTransModels> AcidosGraxosTrans { get; set; }
        public DbSet<CalcioModels> Calcio { get; set; }
        public DbSet<FerroModels> Ferro { get; set; }
        public DbSet<SodioModels> Sodio { get; set; }
        public DbSet<MagnesioModels> Magnesio { get; set; }
        public DbSet<FosforoModels> Fosforo { get; set; }
        public DbSet<PotassioModels> Potassio { get; set; }
        public DbSet<ManganesModels> Manganes { get; set; }
        public DbSet<ZincoModels> Zinco { get; set; }
        public DbSet<CobreModels> Cobre { get; set; }
        public DbSet<SelenioModels> Selenio { get; set; }

    }
}