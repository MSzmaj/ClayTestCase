using System;

namespace Common.Exceptions {
    
    [Serializable]
    public class ModelValidationException : Exception {
        public ModelValidationException(string message) 
        : base($"Model invalid: {message}") { }
    }
}