using AnaDomain.Interfaces;
using Npgsql;
using Dapper;
using System.Data;

namespace AnaInfra.Postgre
{
    public class LogsDAO : ILogsDAO
    {
        private string _connection;

        public LogsDAO(string connectionString)
        {
            _connection = connectionString;
        }

        public void RegistrarLog(string logsMessage)
        {
            var query = @"Insert into meuslogs (acao) values (@mensagem)";
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Execute(query, new
                {
                    mensagem = logsMessage
                });
            }
        }
    }
}
