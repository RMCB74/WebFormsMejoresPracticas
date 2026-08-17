using System.ComponentModel.DataAnnotations.Schema;


namespace WebFormsSoapService.Models
{
    //public class Contacto
    //{
    //    public int Id { get; set; }

    //    public int ClienteId { get; set; }

    //    public int TipoContactoId { get; set; }

    //    public string Valor { get; set; }

    //    public Cliente Cliente { get; set; }

    //    public TipoContacto TipoContacto { get; set; }

    //    public string ClienteNombre { get; set; }

    //    public string TipoContactoDescripcion { get; set; }

    //}

    //public class Contacto
    //{
    //    public int Id { get; set; }

    //    public int ClienteId { get; set; }

    //    public int TipoContactoId { get; set; }

    //    public string Valor { get; set; }

    //    public virtual Cliente Cliente { get; set; }

    //    public virtual TipoContacto TipoContacto { get; set; }
    //}

    public class Contacto
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int TipoContactoId { get; set; }

        public string Valor { get; set; }

        public Cliente Cliente { get; set; }

        public TipoContacto TipoContacto { get; set; }

        [NotMapped]
        public string ClienteNombre { get; set; }

        [NotMapped]
        public string TipoContactoDescripcion { get; set; }


    }

}