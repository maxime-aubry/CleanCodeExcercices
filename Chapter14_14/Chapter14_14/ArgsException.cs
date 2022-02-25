using System;

namespace Chapter14_14
{
    public class ArgsException : Exception
    {
        private char errorArgumentId = '\0';
        private string errorParameter = "TILT";
        private ErrorCode errorCode = ErrorCode.OK;

        public ArgsException() { }

        public ArgsException(string message) : base(message) { }

        //public ArgsException(string message, Exception innerException) : base(message, innerException) { }

        public enum ErrorCode
        {
            OK,
            MISSING_STRING,
            MISSING_INTEGER,
            INVALID_INTEGER,
            MISSING_DOUBLE,
            INVALID_DOUBLE,
            UNEXPECTED_ARGUMENT
        }
    }
}
