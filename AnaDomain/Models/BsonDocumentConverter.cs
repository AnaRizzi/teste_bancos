using MongoDB.Bson;
using System;

namespace AnaDomain.Models
{
    public static class BsonDocumentConverter
    {
        public static BsonDocument Converter(Comentario comentario)
        {
            var lenght = comentario.Mensagem.Length;
            string conclusao = "";

            if (lenght < 50) conclusao = "Comentário rápido";
            else if (lenght < 100) conclusao = "Podia ter usado o tempo para outra coisa";
            else conclusao = "Tempo demais comentando! Vá fazer algo útil!";

            var document = new BsonDocument
            {
                {"Id do Comentario", comentario.Id },
                {"Autor", comentario.Cliente.Nome },
                {"Tamanho", $"{lenght} caracteres" },
                {"Conclusao", conclusao },
                {"Data", DateTime.Now }
            };

            return document;
        }

        public static BsonDocument Converter(Cliente cliente)
        {
            string conclusao = "";

            if (cliente.Nome.Length > 50) conclusao = "Que nome comprido!";

            var document = new BsonDocument
            {
                {"Id do Cliente", cliente.Id },
                {"Inserido em", DateTime.Now },
                {"Observações", conclusao }
            };

            return document;
        }
    }
}
