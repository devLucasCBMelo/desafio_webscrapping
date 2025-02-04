using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;

namespace backend.Services
{
    public class EnergiaService
    {
        private readonly AlimentoContexto _contexto;

        public EnergiaService(AlimentoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEnergia(EnergiaKJModels energia)
        {
            await _contexto.EnergiaKJ.AddAsync(energia);
            await _contexto.SaveChangesAsync();
        }
    }
}