using System;
using System.Runtime.Serialization;

namespace domain.exceptions
{
    [Serializable]
    public class DishValidationAlreadyAddedException : Exception
    {
        public DishValidationAlreadyAddedException()
        {
        }

        public DishValidationAlreadyAddedException(string message) : base(message)
        {
        }

        public DishValidationAlreadyAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DishValidationAlreadyAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}