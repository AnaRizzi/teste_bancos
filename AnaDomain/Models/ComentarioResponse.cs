using System.Collections.Generic;

namespace AnaDomain.Models
{
    public class ComentarioResponse
    {

        public int IdComentario { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Mensagem { get; set; }

        public ComentarioResponse(Comentario comentario)
        {
            IdComentario = comentario.Id;
            IdCliente = comentario.Cliente.Id;
            NomeCliente = comentario.Cliente.Nome;
            Mensagem = comentario.Mensagem;
        }

        public static IList<ComentarioResponse> CriarListaDeComentarios(IList<Comentario> lista)
        {
            IList<ComentarioResponse> novaLista = new List<ComentarioResponse>();
            foreach (var item in lista)
            {
                var comentario = new ComentarioResponse(item);
                novaLista.Add(comentario);
            }

            return novaLista;
        }
    }
}
