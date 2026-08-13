namespace WebFormsMejoresPracticas.Models
{
    public class Contacto
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int TipoContactoId { get; set; }

        public string Valor { get; set; }

        public Cliente Cliente { get; set; }

        public TipoContacto TipoContacto { get; set; }

        public string ClienteNombre { get; set; }

        public string TipoContactoDescripcion { get; set; }

    }
}