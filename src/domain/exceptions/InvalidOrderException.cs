namespace domain.exceptions
{
    [System.Serializable]
    public class InvalidOrderException : System.Exception
    {
        public InvalidOrderException() { }
        public InvalidOrderException(string message) : base(message) { }
        public InvalidOrderException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidOrderException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}