namespace Programacion_NoSQL.Models
{
    public class Votante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Cuil { get; set; }
        public PadronElectoral padronElectoral { get; set; }
    }
}
