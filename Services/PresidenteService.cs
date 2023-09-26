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

        public List<Presidente> ObtenerTodos()
        {
            return _presidenteRepository.ObtenerTodos();
        }
    }
}
