using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public abstract class ComponentInfos
    {
        [Key]
        public string Codigo { get; set; }

        // Corrigir o nome da chave estrangeira
        [ForeignKey("Codigo")]
        public Alimento Alimento { get; set; }

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