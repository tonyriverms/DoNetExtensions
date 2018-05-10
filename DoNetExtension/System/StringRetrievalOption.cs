using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Provides options for string retrieval.
    /// </summary>
    public class StringRetrievalOption
    {
        /// <summary>
        /// Indicating where to start to search the locator.
        /// </summary>
        public int StartIndex;
        /// <summary>
        /// Delimits the beginning of the retrieval area.
        /// </summary>
        public string Locator;
        /// <summary>
        /// Delimits the end of the retrieval area.
        /// </summary>
        public string Boundary;
        /// <summary>
        /// Indicates the start of the string to retrieve.
        /// </summary>
        public string[] StartIndicator;
        /// <summary>
        /// Indicates the end of the string to retrieve.
        /// </summary>
        public string[] EndIndicator;
        /// <summary>
        /// Set this true if the start indicator should be included in the retrieved string; otherwise, false.
        /// </summary>
        public bool IncludeStartIndicator;
        /// <summary>
        /// Set this true if the end indicator should be included in the retrieved string; otherwise, false.
        /// </summary>
        public bool IncludeEndIndicator;
        /// <summary>
        /// Indicates at most how many strings are retrieved.
        /// </summary>
        public int MaximumReturn;


        /// <summary>
        /// Initializes a new instance of System.StringRetrievalOption class.
        /// </summary>
        public StringRetrievalOption() { }

        /// <summary>
        /// Initializes a new instance of System.StringRetrievalOption class.
        /// </summary>
        /// <param name="startIndicator">Indicates the start of the string to retrieve.</param>
        /// <param name="endIndicator">Indicates the end of the string to retrieve.</param>
        /// <param name="maximumReturn">Indicates at most how many strings are retrieved.</param>
        public StringRetrievalOption(string[] startIndicator, string[] endIndicator, int maximumReturn = int.MaxValue)
        {
            StartIndicator = startIndicator;
            EndIndicator = endIndicator;
            MaximumReturn = maximumReturn;
        }

        /// <summary>
        /// Initializes a new instance of System.StringRetrievalOption class.
        /// </summary>
        /// <param name="startIndicator">Indicates the start of the string to retrieve.</param>
        /// <param name="endIndicator">Indicates the end of the string to retrieve.</param>
        /// <param name="maximumReturn">Indicates at most how many strings are retrieved.</param>
        public StringRetrievalOption(string startIndicator, string endIndicator, int maximumReturn = int.MaxValue)
        {
            StartIndicator = new string[] { startIndicator };
            EndIndicator = new string[] { endIndicator };
            MaximumReturn = maximumReturn;
        }

        /// <summary>
        /// Initializes a new instance of System.StringRetrievalOption class.
        /// </summary>
        /// <param name="startIndicator">Indicates the start of the string to retrieve.</param>
        /// <param name="endIndicator">Indicates the end of the string to retrieve.</param>
        /// <param name="maximumReturn">Indicates at most how many strings are retrieved.</param>
        public StringRetrievalOption(string[] startIndicator, string endIndicator, int maximumReturn = int.MaxValue)
        {
            StartIndicator = startIndicator;
            EndIndicator = new string[] { endIndicator };
            MaximumReturn = maximumReturn;
        }

        /// <summary>
        /// Initializes a new instance of System.StringRetrievalOption class.
        /// </summary>
        /// <param name="startIndicator">Indicates the start of the string to retrieve.</param>
        /// <param name="endIndicator">Indicates the end of the string to retrieve.</param>
        /// <param name="maximumReturn">Indicates at most how many strings are retrieved.</param>
        public StringRetrievalOption(string startIndicator, string[] endIndicator, int maximumReturn = int.MaxValue)
        {
            StartIndicator = new string[] { startIndicator };
            EndIndicator = endIndicator;
            MaximumReturn = maximumReturn;
        }

    }
}
