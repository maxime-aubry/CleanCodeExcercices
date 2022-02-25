using NUnit.Framework;
using System;

namespace Chapter14_15.Tests
{
    [TestFixture]
    public class ArgsExceptionTest
    {
        [Test]
        public void testUnexpectedMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, 'x', null);
            Assert.AreEqual("Arguement -x unexpetec.", e.errorMessage());
        }

        [Test]
        public void testMissingStringMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.MISSING_STRING, 'x', null);
            Assert.AreEqual("Could not find string parameter for -x.", e.errorMessage());
        }

        [Test]
        public void testInvalidIntegerMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.INVALID_INTEGER, 'x', "Forty two");
            Assert.AreEqual("Argument -x expects an integer but was 'Forty two'.", e.errorMessage());
        }

        [Test]
        public void testMissingIntegerMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.MISSING_INTEGER, 'x', null);
            Assert.AreEqual("Could not find integer parameter for -x.", e.errorMessage());
        }

        [Test]
        public void testInvalidDoubleMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.INVALID_DOUBLE, 'x', "Forty two");
            Assert.AreEqual("Argument -x expects an double but was 'Forty two'.", e.errorMessage());
        }

        [Test]
        public void testMissingDoubleMessage()
        {
            ArgsException e = new ArgsException(ArgsException.ErrorCode.MISSING_DOUBLE, 'x', null);
            Assert.AreEqual("Could not find double parameter for -x.", e.errorMessage());
        }
    }
}
