using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Noobeex.CodeContract.Tests
{
    [TestClass]
    public class ArgumentsTest
    {
        private const string NotEmptyString = "Some not empty string";
        private static readonly IList<string> NotEmptyCollection = new List<string> { string.Empty };
        private static readonly IList<string> EmptyCollection = new List<string>();

        #region Requires

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Requires_FalseCondition_ThrowsException()
        {
            Arguments.Requires(false);
        }

        [TestMethod]
        public void Requires_TrueCondition_DoesNotThrowException()
        {
            Arguments.Requires(true);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void RequiresWithArgName_FalseCondition_ThrowsException(string message)
        {
            try
            {
                Arguments.Requires(false, message);
            }
            catch (ArgumentException ex)
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
        [DataRow("ArgName")]
        public void RequiresWithArgName_TrueCondition_DoesNotThrowException(string argName)
        {
            Arguments.Requires(true, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void RequiresWithArgNameAndMessage_FalseCondition_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.Requires(false, message, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'Requires' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void RequiresWithArgNameNameAndMessage_TrueCondition_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.Requires(true, argName, message);
        }

        #endregion

        #region Forbids

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Forbids_TrueCondition_ThrowsException()
        {
            Arguments.Forbids(true);
        }

        [TestMethod]
        public void Forbids_FalseCondition_DoesNotThrowException()
        {
            Arguments.Forbids(false);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Message")]
        public void ForbidsWithArgName_TrueCondition_ThrowsException(string message)
        {
            try
            {
                Arguments.Forbids(true, message);
            }
            catch (ArgumentException ex)
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
        [DataRow("ArgName")]
        public void ForbidsWithArgName_FalseCondition_DoesNotThrowException(string argName)
        {
            Arguments.Forbids(false, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void ForbidsWithArgNameAndMessage_TrueCondition_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.Forbids(true, message, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'Forbids' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void ForbidsWithArgNameNameAndMessage_FalseCondition_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.Forbids(false, argName, message);
        }

        #endregion

        #region NotNull

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNull_Null_ThrowsException()
        {
            Arguments.NotNull(null);
        }

        [TestMethod]
        public void NotNull_NotNull_DoesNotThrowException()
        {
            Arguments.NotNull(string.Empty);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullWithArgName_Null_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNull(null, argName);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNull' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullWithArgName_NotNull_DoesNotThrowException(string argName)
        {
            Arguments.NotNull(string.Empty, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotNullWithArgNameAndMessage_Null_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotNull(null, argName, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNull' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullWithArgNameNameAndMessage_NotNull_DoesNotThrowException(string argName, string message)
        {
            Arguments.NotNull(string.Empty, argName, message);
        }

        #endregion

        #region NotNullOrEmpty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullOrEmpty_Null_ThrowsException()
        {
            Arguments.NotNullOrEmpty(null);
        }

        [TestMethod]
        public void NotNullOrEmpty_NotNullNotEmpty_DoesNotThrowException()
        {
            Arguments.NotNullOrEmpty(NotEmptyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotNullOrEmpty_Empty_ThrowsException()
        {
            Arguments.NotNullOrEmpty(string.Empty);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_Null_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty(null, argName);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NotNullOrEmpty_DoesNotThrowException(string argName)
        {
            Arguments.NotNullOrEmpty(NotEmptyString, argName);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_Empty_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty(string.Empty, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotNullOrEmptyWithArgNameAndMessage_Null_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotNullOrEmpty(null, argName, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWith_hArgNameNameAndMessage_NotNullOrEmpty_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.NotNullOrEmpty(NotEmptyString, argName, message);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWith_hArgNameNameAndMessage_Empty_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotNullOrEmpty(string.Empty, argName, message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        #endregion

        #region NotEmpty

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotEmpty_Empty_ThrowsException()
        {
            Arguments.NotEmpty(string.Empty);
        }

        [TestMethod]
        public void NotEmpty_NotEmpty_DoesNotThrowException()
        {
            Arguments.NotEmpty(NotEmptyString);
        }

        [TestMethod]
        public void NotEmpty_Null_DoesNotThrowException()
        {
            Arguments.NotEmpty(null);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_Empty_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotEmpty(string.Empty, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NotEmpty_DoesNotThrowException(string argName)
        {
            Arguments.NotEmpty(NotEmptyString, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotEmptyWithArgNameAndMessage_Empty_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotEmpty(string.Empty, argName, message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameNameAndMessage_NotEmpty_DoesNotThrowException(string argName, string message)
        {
            Arguments.NotEmpty(NotEmptyString, argName, message);
        }

        #endregion

        #region NotEmpty for enumerable

        [TestMethod]
        public void NotEmpty_NullEnumerable_ReturnsNull()
        {
            var result = Arguments.NotEmpty((IEnumerable<string>?)null);

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotEmpty_EmptyEnumerable_ThrowsException()
        {
            _ = Arguments.NotEmpty((IEnumerable<string>)EmptyCollection);
        }

        [TestMethod]
        public void NotEmpty_NotEmptyEnumerable_ReturnsCollectionCopy()
        {
            var result = Arguments.NotEmpty((IEnumerable<string>)NotEmptyCollection);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NullEnumerable_ReturnsNull(string argName)
        {
            var result = Arguments.NotEmpty((IEnumerable<string>?)null, argName);

            Assert.IsNull(result);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_EmptyEnumerable_ThrowsException(string argName)
        {
            try
            {
                _ = Arguments.NotEmpty((IEnumerable<string>)EmptyCollection, argName);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NotEmptyEnumerable_ReturnsCollectionCopy(string argName)
        {
            var result = Arguments.NotEmpty((IEnumerable<string>)NotEmptyCollection, argName);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NullEnumerable_ReturnsNull(string argName, string message)
        {
            var result = Arguments.NotEmpty((IEnumerable<string>?)null, argName, message);

            Assert.IsNull(result);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_EmptyEnumerable_ThrowsException(string argName, string message)
        {
            try
            {
                _ = Arguments.NotEmpty((IEnumerable<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NotEmptyEnumerable_ReturnsCollectionCopy(string argName,
            string message)
        {
            var result = Arguments.NotEmpty((IEnumerable<string>)NotEmptyCollection, argName, message);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        #endregion

        #region NotNullOrEmpty for enumerable

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullOrEmpty_NullEnumerable_ThrowsException()
        {
            Arguments.NotNullOrEmpty((IEnumerable<string>?)null);
        }

        [TestMethod]
        public void NotNullOrEmpty_NotEmptyEnumerable_ReturnsCollectionCopy()
        {
            var result = Arguments.NotNullOrEmpty((IEnumerable<string>)NotEmptyCollection);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotNullOrEmpty_EmptyEnumerable_ThrowsException()
        {
            Arguments.NotNullOrEmpty((IEnumerable<string>)EmptyCollection);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NullEnumerable_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((IEnumerable<string>?)null, argName);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NotEmptyEnumerable_ReturnsCollectionCopy(string argName)
        {
            var result = Arguments.NotNullOrEmpty((IEnumerable<string>)NotEmptyCollection, argName);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_EmptyEnumerable_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((IEnumerable<string>)EmptyCollection, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotNullOrEmptyWithArgNameAndMessage_NullEnumerable_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((IEnumerable<string>?)null, argName, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_NotEmptyEnumerable_ReturnsCollectionCopy(string argName,
            string message)
        {
            var result = Arguments.NotNullOrEmpty((IEnumerable<string>)NotEmptyCollection, argName, message);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.SequenceEqual(NotEmptyCollection));
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_EmptyEnumerable_ThrowsException(string argName,
            string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((IEnumerable<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        #endregion

        #region NotEmpty for collection

        [TestMethod]
        public void NotEmpty_NullCollection_DoesNotThrowException()
        {
            Arguments.NotEmpty((ICollection<string>?)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotEmpty_EmptyCollection_ThrowsException()
        {
            Arguments.NotEmpty((ICollection<string>)EmptyCollection);
        }

        [TestMethod]
        public void NotEmpty_NotEmptyCollection_DoesNotThrowException()
        {
            Arguments.NotEmpty((ICollection<string>)NotEmptyCollection);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NullCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotEmpty((ICollection<string>?)null, argName);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_EmptyCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotEmpty((ICollection<string>)EmptyCollection, argName);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NotEmptyCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotEmpty((ICollection<string>)NotEmptyCollection, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NullCollection_DoesNotThrowException(string argName, string message)
        {
            Arguments.NotEmpty((ICollection<string>?)null, argName, message);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_EmptyCollection_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotEmpty((ICollection<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NotEmptyCollection_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.NotEmpty((ICollection<string>)NotEmptyCollection, argName, message);
        }

        #endregion

        #region NotNullOrEmpty for collection

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullOrEmpty_NullCollection_ThrowsException()
        {
            Arguments.NotNullOrEmpty((ICollection<string>?)null);
        }

        [TestMethod]
        public void NotNullOrEmpty_NotEmptyCollection_DoesNotThrowException()
        {
            Arguments.NotNullOrEmpty((ICollection<string>)NotEmptyCollection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotNullOrEmpty_EmptyCollection_ThrowsException()
        {
            Arguments.NotNullOrEmpty((ICollection<string>)EmptyCollection);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NullCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((ICollection<string>?)null, argName);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NotEmptyCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotNullOrEmpty((ICollection<string>)NotEmptyCollection, argName);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_EmptyCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((ICollection<string>)EmptyCollection, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotNullOrEmptyWithArgNameAndMessage_NullCollection_ThrowsException(string argName, string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((ICollection<string>?)null, argName, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_NotEmptyCollection_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.NotNullOrEmpty((ICollection<string>)NotEmptyCollection, argName, message);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_EmptyCollection_ThrowsException(string argName,
            string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((ICollection<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        #endregion

        #region NotEmpty for readonly collection

        [TestMethod]
        public void NotEmpty_NullReadOnlyCollection_DoesNotThrowException()
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>?)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotEmpty_EmptyReadOnlyCollection_ThrowsException()
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>)EmptyCollection);
        }

        [TestMethod]
        public void NotEmpty_NotEmptyReadOnlyCollection_DoesNotThrowException()
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>)NotEmptyCollection);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NullReadOnlyCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>?)null, argName);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_EmptyReadOnlyCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotEmpty((IReadOnlyCollection<string>)EmptyCollection, argName);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotEmptyWithArgName_NotEmptyReadOnlyCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>)NotEmptyCollection, argName);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NullReadOnlyCollection_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>?)null, argName, message);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_EmptyReadOnlyCollection_ThrowsException(string argName,
            string message)
        {
            try
            {
                Arguments.NotEmpty((IReadOnlyCollection<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentEmptyException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "The message")]
        public void NotEmptyWithArgNameAndMessage_NotEmptyReadOnlyCollection_DoesNotThrowException(string argName,
            string message)
        {
            Arguments.NotEmpty((IReadOnlyCollection<string>)NotEmptyCollection, argName, message);
        }

        #endregion

        #region NotNullOrEmpty for readonly collection

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullOrEmpty_NullReadOnlyCollection_ThrowsException()
        {
            Arguments.NotNullOrEmpty((IReadOnlyCollection<string>?)null);
        }

        [TestMethod]
        public void NotNullOrEmpty_NotEmptyReadOnlyCollection_DoesNotThrowException()
        {
            Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)NotEmptyCollection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentEmptyException))]
        public void NotNullOrEmpty_EmptyReadOnlyCollection_ThrowsException()
        {
            Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)EmptyCollection);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NullReadOnlyCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((IReadOnlyCollection<string>?)null, argName);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_NotEmptyReadOnlyCollection_DoesNotThrowException(string argName)
        {
            Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)NotEmptyCollection, argName);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("ArgName")]
        public void NotNullOrEmptyWithArgName_EmptyReadOnlyCollection_ThrowsException(string argName)
        {
            try
            {
                Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)EmptyCollection, argName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);
                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "Message")]
        [DataRow("ArgName", "Some message")]
        public void NotNullOrEmptyWithArgNameAndMessage_NullReadOnlyCollection_ThrowsException(string argName,
            string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((IReadOnlyCollection<string>?)null, argName, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_NotEmptyReadOnlyCollection_DoesNotThrowException(
            string argName, string message)
        {
            Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)NotEmptyCollection, argName, message);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("ArgName", "ArgName")]
        public void NotNullOrEmptyWithArgNameNameAndMessage_EmptyReadOnlyCollection_ThrowsException(string argName,
            string message)
        {
            try
            {
                Arguments.NotNullOrEmpty((IReadOnlyCollection<string>)EmptyCollection, argName, message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(argName, ex.ParamName);

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.IsTrue(ex.Message.StartsWith(message));
                }

                return;
            }

            Assert.Fail("'NotNullOrEmpty' didn't throw excepted exception.");
        }

        #endregion
    }
}