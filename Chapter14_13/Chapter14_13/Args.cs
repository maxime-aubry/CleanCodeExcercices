using Chapter14_13.Marshalers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter14_13
{
    public class Args
    {
        private string schema;
        private bool valid = true;
        private SortedSet<char> unexpectedArguments = new SortedSet<char>();
        private Dictionary<char, ArgumentMarshaler> marshalers = new Dictionary<char, ArgumentMarshaler>();
        private HashSet<char> argsFound = new HashSet<char>();
        private IEnumerator<string> currentArgument;
        private char errorArgumentId = '\0';
        private string errorParameter = "TILT";
        private ArgsException.ErrorCode errorCode = ArgsException.ErrorCode.OK;
        public List<string> argsList;

        public Args(string schema, string[] args)
        {
            this.schema = schema;
            this.argsList = new List<string>(args);
            this.valid = parse();
        }

        private bool parse()
        {
            if (this.schema.Length == 0 && this.argsList.Count == 0)
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
            if (elementTail.Length == 0)
                this.marshalers[elementId] = new BooleanArgumentMarshaler();
            else if (elementTail.Equals("*"))
                this.marshalers[elementId] = new StringArgumentMarshaler();
            else if (elementTail.Equals("#"))
                this.marshalers[elementId] = new IntegerArgumentMarshaler();
            else if (elementTail.Equals("##"))
                this.marshalers[elementId] = new DoubleArgumentMarshaler();
            else
                throw new ArgsException($"Arguement: {elementId} has invalid format: {elementTail}.");
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new ArgsException("Bad characted:" + elementId + "in Args format: " + schema);
        }

        private bool parseArguments()
        {
            for (this.currentArgument = this.argsList.GetEnumerator(); this.currentArgument.MoveNext();)
            {
                string arg = currentArgument.Current;
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
                this.errorCode = ArgsException.ErrorCode.UNEXPECTED_ARGUMENT;
                this.valid = false;
            }
        }

        private bool setArgument(char argChar)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(argChar);
            if (am == null)
                return false;

            try
            {
                am.set(this.currentArgument);
                return true;
            }
            catch (ArgsException e)
            {
                this.valid = false;
                this.errorArgumentId = argChar;
                throw e;
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
                case ArgsException.ErrorCode.OK:
                    throw new Exception("TILT: Should not get here.");
                case ArgsException.ErrorCode.UNEXPECTED_ARGUMENT:
                    return unexpectedArgumentMessage();
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

        public double getDouble(char arg)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(arg);
            try
            {
                return (am != null) ? 0 : (double)am.get();
            }
            catch (Exception e)
            {
                return 0.0;
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
    }
}

