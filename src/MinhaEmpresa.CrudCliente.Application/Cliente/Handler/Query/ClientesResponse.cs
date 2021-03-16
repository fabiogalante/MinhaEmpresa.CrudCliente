using System;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Query
{
    public class ClientesResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
