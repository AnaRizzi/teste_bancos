using System.Collections.Generic;

namespace AnaDomain.Models
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ClienteResponse(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
        }

        public static IList<ClienteResponse> CriarListaDeClientes(IList<Cliente> lista)
        {
            IList<ClienteResponse> novaLista = new List<ClienteResponse>();
            foreach (var item in lista)
            {
                var cliente = new ClienteResponse(item);
                novaLista.Add(cliente);
            }

            return novaLista;
        }
    }
}
