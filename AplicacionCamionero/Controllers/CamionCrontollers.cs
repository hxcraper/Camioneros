using Microsoft.AspNetCore.Mvc;
using Mysql.Data.Repositorio;
using MySql.model;


namespace AplicacionCamionero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionController : ControllerBase
    {

        private readonly RepositorioCamion _RepostCamion;

        public CamionController(RepositorioCamion RepostCamion)
        {
            _RepostCamion = RepostCamion;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllCamiones()
        {
            return Ok(await _RepostCamion.GetAllCamiones());
        }

        [HttpGet("{camion_id}")]
        public async Task<IActionResult> GetAllCamiones(int camion_id)
        {
            return Ok(await _RepostCamion.GetCamionesDetails(camion_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCamion([FromBody] Camiones camion)
        {

            if (camion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var crear = await _RepostCamion.InsertCamiones(camion);
            return Created("creado", crear);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCamion([FromBody] Camiones camion)
        {

            if (camion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _RepostCamion.UpdateCamiones(camion);
            return NoContent();

        }


        [HttpDelete("{camion_id}")]
        public async Task<IActionResult> DeleteCamions(int id, Camiones camion)
        {


            await _RepostCamion.DeleteCamiones(new Camiones() { camion_id = camion.camion_id });

            return NoContent();
        }


    }
}
