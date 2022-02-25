using Chapter14_16.Marshalers;
using System;
using System.Collections.Generic;

namespace Chapter14_16
{
    public class Args
    {
        private string schema;
        private bool valid = true;
        private Dictionary<char, ArgumentMarshaler> marshalers = new Dictionary<char, ArgumentMarshaler>();
        private HashSet<char> argsFound = new HashSet<char>();
        private IEnumerator<string> currentArgument;
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
                this.marshalers[elementId] = new BooleanArgumentMarshaler(elementId);
            else if (elementTail.Equals("*"))
                this.marshalers[elementId] = new StringArgumentMarshaler(elementId);
            else if (elementTail.Equals("#"))
                this.marshalers[elementId] = new IntegerArgumentMarshaler(elementId);
            else if (elementTail.Equals("##"))
                this.marshalers[elementId] = new DoubleArgumentMarshaler(elementId);
            else
                throw new ArgsException(ArgsException.ErrorCode.INVALID_FORMAT, elementId, elementTail);
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new ArgsException(ArgsException.ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
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
                throw new ArgsException(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
            }
        }

        private bool setArgument(char argChar)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(argChar);
            if (am == null)
                return false;

            try
            {
                this.currentArgument.MoveNext();
                am.set(this.currentArgument);
                return true;
            }
            catch (ArgsException e)
            {
                this.valid = false;
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
                return (am == null) ? 0 : (double)am.get();
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

