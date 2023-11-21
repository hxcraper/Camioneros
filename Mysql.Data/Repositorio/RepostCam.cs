using Dapper;
using MySql.model;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mysql.Data.Repositorio
{
    public class RepostCam : RepositorioCamioneros
    {
        private MySQLConfiguration _connectionString;

        public RepostCam(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Camioneros>> GetAllCamioneros()
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, edad, apellidos, direccion, telefono, tipoLicencia, fechaNacimiento FROM Camioneros";

            return await db.QueryAsync<Camioneros>(sql);
        }

        public async Task<Camioneros> GetCamionerosDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, edad, apellidos, direccion, telefono, tipoLicencia, fechaNacimiento FROM Camioneros WHERE id = @id";

            var result = await db.QueryFirstOrDefaultAsync<Camioneros>(sql, new { id });

            return result;
        }

        public async Task<bool> InsertCamioneros(Camioneros camionero)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Camioneros (id, nombre, edad, apellidos, direccion, telefono, tipoLicencia, fechaNacimiento) 
                        VALUES (@id, @nombre, @edad, @apellidos, @direccion, @telefono, @tipoLicencia, @fechaNacimiento)";

            var result = await db.ExecuteAsync(sql, camionero);

            return result > 0;
        }

        public async Task<bool> UpdateCamioneros(Camioneros upda)
        {
            var db = dbConnection();
            var sql = @"UPDATE Camioneros 
                        SET nombre = @nombre, edad = @edad, apellidos = @apellidos, direccion = @direccion, 
                            telefono = @telefono, tipoLicencia = @tipoLicencia, fechaNacimiento = @fechaNacimiento 
                        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, upda);

            return result > 0;
        }

        public async Task<bool> DeleteCamioneros(Camioneros dele)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM Camioneros WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new { id = dele.id });
            return result > 0;
        }
    }
}
