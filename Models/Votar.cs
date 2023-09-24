namespace Programacion_NoSQL.Models
{
    public class Votar
    {
        public int Id { get; set; }
        public Votante votante { get; set; }
        public Presidente presidente { get; set;}
        public Diputado diputado { get; set; }  
        
    }
}
