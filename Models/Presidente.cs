namespace Programacion_NoSQL.Models
{
    public class Presidente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string VicePresidente { get; set; }
        public List<Diputado> listDiputados { get; set; }
    }
}
