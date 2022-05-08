using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Noobeex.CodeContract
{
    /// <summary>
    /// Provides a set of routines to ensure
    /// method arguments meets preconditions.
    /// </summary>
    public static class Arguments
    {
        /// <summary>
        /// Requires the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="false" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Requires([DoesNotReturnIf(false)] bool condition)
        {
            Requires(condition, null);
        }

        /// <summary>
        /// Requires the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="false" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Requires([DoesNotReturnIf(false)] bool condition, string? message)
        {
            Requires(condition, message, null);
        }

        /// <summary>
        /// Requires the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <param name="argName">
        /// The name of the method argument being checked against
        /// the specified <paramref name="condition"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="false" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Requires([DoesNotReturnIf(false)] bool condition, string? message, string? argName)
        {
            if (!condition)
            {
                throw new ArgumentException(message, argName);
            }
        }

        /// <summary>
        /// Forbids the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured not to be <see langword="true" />.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="true" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Forbids([DoesNotReturnIf(true)] bool condition)
        {
            Forbids(condition, null);
        }

        /// <summary>
        /// Forbids the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured not to be <see langword="true" />.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="true" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Forbids([DoesNotReturnIf(true)] bool condition, string? message)
        {
            Forbids(condition, message, null);
        }

        /// <summary>
        /// Forbids the specified <paramref name="condition"/> to
        /// be <see langword="true"/>. Otherwise throws an
        /// <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">The condition to be ensured not to be <see langword="true" />.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <param name="argName">
        /// The name of the method argument being checked against
        /// the specified <paramref name="condition"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified <paramref name="condition"/> is <see langword="true" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void Forbids([DoesNotReturnIf(true)] bool condition, string? message, string? argName)
        {
            if (condition)
            {
                throw new ArgumentException(message, argName);
            }
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not <see langword="null"/>.
        /// Otherwise throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked on null.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNull([NotNull] object? argument)
        {
            NotNull(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not <see langword="null"/>.
        /// Otherwise throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked on null.</param>
        /// <param name="argName">
        /// The name of the method argument being checked on null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNull([NotNull] object? argument, string? argName)
        {
            NotNull(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not <see langword="null"/>.
        /// Otherwise throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked on null.</param>
        /// <param name="argName">
        /// The name of the method argument being checked on null.
        /// </param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNull([NotNull] object? argument, string? argName, string? message)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argName, message);
            }
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or empty. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty([NotNull] string? argument)
        {
            NotNullOrEmpty(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or empty. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty([NotNull] string? argument, string? argName)
        {
            NotNullOrEmpty(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or empty. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty([NotNull] string? argument, string? argName, string? message)
        {
            NotNull(argument, argName, message);
            NotEmpty(argument, argName, message);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not empty.
        /// Otherwise throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty(string? argument)
        {
            NotEmpty(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not empty.
        /// Otherwise throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty(string? argument, string? argName)
        {
            NotEmpty(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is not empty.
        /// Otherwise throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty(string? argument, string? argName, string? message)
        {
            if (argument == string.Empty)
            {
                throw new ArgumentEmptyException(argName, message);
            }
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>,
        /// otherwise returns a copy of the incoming collection.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown and <see langword="null"/>
        /// is returned.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        [return: NotNullIfNotNull("argument")]
        public static IList<T>? NotEmpty<T>(IEnumerable<T>? argument)
        {
            return NotEmpty(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>,
        /// otherwise returns a copy of the incoming collection.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown and <see langword="null"/>
        /// is returned.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        [return: NotNullIfNotNull("argument")]
        public static IList<T>? NotEmpty<T>(IEnumerable<T>? argument, string? argName)
        {
            return NotEmpty(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>,
        /// otherwise returns a copy of the incoming collection.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown and <see langword="null"/>
        /// is returned.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        [return: NotNullIfNotNull("argument")]
        public static IList<T>? NotEmpty<T>(IEnumerable<T>? argument, string? argName, string? message)
        {
            if (argument == null)
            {
                return null;
            }

            var list = argument.ToList();

            if (list.Count == 0)
            {
                throw new ArgumentEmptyException(argName, message);
            }

            return list;
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static IList<T> NotNullOrEmpty<T>([NotNull] IEnumerable<T>? argument)
        {
            NotNull(argument);
            return NotEmpty(argument);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static IList<T> NotNullOrEmpty<T>([NotNull] IEnumerable<T>? argument, string argName)
        {
            NotNull(argument, argName);
            return NotEmpty(argument, argName);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <returns>
        /// A copy of the incoming collection or <see langword="null"/>
        /// if the incoming collection is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static IList<T> NotNullOrEmpty<T>([NotNull] IEnumerable<T>? argument, string argName, string message)
        {
            NotNull(argument, argName, message);
            return NotEmpty(argument, argName, message);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(ICollection<T>? argument)
        {
            NotEmpty(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(ICollection<T>? argument, string? argName)
        {
            NotEmpty(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(ICollection<T>? argument, string? argName, string? message)
        {
            if (argument == null)
            {
                return;
            }

            if (argument.Count == 0)
            {
                throw new ArgumentEmptyException(argName, message);
            }
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] ICollection<T>? argument)
        {
            NotNull(argument);
            NotEmpty(argument);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] ICollection<T>? argument, string? argName)
        {
            NotNull(argument, argName);
            NotEmpty(argument, argName);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] ICollection<T>? argument, string? argName, string? message)
        {
            NotNull(argument, argName, message);
            NotEmpty(argument, argName, message);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(IReadOnlyCollection<T>? argument)
        {
            NotEmpty(argument, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(IReadOnlyCollection<T>? argument, string? argName)
        {
            NotEmpty(argument, argName, null);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/> is
        /// not an empty collection. If it is throws an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <remarks>
        /// This method doesn't check the specified <paramref name="argument"/>
        /// on <see langword="null"/>. In other words, if the <paramref name="argument"/>
        /// is <see langword="null"/> no exception is thrown.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotEmpty<T>(IReadOnlyCollection<T>? argument, string? argName, string? message)
        {
            if (argument == null)
            {
                return;
            }

            if (argument.Count == 0)
            {
                throw new ArgumentEmptyException(argName, message);
            }
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] IReadOnlyCollection<T>? argument)
        {
            NotNull(argument);
            NotEmpty(argument);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] IReadOnlyCollection<T>? argument, string? argName)
        {
            NotNull(argument, argName);
            NotEmpty(argument, argName);
        }

        /// <summary>
        /// Checks that the specified <paramref name="argument"/>
        /// is not <see langword="null"/> or an empty collection. Otherwise throws
        /// either an <see cref="ArgumentNullException"/> or an <see cref="ArgumentEmptyException"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argName">The name of the method argument being checked.</param>
        /// <param name="message">
        /// The error message that explains the reason for
        /// failed contract condition.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified <paramref name="argument"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentEmptyException">
        /// Thrown if the specified <paramref name="argument"/> is an empty collection.
        /// </exception>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>([NotNull] IReadOnlyCollection<T>? argument, string? argName, string? message)
        {
            NotNull(argument, argName, message);
            NotEmpty(argument, argName, message);
        }
    }
}