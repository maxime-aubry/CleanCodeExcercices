using Chapter14_11.Marshalers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter14_11
{
    public class Args
    {
        private string schema;
        private string[] args;
        private bool valid = true;
        private SortedSet<char> unexpectedArguments = new SortedSet<char>();
        private Dictionary<char, ArgumentMarshaler> marshalers = new Dictionary<char, ArgumentMarshaler>();
        private HashSet<char> argsFound = new HashSet<char>();
        private int currentArgument;
        private char errorArgumentId = '\0';
        private string errorParameter = "TILT";
        private ErrorCode errorCode = ErrorCode.OK;

        public enum ErrorCode
        {
            OK,
            MISSING_STRING,
            MISSING_INTEGER,
            INVALID_INTEGER,
            UNEXPECTED_ARGUMENT
        }

        public Args(string schema, string[] args)
        {
            this.schema = schema;
            this.args = args;
            this.valid = parse();
        }

        private bool parse()
        {
            if (this.schema.Length == 0 && this.args.Length == 0)
                return true;
            parseSchema();
            try
            {
                parseArguments();
            }
            catch (ArgsException e)
            {

            }
            return this.valid;
        }

        private bool parseSchema()
        {
            foreach (string element in this.schema.Split(","))
            {
                if (element.Length > 0)
                {
                    string trimmedElement = element.Trim();
                    parseSchemaElement(trimmedElement);
                }
            }
            return true;
        }

        private void parseSchemaElement(string element)
        {
            char elementId = element[0];
            string elementTail = element.Substring(1);
            validateSchemaElementId(elementId);
            if (isBooleanSchemaElement(elementTail))
                this.marshalers[elementId] = new BooleanArgumentMarshaler();
            else if (isStringSchemaElement(elementTail))
                this.marshalers[elementId] = new StringArgumentMarshaler();
            else if (isIntegerSchemaElement(elementTail))
                this.marshalers[elementId] = new IntegerArgumentMarshaler();
            else
                throw new FormatException($"Arguement: {elementId} has invalid format: {elementTail}.");
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new FormatException("Bad characted:" + elementId + "in Args format: " + schema);
        }

        private bool isStringSchemaElement(string elementTail)
        {
            return elementTail.Equals("*");
        }

        private bool isBooleanSchemaElement(string elementTail)
        {
            return elementTail.Length == 0;
        }

        private bool isIntegerSchemaElement(string elementTail)
        {
            return elementTail.Equals("#");
        }

        private bool parseArguments()
        {
            for (this.currentArgument = 0; this.currentArgument < this.args.Length; this.currentArgument++)
            {
                string arg = this.args[this.currentArgument];
                parseArgument(arg);
            }
            return true;
        }

        private void parseArgument(string arg)
        {
            if (arg.StartsWith("-"))
                parseElements(arg);
        }

        private void parseElements(string arg)
        {
            for (int i = 1; i < arg.Length; i++)
                parseElement(arg[i]);
        }

        private void parseElement(char argChar)
        {
            if (setArgument(argChar))
                this.argsFound.Add(argChar);
            else
            {
                this.unexpectedArguments.Add(argChar);
                this.errorCode = ErrorCode.UNEXPECTED_ARGUMENT;
                this.valid = false;
            }
        }

        private bool setArgument(char argChar)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(argChar);

            try
            {
                if (am is BooleanArgumentMarshaler)
                    setBooleanArg(am);
                else if (am is StringArgumentMarshaler)
                    setStringArg(am);
                else if (am is IntegerArgumentMarshaler)
                    setIntArg(am);
                else
                    return false;
            }
            catch(ArgsException e)
            {
                this.valid = false;
                this.errorArgumentId = argChar;
                throw e;
            }
            return true;
        }

        private void setIntArg(ArgumentMarshaler am)
        {
            this.currentArgument++;
            string parameter = null;
            try
            {
                parameter = this.args[this.currentArgument];
                am.set(parameter);
            }
            catch (IndexOutOfRangeException e)
            {
                this.errorCode = ErrorCode.MISSING_INTEGER;
                throw new ArgsException();
            }
            catch (ArgsException e)
            {
                this.errorParameter = parameter;
                this.errorCode = ErrorCode.INVALID_INTEGER;
                throw e;
            }
        }

        private void setStringArg(ArgumentMarshaler am)
        {
            this.currentArgument++;
            try
            {
                am.set(this.args[this.currentArgument]);
            }
            catch (IndexOutOfRangeException e)
            {
                this.errorCode = ErrorCode.MISSING_STRING;
                throw new ArgsException();
            }
        }

        private void setBooleanArg(ArgumentMarshaler am)
        {
            try
            {
                am.set("true");
            }
            catch (ArgsException e)
            {

            }
        }

        public int cardinality()
        {
            return this.argsFound.Count;
        }

        public string usage()
        {
            if (this.schema.Length > 0)
                return "-[" + this.schema + "]";
            else
                return "";
        }

        public string errorMessage()
        {
            switch (this.errorCode)
            {
                case ErrorCode.OK:
                    throw new Exception("TILT: Should not get here.");
                case ErrorCode.UNEXPECTED_ARGUMENT:
                    return unexpectedArgumentMessage();
                case ErrorCode.MISSING_STRING:
                    return $"Could not find string parameter for {this.errorArgumentId}.";
                case ErrorCode.INVALID_INTEGER:
                    return $"Argument -{this.errorArgumentId} expects an integer but was '{this.errorParameter}'.";
                case ErrorCode.MISSING_INTEGER:
                    return $"Could not find integer parameter for -{this.errorArgumentId}.";
            }
            return "";
        }

        private string unexpectedArgumentMessage()
        {
            StringBuilder message = new StringBuilder("Argument(s) -");
            foreach (char c in this.unexpectedArguments)
            {
                message.Append(c);
            }
            message.Append(" unexpected.");
            return message.ToString();
        }


        public string getString(char arg)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(arg);
            try
            {
                return (am == null) ? "" : (string)am.get();
            }
            catch (InvalidCastException e)
            {
                return "";
            }
        }

        public int getInt(char arg)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(arg);
            try
            {
                return (am == null) ? 0 : (int)am.get();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool getBoolean(char arg)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(arg);
            bool b;
            try
            {
                b = (am != null && (bool)am.get());
            }
            catch (InvalidCastException e)
            {
                b = false;
            }
            return b;
        }

        public bool has(char arg)
        {
            return this.argsFound.Contains(arg);
        }

        public bool isValid()
        {
            return this.valid;
        }

        public class ArgsException : Exception
        {

        }
    }
}

