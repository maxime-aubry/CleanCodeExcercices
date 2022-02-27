using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter14_08
{
    public class Args
    {
        private string schema;
        private string[] args;
        private bool valid = true;
        private SortedSet<char> unexpectedArguments = new SortedSet<char>();
        private Dictionary<char, bool> booleanArgs = new Dictionary<char, bool>();
        private Dictionary<char, string> stringArgs = new Dictionary<char, string>();
        private Dictionary<char, int> intArgs = new Dictionary<char, int>();
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
                parseBooleanSchemaElement(elementId);
            else if (isStringSchemaElement(elementTail))
                parseStringSchemaElement(elementId);
            else if (isIntegerSchemaElement(elementTail))
                parseIntegerSchemaElement(elementId);
            else
                throw new FormatException($"Arguement: {elementId} has invalid format: {elementTail}.");
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new FormatException("Bad characted:" + elementId + "in Args format: " + schema);
        }

        private void parseBooleanSchemaElement(char elementId)
        {
            this.booleanArgs.Add(elementId, false);
        }

        private void parseIntegerSchemaElement(char elementId)
        {
            this.intArgs.Add(elementId, 0);
        }

        private void parseStringSchemaElement(char elementId)
        {
            this.stringArgs.Add(elementId, "");
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
                argsFound.Add(argChar);
            else
            {
                this.unexpectedArguments.Add(argChar);
                this.errorCode = ErrorCode.UNEXPECTED_ARGUMENT;
                this.valid = false;
            }
        }

        private bool setArgument(char argChar)
        {
            if (isBooleanArg(argChar))
                setBooleanArg(argChar, true);
            else if (isStringArg(argChar))
                setStringArg(argChar);
            else if (isIntArg(argChar))
                setIntArg(argChar);
            else
                return false;

            return true;
        }

        private bool isIntArg(char argChar)
        {
            return this.intArgs.ContainsKey(argChar);
        }

        private void setIntArg(char argChar)
        {
            this.currentArgument++;
            string parameter = null;
            try
            {
                parameter = this.args[this.currentArgument];
                this.intArgs[argChar] = Int32.Parse(parameter);
            }
            catch (IndexOutOfRangeException e)
            {
                this.valid = false;
                this.errorArgumentId = argChar;
                this.errorCode = ErrorCode.MISSING_INTEGER;
                throw new ArgsException();
            }
            catch (FormatException e)
            {
                this.valid = false;
                this.errorArgumentId = argChar;
                this.errorParameter = parameter;
                this.errorCode = ErrorCode.INVALID_INTEGER;
                throw new ArgsException();
            }
        }

        private void setStringArg(char argChar)
        {
            this.currentArgument++;
            try
            {
                this.stringArgs[argChar] = this.args[this.currentArgument];
            }
            catch (IndexOutOfRangeException e)
            {
                this.valid = false;
                this.errorArgumentId = argChar;
                this.errorCode = ErrorCode.MISSING_STRING;
                throw new ArgsException();
            }
        }

        private bool isStringArg(char argChar)
        {
            return this.stringArgs.ContainsKey(argChar);
        }

        private void setBooleanArg(char argChar, bool value)
        {
            this.booleanArgs[argChar] = value;
        }

        private bool isBooleanArg(char argChar)
        {
            return this.booleanArgs.ContainsKey(argChar);
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

        private bool falseIfNull(bool? b)
        {
            return (b.HasValue && b.Value);
        }

        private int zeroIfNull(int? i)
        {
            return (int)((i is null) ? 0 : i);
        }

        private string blankIfNull(string s)
        {
            return (s == null) ? "" : s;
        }

        public string getString(char arg)
        {
            return this.blankIfNull(this.stringArgs[arg]);
        }

        public int getInt(char arg)
        {
            return this.zeroIfNull(this.intArgs[arg]);
        }

        public bool getBoolean(char arg)
        {
            return this.falseIfNull(this.booleanArgs[arg]);
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

