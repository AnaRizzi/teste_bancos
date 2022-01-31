namespace AnaDomain.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Mensagem { get; set; }
    }
}
