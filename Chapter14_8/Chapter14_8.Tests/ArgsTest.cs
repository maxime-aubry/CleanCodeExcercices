using NUnit.Framework;
using System;

namespace Chapter14_8.Tests
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
            Args args = new Args("", new string[] { "-x" });
            Assert.IsFalse(args.isValid());
            Assert.AreEqual("Argument(s) -x unexpected.", args.errorMessage());
        }

        [Test]
        public void testWithNoSchemaButWithMultipleArguments()
        {
            Args args = new Args("", new string[] { "-x", "-y" });
            Assert.IsFalse(args.isValid());
            Assert.AreEqual("Argument(s) -xy unexpected.", args.errorMessage());
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
                Assert.AreEqual("Bad characted:*in Args format: *", e.Message);
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
                Assert.AreEqual("Arguement: f has invalid format: ~.", e.Message);
            }
        }

        [Test]
        public void testSimpleBooleanPresent()
        {
            Args args = new Args("x", new string[] { "-x" });
            Assert.IsTrue(args.isValid());
            Assert.AreEqual(1, args.cardinality());
            Assert.IsTrue(args.has('x'));
            Assert.AreEqual(true, args.getBoolean('x'));
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
            Args args = new Args("x*", new string[] { "-x" });
            Assert.IsFalse(args.isValid());
            Assert.AreEqual(0, args.cardinality());
            Assert.IsFalse(args.has('x'));
            Assert.AreEqual("Could not find string parameter for x.", args.errorMessage());
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
            Args args = new Args("x#", new string[] { "-x", "Forty two" });
            Assert.IsFalse(args.isValid());
            Assert.AreEqual(0, args.cardinality());
            Assert.IsFalse(args.has('x'));
            Assert.AreEqual("Argument -x expects an integer but was 'Forty two'.", args.errorMessage());
        }

        [Test]
        public void testMissingInteger()
        {
            Args args = new Args("x#", new string[] { "-x" });
            Assert.IsFalse(args.isValid());
            Assert.AreEqual(0, args.cardinality());
            Assert.IsFalse(args.has('x'));
            Assert.AreEqual("Could not find integer parameter for -x.", args.errorMessage());
        }
    }
}