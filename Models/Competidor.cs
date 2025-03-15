using System.ComponentModel.DataAnnotations;

namespace Cronometro.Models
{
    public class CompetidorBD
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int NumeroCompetidor { get; set; }
        public float DistanciaRecorrida { get; set; }
        public float TiempoFinal { get; set; }
        public float VelocidadPromedio { get; set; }
        public string Estado { get; set; } = "Inscrito";
    }
        
        
    public class Competidor
    {
        public int IdCompetidor { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int NumeroCompetidor { get; set; }
        public float DistanciaRecorrida { get; set; }
        public float TiempoFinal { get; set; }
        public float VelocidadPromedio { get; set; }
        public string Estado { get; set; } = "Inscrito";
        public Competidor() { }
        public Competidor(int id, string nombre, int numero)
        {
            IdCompetidor = id;
            Nombre = nombre;
            NumeroCompetidor = numero;
            DistanciaRecorrida = 0;
            TiempoFinal = 0;
            VelocidadPromedio = 0;
            Estado = "Inscrito";
        }
        
        public static Competidor Registrar(int id, string nombre, int numero)
        {
            return new Competidor(id, nombre, numero);
        }
        
        public void ActualizarTiempo(float tiempo)
        {
            TiempoFinal = tiempo;
        }        
        public void ActualizarCompetidor(Competidor nuevoEstado)
        {
            DistanciaRecorrida = nuevoEstado.DistanciaRecorrida;
            TiempoFinal = nuevoEstado.TiempoFinal;
            VelocidadPromedio = nuevoEstado.VelocidadPromedio;
            Estado = nuevoEstado.Estado;
        }
    }

}
