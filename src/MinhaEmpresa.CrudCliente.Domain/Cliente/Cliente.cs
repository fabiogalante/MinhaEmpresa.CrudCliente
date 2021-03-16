using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaEmpresa.CrudCliente.Crosscutting.Entity;

namespace MinhaEmpresa.CrudCliente.Domain.Cliente
{
    public class Cliente : Entity<Guid>, IDomain<Cliente>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
