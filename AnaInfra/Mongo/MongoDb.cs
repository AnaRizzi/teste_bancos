using AnaDomain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaInfra.Mongo
{
    public class MongoDb : IMongoDb
    {
        private readonly string _connection;
        private IMongoClient _client;
        private IMongoDatabase bancoDados;

        public MongoDb(string connection)
        {
            _connection = connection;

        }

        private IMongoCollection<BsonDocument> Conectar()
        {
            _client = new MongoClient(_connection);
            bancoDados = _client.GetDatabase("teste");
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("teste");

            return colecao;
        }

        public void RegistrarInformacoes(BsonDocument document)
        {
            var colecao = Conectar();

            colecao.InsertOne(document);
        }
    }
}
