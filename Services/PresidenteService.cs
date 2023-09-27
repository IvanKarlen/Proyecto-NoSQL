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

        public async Task<List<Presidente>> ObtenerTodos()
        {
            return await _presidenteRepository.ObtenerTodosAsync();
        }
    }
}
