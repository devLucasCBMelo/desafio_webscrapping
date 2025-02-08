using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Element
    {
        public Alimento alimento;

        public List<Alimento> ElementTable { get; set; }

        public void AddElementInTable(Alimento alimento)
        {
            ElementTable.Add(alimento);
        }
    }
}