using Microsoft.AspNetCore.Mvc;
using Programacion_NoSQL.Models;
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
        public IEnumerable<Presidente> obtenerCandidatos()
        {
            return _presidenteService.obtenerTodosLosCandidatos();
        }

        [HttpPost("votar")]
        public RespuestaVoto registrarVoto(Votar voto)
        {
            return _votarService.cargar(voto);
        }
    }
}