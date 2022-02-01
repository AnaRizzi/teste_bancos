using AnaDomain.Enums;
using AnaDomain.Interfaces;
using AnaDomain.Models;
using System;
using System.Collections.Generic;

namespace AnaDomain.Service
{
    public class ClienteService : IClienteService
    {
        private IClienteDAO _clienteDao;
        private ILogsDAO _logsDao;

        public ClienteService(IClienteDAO clienteDAO, ILogsDAO logsDAO)
        {
            _clienteDao = clienteDAO;
            _logsDao = logsDAO;
        }

        public ClienteResponse Buscar(int id)
        {
            var cliente = _clienteDao.Buscar(id);

            if (cliente == null)
            {
                return null;
            }

            _logsDao.RegistrarLog(LogsMessages.BuscaId);

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

            _logsDao.RegistrarLog(LogsMessages.Busca);

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

            _logsDao.RegistrarLog(LogsMessages.Cadastro);

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

        public void InserirComentario(ComentarioRequest request)
        {
            var cliente = _clienteDao.BuscarPorCpf(request.Cpf);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            Comentario comentario = new Comentario()
            {
                Mensagem = request.Comentario,
                Cliente = cliente
            };

            _clienteDao.CadastrarComentario(comentario);

            _logsDao.RegistrarLog(LogsMessages.Comentario);

        }
    }
}
