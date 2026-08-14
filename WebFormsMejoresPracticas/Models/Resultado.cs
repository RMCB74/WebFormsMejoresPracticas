namespace WebFormsMejoresPracticas.Models
{
    public class Resultado<T>
    {
        public bool Exitoso { get; set; }

        public string Mensaje { get; set; }

        public T Datos { get; set; }
    }
}