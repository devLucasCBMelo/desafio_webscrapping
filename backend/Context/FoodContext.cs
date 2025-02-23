using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<EnergiaKJModels> EnergiaKJ { get; set; }
        public DbSet<EnergiaKcalModels> EnergiaKcal { get; set; }
        public DbSet<UmidadeModels> Umidade { get; set; }
        public DbSet<CarboidratoTotalModels> CarboidratoTotal { get; set; }
        public DbSet<CarboidratoDisponivelModels> CarboidratoDisponivel { get; set; }
        public DbSet<ProteinaModels> Proteina { get; set; }
        public DbSet<LipidiosModels> Lipidios { get; set; }
        public DbSet<FibraAlimentarModels> FibraAlimentar { get; set; }
        public DbSet<AlcoolModels> Alcool { get; set; }
        public DbSet<CinzasModels> Cinzas { get; set; }
        public DbSet<ColesterolModels> Colesterol { get; set; }
        public DbSet<AcidosGraxosSaturadosModels> AcidosGraxosSaturados { get; set; }
        public DbSet<AcidosGraxosMonoinsaturadosModels> AcidosGraxosMonoinsaturados { get; set; }
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

        public DbSet<VitaminaAREModels> VitaminaARE { get; set; }
        public DbSet<VitaminaARAEModels> VitaminaARAE { get; set; }
        public DbSet<VitaminaDModels> VitaminaD { get; set; }

        public DbSet<VitaminaEModelsModels> VitaminaE { get; set; }
        public DbSet<TiaminaModels> Tiamina { get; set; }
        public DbSet<RiboflavinaModels> Riboflavina { get; set; }
        public DbSet<NiacinaModels> Niacina { get; set; }
        public DbSet<VitaminaB6Models> VitaminaB6 { get; set; }
        public DbSet<VitaminaB12Models> VitaminaB12 { get; set; }
        public DbSet<VitaminaCModels> VitaminaC { get; set; }
        public DbSet<EquivalenteDeFolatoModels> EquivalenteDeFolato { get; set; }

        public DbSet<SalDeAdicaoModels> SalDeAdicao { get; set; }

        public DbSet<AcucarDeAdicaoModels> AcucarDeAdicao { get; set; }
    }
}