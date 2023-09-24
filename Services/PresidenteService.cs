using Programacion_NoSQL.Models;
using Programacion_NoSQL.Repository;

namespace Programacion_NoSQL.Services
{
    public class PresidenteService
    {
        public PresidenteRepository _presidenteRepository;
        public PresidenteService(PresidenteRepository presidenteRepository) {
            _presidenteRepository = presidenteRepository;
        }

        public List<Presidente> obtenerTodosLosCandidatos()
        {
            return _presidenteRepository.ObtenerTodos();
        }
    }
}
