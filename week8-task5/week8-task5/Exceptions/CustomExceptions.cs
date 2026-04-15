using System;

namespace week8_task5.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }
}