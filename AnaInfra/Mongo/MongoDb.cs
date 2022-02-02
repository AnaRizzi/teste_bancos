using AnaDomain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AnaInfra.Mongo
{
    public class MongoDb : IMongoDb
    {
        private readonly string _connection;
        private IMongoClient _client;
        private IMongoDatabase bancoDados;
        private readonly MongoConfig _config;

        public MongoDb(string connection, MongoConfig config)
        {
            _connection = connection;
            _config = config;
        }

        private IMongoCollection<BsonDocument> Conectar()
        {
            _client = new MongoClient(_connection);
            bancoDados = _client.GetDatabase(_config.Database);
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>(_config.Collection);

            return colecao;
        }

        public void RegistrarInformacoes(BsonDocument document)
        {
            var colecao = Conectar();

            colecao.InsertOne(document);
        }
    }
}
