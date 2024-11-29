using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Excepciones
{
    public class ProcessException : Exception
    {

        //Propiedad publica que retorna los detalles de solo lectura
        public ReadOnlyCollection<string> Details => _details.AsReadOnly();

        private readonly List<string> _details = new List<string>();

        public ProcessException(string message, List<string> details) : base(message)
        {
            _details = details;
        }

        public ProcessException(string message) : base(message)
        {
        }
        
        public ProcessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
