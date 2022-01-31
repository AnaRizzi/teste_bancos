using AnaDomain.Interfaces;
using AnaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaDomain.Service
{
    public class ClienteService : IClienteService
    {
        private IClienteDAO _clienteDao;

        public ClienteService(IClienteDAO clienteDAO)
        {
            _clienteDao = clienteDAO;
        }

        public Cliente Buscar(int id)
        {
            var cliente = _clienteDao.Buscar(id);

            return cliente;
        }

        public List<Cliente> BuscarTodos()
        {
            var lista = _clienteDao.BuscarTodos();

            return lista;
        }

        public Cliente Cadastrar(ClienteRequest request)
        {
            var cliente = new Cliente()
            {
                Nome = request.Nome,
                Cpf = request.Cpf
            };
            _clienteDao.Cadastrar(cliente);

            return cliente;
        }
    }
}
