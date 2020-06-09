using System;

namespace Core.Exceptions
{
    public class TransactionValidationException : Exception
    {
        private const string defaultMessage = "Unknown format";
        public TransactionValidationException()
            : base(defaultMessage)
        {
        }

        public TransactionValidationException(Exception inner)
            : base(defaultMessage, inner)
        {
        }

        public TransactionValidationException(string message)
            : base(message)
        {
        }

        public TransactionValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
