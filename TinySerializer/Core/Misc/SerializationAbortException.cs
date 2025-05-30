using System;

namespace TinySerializer.Core.Misc {
    public class SerializationAbortException : Exception {
        public SerializationAbortException(string message) : base(message) { }
        
        public SerializationAbortException(string message, Exception innerException) : base(message, innerException) { }
    }
}