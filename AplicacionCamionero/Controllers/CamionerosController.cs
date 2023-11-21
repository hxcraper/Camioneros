using Microsoft.AspNetCore.Mvc;
using Mysql.Data.Repositorio;
using MySql.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicacionCamionero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionerosController : ControllerBase
    {

        private readonly RepositorioCamioneros _repostCam;

        public CamionerosController(RepositorioCamioneros repostCam)
        {
            _repostCam = repostCam;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllCamioneros()
        {
            return Ok(await _repostCam.GetAllCamioneros());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCamioneros(int id)
        {
            return Ok(await _repostCam.GetCamionerosDetails(id));
        }


        [HttpPost]
        public async Task<IActionResult> Createcamions([FromBody] Camioneros camionero)
        {

            if (camionero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var crear = await _repostCam.InsertCamioneros(camionero);
            return Created("creado", crear);

        }

        [HttpPut]
        public async Task<IActionResult> Updatecami([FromBody] Camioneros camionero)
        {

            if (camionero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repostCam.UpdateCamioneros(camionero);
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamion(int id, Camioneros camioneros) {


            await _repostCam.DeleteCamioneros(new Camioneros() { id = camioneros.id });

            return NoContent();
        }


    }
}

