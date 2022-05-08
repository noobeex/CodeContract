using System;
using System.Runtime.Serialization;

namespace Noobeex.CodeContract
{
    /// <summary>
    /// The exception that is thrown when one of the arguments
    /// provided to a method is empty.
    /// </summary>
    public class ArgumentEmptyException : ArgumentException
    {
        /// <summary>
        /// The error message to be set to <see cref="ArgumentException.Message"/>
        /// by constructors of <see cref="ArgumentEmptyException"/> which
        /// don't accept a message as an argument.
        /// </summary>
        public static string ErrorMessage { get; set; } =
            "The specified argument must not be empty.";


        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentEmptyException"/> class.
        /// </summary>
        public ArgumentEmptyException()
            : base(ErrorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentEmptyException"/> class.
        /// </summary>
        /// <param name="paramName">
        /// The name of the parameter that caused the current exception.
        /// </param>
        public ArgumentEmptyException(string? paramName)
            : base(ErrorMessage, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentEmptyException"/> class.
        /// </summary>
        /// <param name="paramName">
        /// The name of the parameter that caused the current exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException
        /// parameter is not a null reference, the current exception is raised in a catch
        /// block that handles the inner exception.
        /// </param>
        public ArgumentEmptyException(string? paramName, Exception innerException)
            : base(ErrorMessage, paramName, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentEmptyException"/> class.
        /// </summary>
        /// <param name="paramName">
        /// The name of the parameter that caused the current exception.
        /// </param>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        public ArgumentEmptyException(string? paramName, string? message)
            : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentEmptyException"/> class.
        /// </summary>
        /// <param name="paramName">
        /// The name of the parameter that caused the current exception.
        /// </param>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException
        /// parameter is not a null reference, the current exception is raised in a catch
        /// block that handles the inner exception.
        /// </param>
        public ArgumentEmptyException(string? paramName, string? message, Exception innerException)
            : base(message, paramName, innerException)
        {
        }

        /// <inheritdoc />
        protected ArgumentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}