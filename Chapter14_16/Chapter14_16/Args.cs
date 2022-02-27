using Chapter14_16.Marshalers;
using System;
using System.Collections.Generic;

namespace Chapter14_16
{
    public class Args
    {
        private Dictionary<char, ArgumentMarshaler> marshalers = new Dictionary<char, ArgumentMarshaler>();
        private HashSet<char> argsFound = new HashSet<char>();
        private IEnumerator<string> currentArgument;

        public Args(string schema, string[] args)
        {
            parseSchema(schema);
            parseArgumentStrings(new List<string>(args));
        }

        private void parseSchema(string schema)
        {
            foreach (string element in schema.Split(','))
                if (element.Length > 0)
                    parseSchemaElement(element.Trim());
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
                throw new ArgsException(ArgsException.ErrorCode.INVALID_FORMAT, elementId, elementTail);
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new ArgsException(ArgsException.ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
        }

        private void parseArgumentStrings(List<string> argsList)
        {
            for (this.currentArgument = argsList.GetEnumerator(); this.currentArgument.MoveNext();)
            {
                string argument = this.currentArgument.Current;
                if (argument.StartsWith('-'))
                    parseArgumentCharacters(argument.Substring(1));
            }
        }

        private void parseArgumentCharacters(string argChars)
        {
            for (int i = 0; i < argChars.Length; i++)
                parseArgumentCharacter(argChars[i]);
        }

        private void parseArgumentCharacter(char argChar)
        {
            ArgumentMarshaler am = this.marshalers.GetValueOrDefault(argChar);
            if (am == null)
                throw new ArgsException(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);

            this.argsFound.Add(argChar);

            try
            {
                this.currentArgument.MoveNext();
                am.set(this.currentArgument);
            }
            catch (ArgsException e)
            {
                e.setErrorArgumentId(argChar);
                throw e;
            }
        }

        public int cardinality()
        {
            return this.argsFound.Count;
        }

        public bool getBoolean(char arg)
        {
            return BooleanArgumentMarshaler.getValue(this.marshalers.GetValueOrDefault(arg));
        }

        public string getString(char arg)
        {
            return StringArgumentMarshaler.getValue(this.marshalers.GetValueOrDefault(arg));
        }

        public int getInt(char arg)
        {
            return IntegerArgumentMarshaler.getValue(this.marshalers.GetValueOrDefault(arg));
        }

        public double getDouble(char arg)
        {
            return DoubleArgumentMarshaler.getValue(this.marshalers.GetValueOrDefault(arg));
        }

        public bool has(char arg)
        {
            return this.argsFound.Contains(arg);
        }
    }
}

