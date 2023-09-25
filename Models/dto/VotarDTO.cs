namespace Programacion_NoSQL.Models.dto
{
    public class VotarDTO
    {
        public VotanteDTO votante { get; set; }
        public PresidenteDTO presidente { get; set; }
        public DiputadoDTO diputado { get; set; }
    }

    public class VotanteDTO
    {
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Cuil { get; set; }
        public PadronElectoralDTO padronElectoral { get; set; }
    }

    public class PadronElectoralDTO
    {
        public int NroOrden { get; set; }
        public int Distrito { get; set; }
        public int CIRC { get; set; }
        public int Seccion { get; set; }
        public int Mesa { get; set; }
    }

    public class PresidenteDTO
    {
        public int Id { get; set; }
    }

    public class DiputadoDTO
    {
        public int Id { get; set; }
    }
}
