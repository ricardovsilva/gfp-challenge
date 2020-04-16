namespace domain.exceptions
{
    [System.Serializable]
    public class InvalidOptionException : System.Exception
    {
        public InvalidOptionException() { }
        public InvalidOptionException(string message) : base(message) { }
        public InvalidOptionException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidOptionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}