using Microsoft.AspNetCore.Mvc;
using Programacion_NoSQL.Models;
using Programacion_NoSQL.Models.dto;
using Programacion_NoSQL.Services;

namespace Programacion_NoSQL.Controllers
{
    [ApiController]
    [Route("votacion")]
    public class VotacionController : ControllerBase
    {
        private readonly PresidenteService _presidenteService;
        private readonly VotarService _votarService;
        public VotacionController(PresidenteService presidenteService, VotarService votarService)
        {
            _presidenteService = presidenteService;
            _votarService = votarService;
        }


        [HttpGet("candidatos")]
        [ProducesResponseType(typeof(IEnumerable<Presidente>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult ObtenerTodosLosCandidatos()
        {
            try
            {
                var presidentes = _presidenteService.ObtenerTodos();

                if (presidentes != null && presidentes.Any())
                {
                    return Ok(presidentes);
                }
                else
                {
                    return NotFound("No se encontraron candidatos."); // Devuelve una respuesta 404 Not Found
                }
            }
            catch (Exception ex)
            {
                // Devuelve una respuesta JSON con el mensaje de error
                var errorResponse = new ErrorResponse { Message = "Error: " + ex.Message };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("votar")]
        [ProducesResponseType(typeof(RespuestaDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]

        public IActionResult registrarVoto(VotarDTO votoDTO)
        {
            try
            {
                return Ok(_votarService.cargar(votoDTO));
            }
            catch (Exception ex)
            {
                // Devuelve una respuesta JSON con el mensaje de error
                var errorResponse = new ErrorResponse { Message = "Error: " + ex.Message };
                return StatusCode(500, errorResponse);
            }
        }
    }
}