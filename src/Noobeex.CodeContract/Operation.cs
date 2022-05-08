using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Noobeex.CodeContract
{
    /// <summary>
    /// Provides a set of routines to ensure
    /// method is in the right state for performing operation.
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// Requires the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="false" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Requires([DoesNotReturnIf(false)] bool condition)
        {
            if (!condition)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Requires the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="false" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Requires([DoesNotReturnIf(false)] bool condition, string? message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Forbids the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured not to be <see langword="true" />.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="true" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Forbids([DoesNotReturnIf(true)] bool condition)
        {
            Requires(!condition);
        }

        /// <summary>
        /// Forbids the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured not to be <see langword="true" />.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="true" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Forbids([DoesNotReturnIf(true)] bool condition, string? message)
        {
            Requires(!condition, message);
        }
    }
}