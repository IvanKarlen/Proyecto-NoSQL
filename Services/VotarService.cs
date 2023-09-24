using Programacion_NoSQL.Models;
using Programacion_NoSQL.Repository;

namespace Programacion_NoSQL.Services
{
    public class VotarService
    {
        public VotarRepository _votarRepository;
        public VotanteRepository _votanteRepository;

        public VotarService(VotarRepository votarRepository, VotanteRepository votanteRepository)
        {
            _votarRepository = votarRepository;
            _votanteRepository = votanteRepository;
        }

        public RespuestaVoto cargar(Votar voto)
        {
            Votante votante = _votanteRepository.ObtenerPorCuil(voto.votante.Cuil);

            if (votante != null)
            {
                Votar votoBD = _votarRepository.Cargar(voto);

                if (votoBD != null)
                {
                    return new RespuestaVoto { votante = votante, padronElectoral = votante.padronElectoral };
                }
                else
                {
                    throw new Exception("No se ha guardado su voto. Intentelo nuevamente");
                }
            }
            else
            {
                throw new Exception("No se ha encontrado una persona con esos datos");
            }
        }
    }
}
