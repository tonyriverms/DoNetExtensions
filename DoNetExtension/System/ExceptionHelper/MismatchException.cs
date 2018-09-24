using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using DoNetExtension.System;

namespace System
{
    /// <summary>
    /// The exception that is thrown when a character mismatch is found in a string. Many formated string require matches of quotes or brackets (like <c>{</c> and <c>}</c>, <c>[</c> and <c>]</c>, etc.).
    /// </summary>
    public class CharacterMismatchException : FormatException
    {
        /// <summary>
        /// Gets the position of the character that is mismatched.
        /// </summary>
        /// <value>The position of the mismatched target.</value>
        public int MatchTargetPosition { get; private set; }

        /// <summary>
        /// Gets the character that is mismatched.
        /// </summary>
        /// <value>The mismatched target character.</value>
        public char MatchTarget { get; private set; }

        /// <summary>
        /// Gets the missing character that should have matched <see cref="MatchTarget"/>.
        /// </summary>
        /// <value>The missing match.</value>
        public char MissingMatch { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterMismatchException"/> class.
        /// </summary>
        /// <param name="matchTargetPosition">The position of the target character that is mismatched.</param>
        /// <param name="matchTarget">The target character that should be matched.</param>
        /// <param name="missingMatch">The missing match.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a <c>null</c> reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public CharacterMismatchException(int matchTargetPosition, char matchTarget, char missingMatch, Exception innerException)
            : this(GeneralResources.ERR_MisMatch.Scan(matchTarget, matchTargetPosition), matchTargetPosition, matchTarget, missingMatch, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterMismatchException"/> class.
        /// </summary>
        /// <param name="message">The message string that explains the mismatch error.</param>
        /// <param name="matchTargetPosition">The position of the target character that is mismatched.</param>
        /// <param name="matchTarget">The target character that should be matched.</param>
        /// <param name="missingMatch">The missing match.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a <c>null</c> reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public CharacterMismatchException(string message, int matchTargetPosition, char matchTarget, char missingMatch, Exception innerException)
            : base(message, innerException)
        {
            MatchTargetPosition = matchTargetPosition;
            MatchTarget = matchTarget;
            MissingMatch = missingMatch;
        }
    }

    /// <summary>
    /// The exception that is thrown when a string mismatch is found in a string. A similar exception is <see cref="CharacterMismatchException"/> that handles character mismatch.
    /// </summary>
    public class StringMismatchException : FormatException
    {
        /// <summary>
        /// Gets the position of the substring that is mismatched.
        /// </summary>
        /// <value>The position of the mismatched target.</value>
        public int MatchTargetPosition { get; private set; }

        /// <summary>
        /// Gets the substring that is mismatched.
        /// </summary>
        /// <value>The mismatched target substring.</value>
        public string MatchTarget { get; private set; }

        /// <summary>
        /// Gets the missing string that should have matched <see cref="MatchTarget"/>.
        /// </summary>
        /// <value>The missing match.</value>
        public string MissingMatch { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringMismatchException"/> class.
        /// </summary>
        /// <param name="matchTargetPosition">The position of the target substring that is mismatched.</param>
        /// <param name="matchTarget">The target substring that should be matched.</param>
        /// <param name="missingMatch">The missing match.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a <c>null</c> reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public StringMismatchException(int matchTargetPosition, string matchTarget, string missingMatch, Exception innerException)
            : this(GeneralResources.ERR_MisMatch.Scan(matchTarget, matchTargetPosition), matchTargetPosition, matchTarget, missingMatch, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringMismatchException"/> class.
        /// </summary>
        /// <param name="message">The message string that explains the mismatch error.</param>
        /// <param name="matchTargetPosition">The position of the target substring that is mismatched.</param>
        /// <param name="matchTarget">The target substring that should be matched.</param>
        /// <param name="missingMatch">The missing match.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a <c>null</c> reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public StringMismatchException(string message, int matchTargetPosition, string matchTarget, string missingMatch, Exception innerException)
            : base(message, innerException)
        {
            MatchTargetPosition = matchTargetPosition;
            MatchTarget = matchTarget;
            MissingMatch = missingMatch;
        }
    }
}
