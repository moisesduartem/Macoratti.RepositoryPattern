using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macoratti.RepositoryPattern.Api.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
