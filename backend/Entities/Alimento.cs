using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}