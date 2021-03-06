﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    /// <summary>
    /// Represents an interface that generates 32-bit integer identifiers.
    /// </summary>
    public interface IIntIdentifierGenerator
    {
        /// <summary>
        /// Gets the next 32-bit integer identifier. The implementation must ensure the numbers generated by this method are all different.
        /// </summary>
        /// <returns>A 32-bit interner as an unique identifier if it is successfully generated; otherwise, <c>null</c>.</returns>
        int? Next();

        void Reset();
    }

    /// <summary>
    /// Represents an interface that generates 64-bit integer identifiers.
    /// </summary>
    public interface IInt64IdentifierGenerator
    {
        /// <summary>
        /// Gets the next 64-bit integer identifier. The implementation must ensure the numbers generated by this method are all different.
        /// </summary>
        /// <returns>A 64-bit interner as an unique identifier if it is successfully generated; otherwise, <c>null</c>.</returns>
        long? Next();

        void Reset();
    }
}
