using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dominio.Exceptions
{
    public class SystemPlusException : Exception
    {
        public List<string> Errores { get; set; } = new List<string>();

        public SystemPlusException()
        {
        }

        public SystemPlusException(string message) : base(message)
        {
            this.Errores.Add(message);
        }

        public SystemPlusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SystemPlusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}