using System;

namespace WebFormsMejoresPracticas.Exceptions
{
    public class ClienteTieneContactosException : Exception
    {
        public ClienteTieneContactosException()
            : base("No se puede eliminar el cliente porque tiene contactos registrados.")
        {

        }
    }
}