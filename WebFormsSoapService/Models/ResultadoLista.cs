using System.Collections.Generic;

namespace WebFormsSoapService.Models
{
    public class ResultadoLista<T>
    {
        public bool Exitoso { get; set; }

        public string Mensaje { get; set; }

        public List<T> Datos { get; set; }
    }
}