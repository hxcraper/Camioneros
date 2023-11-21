using MySql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysql.Data.Repositorio
{
    public interface RepositorioCamion
    { 
        Task<IEnumerable<Camiones>> GetAllCamiones();
        Task<Camiones> GetCamionesDetails(int camion_id);
        Task<bool> InsertCamiones(Camiones marca);


        Task<bool> UpdateCamiones(Camiones marca);
        Task<bool> DeleteCamiones(Camiones camion_id);
    }
}
