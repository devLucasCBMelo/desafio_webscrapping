using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Entities
{
    public class Alimento
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeCientifico { get; set; }

        public string Grupo { get; set; }

        public string Marca { get; set; }
        [JsonIgnore]
        public Collection<AcidosGraxosMonoinsaturadosModels> acidosGraxosMonoinsaturados { get; set; }
        public Collection<AcidosGraxosPoliinsaturadosModels> acidosGraxosPoliinsaturados { get; set; }
        public Collection<AcidosGraxosSaturadosModels> acidosGraxosSaturados { get; set; }
        public Collection<AcidosGraxosTransModels> acidosGraxosTransModels { get; set; }
        public Collection<AcucarDeAdicaoModels> acucarDeAdicao { get; set; }
        public Collection<AlcoolModels> alcool { get; set; }
        public Collection<CalcioModels> calcios { get; set; }
        public Collection<CarboidratoDisponivelModels> carboidratoDisponivel { get; set; }
        public Collection<CarboidratoTotalModels> carboidratoTotal { get; set; }
        public Collection<CinzasModels> cinzas { get; set; }
        public Collection<CobreModels> cobre { get; set; }
        public Collection<ColesterolModels> colesterol { get; set; }
        public Collection<EnergiaKcalModels> energiaKcal { get; set; }
        public Collection<EnergiaKJModels> energiaKJs { get; set; }
        public Collection<EquivalenteDeFolatoModels> equivalenteDeFolato { get; set; }
        public Collection<FerroModels> ferro { get; set; }
        public Collection<FibraAlimentarModels> fibraAlimentar { get; set; }
        public Collection<FosforoModels> fosforo { get; set; }
        public Collection<LipidiosModels> lipidios { get; set; }
        public Collection<MagnesioModels> magnesio { get; set; }
        public Collection<ManganesModels> manganes { get; set; }
        public Collection<NiacinaModels> niacina { get; set; }
        public Collection<PotassioModels> potassio { get; set; }
        public Collection<ProteinaModels> proteina { get; set; }
        public Collection<RiboflavinaModels> riboflavina { get; set; }
        public Collection<SalDeAdicaoModels> salDeAdicao { get; set; }
        public Collection<SelenioModels> selenio { get; set; }
        public Collection<SodioModels> sodio { get; set; }
        public Collection<TiaminaModels> tiamina { get; set; }
        public Collection<UmidadeModels> umidade { get; set; }
        public Collection<VitaminaARAEModels> vitaminaARAE { get; set; }
        public Collection<VitaminaAREModels> vitaminaARE { get; set; }
        public Collection<VitaminaB12Models> vitaminaB12 { get; set; }
        public Collection<VitaminaB6Models> vitaminaB6 { get; set; }
        public Collection<VitaminaCModels> vitaminaC { get; set; }
        public Collection<VitaminaDModels> vitaminaD { get; set; }
        public Collection<VitaminaEModelsModels> vitaminaE { get; set; }
        public Collection<ZincoModels> zinco { get; set; }
    }

}