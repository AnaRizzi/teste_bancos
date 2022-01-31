using AnaDomain.Models;
using System.Collections.Generic;

namespace AnaDomain.Interfaces
{
    public interface IClienteService
    {
        ClienteResponse Cadastrar(ClienteRequest request);
        ClienteResponse Buscar(int id);
        IList<ClienteResponse> BuscarTodos();
        IList<ComentarioResponse> BuscarComentarios(int idCliente);
        void InserirComentario(ComentarioRequest request);
    }
}
