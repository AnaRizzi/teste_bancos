using AnaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaDomain.Interfaces
{
    public interface IClienteDAO
    {
        void Cadastrar(Cliente cliente);

        Cliente Buscar(int id);

        List<Cliente> BuscarTodos();
    }
}
