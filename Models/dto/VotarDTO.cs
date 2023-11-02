namespace Programacion_NoSQL.Models.dto
{
    public class VotarDTO
    {
        public VotanteDTO votante { get; set; }
        public PresidenteDTO presidente { get; set; }
        public JefeDeGobiernoDTO jefeDeGobierno { get; set; }
    }

    public class VotanteDTO
    {
        public string Cuil { get; set; }
    }

    public class PresidenteDTO
    {
        public int Id { get; set; }
    }

    public class JefeDeGobiernoDTO
    {
        public int Id { get; set; }
    }
}
