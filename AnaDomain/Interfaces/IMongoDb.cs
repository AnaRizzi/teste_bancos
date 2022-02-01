using MongoDB.Bson;

namespace AnaDomain.Interfaces
{
    public interface IMongoDb
    {
        void RegistrarInformacoes(BsonDocument document);
    }
}
