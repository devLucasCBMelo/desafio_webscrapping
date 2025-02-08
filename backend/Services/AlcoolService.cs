using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;

namespace backend.Services
{
    public class AlcoolService
    {
        private readonly FoodContext _contexto;

        public AlcoolService(FoodContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAlcool(AlcoolModels alcool)
        {
            Console.WriteLine("(((((((((((((((((((((((((CHEGUEI AQUIIIII)))))))))))))))))))))))))");
            await _contexto.Alcool.AddAsync(alcool);
            await _contexto.SaveChangesAsync();
        }
    }
}