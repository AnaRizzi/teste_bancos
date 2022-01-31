using System.Collections.Generic;

namespace AnaDomain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public IList<Comentario> Comentarios { get; set; }

        public Cliente()
        {
            Comentarios = new List<Comentario>();
        }
    }
}
