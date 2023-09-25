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

        public RespuestaDTO cargar(VotarDTO votoDTO)
        {
            Votante votanteBD = _votanteRepository.ObtenerPorCuil(votoDTO.votante.Cuil);

            if (votanteBD != null)
            {
                Votante votante = new Votante
                {
                    Nombre = votanteBD.Nombre,
                    Apellido = votanteBD.Apellido,
                    Cuil = votanteBD.Cuil,
                    IdTipoDocumento = votanteBD.IdTipoDocumento,
                    Documento = votanteBD.Documento,
                    padronElectoral = new PadronElectoral
                    {
                        CIRC = votanteBD.padronElectoral.CIRC,
                        Distrito = votanteBD.padronElectoral.Distrito,
                        Mesa = votanteBD.padronElectoral.Mesa,
                        NroOrden = votanteBD.padronElectoral.NroOrden,
                        Seccion = votanteBD.padronElectoral.Seccion,
                    }
                };

                Presidente presidente = _presidenteRepository.ObtenerPorId(votoDTO.presidente.Id);

                // Persisto el voto
                Votar votoBD = _votarRepository.Cargar(new Votar
                {
                    presidente = presidente,
                    votante = votante
                });

                if (votoBD != null)
                    return new RespuestaDTO { votante = votante };
                else
                    throw new Exception("No se ha guardado su voto. Intentelo nuevamente");
            }
            else
            {
                throw new Exception("No existen personas asociadas a esos datos");
            }
        }
    }
}