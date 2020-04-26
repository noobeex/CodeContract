using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Noobeex.CodeContract.Tests
{
    [TestClass]
    public class OperationTest
    {
        #region Requires

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Requires_FalseCondition_ThrowsException()
        {
            Operation.Requires(false);
        }

        [TestMethod]
        public void Requires_TrueCondition_DoesNotThrowException()
        {
            Operation.Requires(true);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void RequiresWithMessage_FalseCondition_ThrowsException(string message)
        {
            try
            {
                Operation.Requires(false, message);
            }
            catch (InvalidOperationException ex)
            {
                if (message != null)
                {
                    Assert.AreEqual(message, ex.Message);
                }

                return;
            }

            Assert.Fail("'Requires' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void RequiresWithMessage_TrueCondition_DoesNotThrowException(string message)
        {
            Operation.Requires(true, message);
        }

        #endregion

        #region Forbids

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Forbids_TrueCondition_ThrowsException()
        {
            Operation.Forbids(true);
        }

        [TestMethod]
        public void Forbids_FalseCondition_DoesNotThrowException()
        {
            Operation.Forbids(false);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void ForbidsWithMessage_TrueCondition_ThrowsException(string message)
        {
            try
            {
                Operation.Forbids(true, message);
            }
            catch (InvalidOperationException ex)
            {
                if (message != null)
                {
                    Assert.AreEqual(message, ex.Message);
                }

                return;
            }

            Assert.Fail("'Forbids' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void ForbidsWithMessage_FalseCondition_DoesNotThrowException(string message)
        {
            Operation.Forbids(false, message);
        }

        #endregion
    }
}