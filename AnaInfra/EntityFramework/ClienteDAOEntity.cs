using AnaDomain.Interfaces;
using AnaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnaInfra.EntityFramework
{
    public class ClienteDAOEntity : IDisposable, IClienteDAO
    {
        private ClienteContext context;

        public ClienteDAOEntity(ClienteContext clientContext)
        {
            context = clientContext;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public void Cadastrar(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public Cliente Buscar(int id)
        {
            return context.Clientes.Find(id);
        }

        public List<Cliente> BuscarTodos()
        {
            var lista = context.Clientes.ToList();
            return lista;
        }
    }
}
