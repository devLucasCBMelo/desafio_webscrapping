using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Core
{
    public class ClientRequest
    {
        public string? Name { get; set; }
        public decimal AccountBalance { get; set; }

        public Client CreateClient(int id)
        {
            return new Client
            {
                Id = id,
                Name = Name,
                AccountBalance = AccountBalance,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
    }
}