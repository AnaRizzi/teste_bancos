using AnaDomain.Models;
using System.Collections.Generic;

namespace AnaDomain.Interfaces
{
    public interface IClienteService
    {
        Cliente Cadastrar(ClienteRequest request);

        Cliente Buscar(int id);

        List<Cliente> BuscarTodos();
    }
}
