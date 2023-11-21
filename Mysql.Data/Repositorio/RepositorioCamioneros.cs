using MySql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysql.Data.Repositorio
{
    public interface RepositorioCamioneros
    {
        Task<IEnumerable<Camioneros>> GetAllCamioneros();
        Task<Camioneros> GetCamionerosDetails(int id);
        Task<bool> InsertCamioneros(Camioneros nombre);


        Task<bool> UpdateCamioneros( Camioneros nombre);
        Task<bool> DeleteCamioneros(Camioneros id);
    }
}
