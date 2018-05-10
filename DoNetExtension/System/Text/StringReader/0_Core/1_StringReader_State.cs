using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Provides rich methods to extract information from a string instance, with a state property and related methods to facilitate construction of an automaton.
    /// </summary>
    /// <typeparam name="TState">The type of the state object.</typeparam>
    /// <seealso cref="System.StringReader" />
    public class StringReader<TState> : StringReader
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader{TState}" /> class.
        /// </summary>
        /// <param name="initialState">Provides the initial state.</param>
        /// <param name="endState">Provides the end state.</param>
        /// <param name="s">The string instance to read.</param>
        /// <param name="startIndex">Specifies the initial position of the reader.</param>
        /// <param name="length">Specifies the maximum number of characters this reader can read from its initial position.
        /// This argument together with <paramref name="startIndex" /> determines this reader's reading scope.</param>
        public StringReader(TState initialState, TState endState, string s, int startIndex, int length) : base(s, startIndex, length)
        {
            InitialState = initialState;
            EndState = endState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader{TState}" /> class.
        /// </summary>
        /// <param name="initialState">Provides the initial state.</param>
        /// <param name="endState">Provides the end state.</param>
        /// <param name="s">The string instance to read.</param>
        /// <param name="startIndex">Specifies the initial position of the reader.</param>
        public StringReader(TState initialState, TState endState, string s, int startIndex = 0): base(s, startIndex)
        {
            InitialState = initialState;
            EndState = endState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader{TState}" /> class from a <see cref="StringReader" /> instance. This constructor copies <see cref="StringReader.UnderlyingString" />, <see cref="StringReader.CurrentPosition" />, <see cref="StringReader.EndPosition" /> and <see cref="StringReader.ComparisonType" /> of <paramref name="reader" /> to the new instance, but does not copy <see cref="StringReader.MarkedPosition" /> property.
        /// </summary>
        /// <param name="initialState">Provides the initial state.</param>
        /// <param name="endState">Provides the end state.</param>
        /// <param name="reader">Provides a <see cref="StringReader" /> instance.</param>
        public StringReader(TState initialState, TState endState, StringReader reader) : base(reader)
        {
            InitialState = initialState;
            EndState = endState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader{TState}" /> class.
        /// </summary>
        /// <param name="initialState">Provides the initial state.</param>
        /// <param name="endState">Provides the end state.</param>
        /// <param name="s">The string instance to read.</param>
        /// <param name="comparisonType">Specifies a <see cref="StringComparison" /> value for string comparisons in various methods of the <see cref="StringReader" /> class.</param>
        public StringReader(TState initialState, TState endState, string s, StringComparison comparisonType) : base(s, comparisonType)
        {
            InitialState = initialState;
            EndState = endState;
        }

        #endregion

        /// <summary>
        /// Gets the reading state.
        /// </summary>
        /// <value>The reading state.</value>
        public TState State { get; private set; }

        /// <summary>
        /// Gets the initial state of this <see cref="StringReader{TState}"/>.
        /// </summary>
        /// <value>The initial state of this <see cref="StringReader{TState}"/>.</value>
        public TState InitialState { get; private set; }

        /// <summary>
        /// Gets the end state of this <see cref="StringReader{TState}"/>.
        /// </summary>
        /// <value>The end state of this <see cref="StringReader{TState}"/>.</value>
        public TState EndState { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="StringReader{TState}"/> is at its end state.
        /// </summary>
        /// <value><c>true</c> if this <see cref="StringReader{TState}"/> is at its end state; otherwise, <c>false</c>.</value>
        public bool EOS { get { return State.Equals(EndState); } }

        /// <summary>
        /// Sets the reading state.
        /// </summary>
        /// <param name="state">An object representing the reading state.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetState(TState state)
        {
            State = state;
        }

        /// <summary>
        /// Resets this <see cref="StringReader{TState}"/> to its initial state.
        /// </summary>
        public void Reset()
        {
            State = InitialState;
        }


        /// <summary>
        /// Advances the reader to the position of the first non-whitespace character in the reader's scope. The <see cref="State"/> will be set to <paramref name="epsilonState"/> if the current reading scope is empty or contains only whitespace characters, and set to <paramref name="nonEpsilonState"/> otherwise.
        /// </summary>
        /// <param name="epsilonState">The state to set if the current reading scope is empty or contains only whitespace characters.</param>
        /// <param name="nonEpsilonState">The state to set if the current reading scope contains at least one non-whitespace character.</param>
        public void Advance(TState epsilonState, TState nonEpsilonState)
        {
            TrimStart();
            if (EOF) State = epsilonState;
            else State = nonEpsilonState;
        }

        /// <summary>
        /// Reads the first non-whitespace character in the reader's scope and advances the reader to the position after the first non-whitespace character. The <see cref="State"/> will be set to <paramref name="epsilonState"/> if the current reading scope is empty or contains only whitespace characters, and set to <paramref name="nonEpsilonState"/> otherwise.
        /// </summary>
        /// <param name="epsilonState">The state to set if the current reading scope is empty or contains only whitespace characters.</param>
        /// <param name="nonEpsilonState">The state to set if the current reading scope contains at least one non-whitespace character.</param>
        /// <returns>If there eists a non-whitespace character in the reader's scope, this method returns the first non-whitespace character; otherwise, this method returns '\0'.</returns>
        public char Read(TState epsilonState, TState nonEpsilonState)
        {
            if (EOF)
            {
                State = epsilonState;
                return '\0';
            }
            else
            {
                while (UnderlyingString[CurrentPosition].IsWhiteSpace())
                {
                    ++CurrentPosition;
                    if (EOF)
                    {
                        State = epsilonState;
                        return '\0';
                    }
                }

                State = nonEpsilonState;
                return UnderlyingString[CurrentPosition++];
            }
        }


    }
}
