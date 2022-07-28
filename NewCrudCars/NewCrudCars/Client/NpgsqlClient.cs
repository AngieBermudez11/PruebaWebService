using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace NewCrudCars.Client
{
    public class NpgsqlClient
    {
        #region Static
        private static readonly Dictionary<string, NpgsqlClient> Connections = new();
        public static NpgsqlClient Create(string connectionString)
        {
            if (!Connections.ContainsKey(connectionString))
            {
                Connections[connectionString] = new NpgsqlClient(connectionString);
            }
            return Connections[connectionString];
        }
        #endregion
        #region Attributes
        private readonly string _connectionString;
        #endregion
        #region Methods

        public NpgsqlClient(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
        #endregion
    }
}