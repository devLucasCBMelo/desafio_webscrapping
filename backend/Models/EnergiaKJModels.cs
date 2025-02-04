using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace backend.Models
{
    public class EnergiaKJModels
    {
        [Key]
        public int Cogido { get; set; }
        public string Unidades { get; set; }
        public string ValorPor100g { get; set; }
        public string ColherSopaCheia45g { get; set; }
        public string CopoAmericanoDuplo200ml { get; set; }
        public string CopoAmericanoPequeno130ml { get; set; }
        public string PedacoUnidadeFatia { get; set; }
        public string PratoFundo450g { get; set; }
        public string PratoRaso350g { get; set; }
    }
}