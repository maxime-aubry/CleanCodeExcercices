using System;

namespace Chapter14_15
{
    public class ArgsException : Exception
    {
        private char errorArgumentId = '\0';
        private string errorParameter = "TILT";
        private ErrorCode errorCode = ErrorCode.OK;

        public ArgsException() { }

        public ArgsException(string message) : base(message) { }

        public ArgsException(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParameter)
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
        }

        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameter)
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
            this.errorArgumentId = errorArgumentId;
        }

        public char getErrorArgumentId()
        {
            return errorArgumentId;
        }

        public void setErrorArgumentId(char errorArgumentId)
        {
            this.errorArgumentId = errorArgumentId;
        }

        public string getErrorParameter()
        {
            return this.errorParameter;
        }

        public void setErrorParameter(string errorParameter)
        {
            this.errorParameter = errorParameter;
        }

        public ErrorCode getErrorCode()
        {
            return errorCode;
        }

        public void setErrorCode(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public string errorMessage()
        {
            switch (this.errorCode)
            {
                case ArgsException.ErrorCode.OK:
                    throw new Exception("TILT: Should not get here.");
                case ArgsException.ErrorCode.UNEXPECTED_ARGUMENT:
                    return $"Argument {this.errorArgumentId} unexpected..";
                case ArgsException.ErrorCode.MISSING_STRING:
                    return $"Could not find string parameter for {this.errorArgumentId}.";
                case ArgsException.ErrorCode.INVALID_INTEGER:
                    return $"Argument -{this.errorArgumentId} expects an integer but was '{this.errorParameter}'.";
                case ArgsException.ErrorCode.MISSING_INTEGER:
                    return $"Could not find integer parameter for -{this.errorArgumentId}.";
                case ArgsException.ErrorCode.INVALID_DOUBLE:
                    return $"Argument -{this.errorArgumentId} expects an double but was '{this.errorParameter}'.";
                case ArgsException.ErrorCode.MISSING_DOUBLE:
                    return $"Could not find double parameter for -{this.errorArgumentId}.";
            }
            return "";
        }

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
