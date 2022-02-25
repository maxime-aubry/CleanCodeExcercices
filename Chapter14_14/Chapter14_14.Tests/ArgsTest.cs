using NUnit.Framework;
using System;

namespace Chapter14_14.Tests
{
    [TestFixture]
    public class argsTest
    {
        [Test]
        public void testCreateWithNoSchemaOrArguments()
        {
            Args args = new Args("", new string[0]);
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(0, args.cardinality());
        }

        [Test]
        public void testWithNoSchemaButWithOneArgument()
        {
            try
            {
                new Args("", new string[] { "-x" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testWithNoSchemaButWithMultipleArguments()
        {
            try
            {
                new Args("", new string[] { "-x", "-y" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testNonLetterSchema()
        {
            try
            {
                new Args("*", new string[] { });
            }
            catch (FormatException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.INVALID_ARGUMENT_NAME, e.getErrorCode());
                Assert.AreEqual('*', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testInvalidArgumentFormat()
        {
            try
            {
                new Args("f~", new string[] { });
            }
            catch (Exception e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.INVALID_FORMAT, e.getErrorCode());
                Assert.AreEqual('f', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testSimpleBooleanPresent()
        {
            Args args = new Args("x", new string[] { "-x" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(1, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.IsTrue(args.getBoolean('x'));
        }

        [Test]
        public void testSimpleStringPresent()
        {
            Args args = new Args("x*", new string[] { "-x", "param" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(1, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.AreEqual("param", args.getString('x'));
        }

        [Test]
        public void testMissingStringArgument()
        {
            try
            {
                new Args("x*", new string[] { "-x" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.MISSING_STRING, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testSpacesInFormat()
        {
            Args args = new Args("x, y", new string[] { "-xy" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(2, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.IsTrue(args.has('y'));
        }

        [Test]
        public void testSimpleIntPresent()
        {
            Args args = new Args("x#", new string[] { "-x", "42" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(1, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.AreEqual(42, args.getInt('x'));
        }

        [Test]
        public void testInvalidInteger()
        {
            try
            {
                new Args("x#", new string[] { "-x", "Forty two" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.INVALID_INTEGER, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
                Assert.AreEqual("Forty two", e.getErrorParameter());
            }
        }

        [Test]
        public void testMissingInteger()
        {
            try
            {
                new Args("x#", new string[] { "-x" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.MISSING_INTEGER, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
            }
        }

        [Test]
        public void testSimpleDoublePresent()
        {
            Args args = new Args("x##", new string[] { "-x", "42.3" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(1, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.AreEqual(42.3, args.getDouble('x'), .001);
        }

        [Test]
        public void testInvalidDouble()
        {
            try
            {
                new Args("x##", new string[] { "-x", "Forty two" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.INVALID_DOUBLE, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
                Assert.AreEqual("Forty two", e.getErrorParameter());
            }
        }

        [Test]
        public void testMissingDouble()
        {
            try
            {
                new Args("x##", new string[] { "-x" });
            }
            catch (ArgsException e)
            {
                Assert.AreEqual(ArgsException.ErrorCode.MISSING_DOUBLE, e.getErrorCode());
                Assert.AreEqual('x', e.getErrorArgumentId());
            }
        }
    }
}