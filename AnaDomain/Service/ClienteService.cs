using AnaDomain.Interfaces;
using AnaDomain.Models;
using System.Collections.Generic;

namespace AnaDomain.Service
{
    public class ClienteService : IClienteService
    {
        private IClienteDAO _clienteDao;

        public ClienteService(IClienteDAO clienteDAO)
        {
            _clienteDao = clienteDAO;
        }

        public ClienteResponse Buscar(int id)
        {
            var cliente = _clienteDao.Buscar(id);

            if (cliente == null)
            {
                return null;
            }
            return new ClienteResponse(cliente);
        }

        public IList<ClienteResponse> BuscarTodos()
        {
            var clientes = _clienteDao.BuscarTodos();

            if (clientes == null)
            {
                return new List<ClienteResponse>();
            }

            var lista = ClienteResponse.CriarListaDeClientes(clientes);

            return lista;
        }

        public ClienteResponse Cadastrar(ClienteRequest request)
        {
            var cliente = new Cliente()
            {
                Nome = request.Nome,
                Cpf = request.Cpf
            };
            _clienteDao.Cadastrar(cliente);

            var response = new ClienteResponse(cliente);
            return response;
        }

        public IList<ComentarioResponse> BuscarComentarios(int idCliente)
        {
            var comentarios = _clienteDao.BuscarComentarios(idCliente);

            if (comentarios == null)
            {
                return new List<ComentarioResponse>();
            }

            var lista = ComentarioResponse.CriarListaDeComentarios(comentarios);

            return lista;
        }
    }
}
