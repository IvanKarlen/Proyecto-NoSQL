using Programacion_NoSQL.Models;
using Programacion_NoSQL.Models.dto;
using Programacion_NoSQL.Repository;

namespace Programacion_NoSQL.Services
{
    public class VotarService
    {
        public VotarRepository _votarRepository;
        public VotanteRepository _votanteRepository;
        public PresidenteRepository _presidenteRepository;

        public VotarService(VotarRepository votarRepository, VotanteRepository votanteRepository,
                            PresidenteRepository presidenteRepository)
        {
            _votarRepository = votarRepository;
            _votanteRepository = votanteRepository;
            _presidenteRepository = presidenteRepository;
        }

        public async Task<RespuestaDTO> Cargar(VotarDTO votoDTO)
        {
            try
            {
                // Obtiene el votante de la base de datos
                Votante votante = ObtenerPorCuil(votoDTO.votante.Cuil);

                if (votante == null)
                    throw new Exception("Error al cargar los datos. No hay un votante que coincida con esos datos.");

                // Obtengo el presidente por ID
                Presidente presidente = await _presidenteRepository.ObtenerPorIdAsync(votoDTO.presidente.Id);

                if (presidente == null)
                    throw new Exception("Error al cargar los datos. No hay un presidente que coincida con esos datos.");

                // Verifica si el votante ya ha ejercido su voto
                VerificarVotanteEjercioVoto(votante);

                // Persiste el voto
                Votar votoBD = _votarRepository.Cargar(new Votar
                {
                    presidente = presidente,
                    votante = votante,
                });

                // Actualiza el estado del votante
                Votante votanteActualizado = ActualizarEstadoVotante(votante);

                if (votoBD != null && votanteActualizado != null)
                {
                    return new RespuestaDTO { votante = votante };
                }
                else
                {
                    throw new Exception("No se ha guardado su voto. Inténtelo nuevamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void VerificarVotanteEjercioVoto(Votante votante)
        {
            if (votante.Voto == true)
            {
                throw new Exception("Usted ya ha ejercido su voto.");
            }
        }

        private Votante ActualizarEstadoVotante(Votante votante)
        {
            votante.Voto = true;
            return _votanteRepository.Actualizar(votante);
        }

        private Votante ObtenerPorCuil(string Cuil)
        {
            return _votanteRepository.ObtenerPorCuil(Cuil);
        }
    }
}