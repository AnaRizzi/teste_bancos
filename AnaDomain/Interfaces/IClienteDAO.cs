using AnaDomain.Models;
using System.Collections.Generic;

namespace AnaDomain.Interfaces
{
    public interface IClienteDAO
    {
        void Cadastrar(Cliente cliente);
        Cliente Buscar(int id);
        List<Cliente> BuscarTodos();
        Cliente BuscarPorCpf(string cpf);
        List<Comentario> BuscarComentarios(int idCliente);
        void CadastrarComentario(Comentario comentario);
    }
}
