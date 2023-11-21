using Dapper;
using MySql.model;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mysql.Data.Repositorio
{
    public class RepostCamion : RepositorioCamion
    {
        private MySQLConfiguration _connectionString;

        public RepostCamion(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Camiones>> GetAllCamiones()
        {
            var db = dbConnection();
            var sql = @"SELECT camion_id, marca, modelo, pesoneto, capacidad, patente, dueño, año FROM Camiones";

            return await db.QueryAsync<Camiones>(sql);
        }

        public async Task<Camiones> GetCamionesDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT camion_id, marca, modelo, pesoneto, capacidad, patente, dueño, año FROM Camiones WHERE camion_id = @id";

            var result = await db.QueryFirstOrDefaultAsync<Camiones>(sql, new { id });

            return result;
        }

        public async Task<bool> InsertCamiones(Camiones camion)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Camiones (camion_id, marca, modelo, pesoneto, capacidad, patente, dueño, año) 
                        VALUES (@camion_id, @marca, @modelo, @pesoneto, @capacidad, @patente, @dueño, @año)";

            var result = await db.ExecuteAsync(sql, camion);

            return result > 0;
        }

        public async Task<bool> UpdateCamiones(Camiones upda)
        {
            var db = dbConnection();
            var sql = @"UPDATE Camiones 
                        SET marca = @marca, modelo = @modelo, pesoneto = @pesoneto, capacidad = @capacidad, 
                            patente = @patente, dueño = @dueño, año = @año 
                        WHERE camion_id = @camion_id";

            var result = await db.ExecuteAsync(sql, upda);

            return result > 0;
        }

        public async Task<bool> DeleteCamiones(Camiones dele)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM Camiones WHERE camion_id = @camion_id";

            var result = await db.ExecuteAsync(sql, new { camion_id = dele.camion_id });
            return result > 0;
        }
    }
}
