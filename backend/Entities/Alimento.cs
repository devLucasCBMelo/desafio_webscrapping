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
        public Collection<EnergiaKcalModels> energiaKcalModels { get; set; }
        public Collection<CalcioModels> calcios { get; set; }
        public Collection<AcidosGraxosMonoinsaturadosModels> acidosGraxosMonoinsaturadosModels { get; set; }
        public Collection<AcidosGraxosPoliinsaturadosModels> acidosGraxosPoliinsaturadosModels { get; set; }
        public Collection<AcidosGraxosSaturadosModels> acidosGraxosSaturadosModels { get; set; }
        public Collection<AcidosGraxosTransModels> acidosGraxosTransModels { get; set; }
    }

}