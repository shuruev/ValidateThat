using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidateThat
{
    /// <summary>
    /// Common utility methods to use in various validators.
    /// </summary>
    public static class ValidateUtil
    {
        /// <summary>
        /// Wraps string items in quotes and joins them to a comma separated list.
        /// E.g. for [ "a", "b", "c" ] it will return string "'a', 'b', 'c'".
        /// </summary>
        public static string JoinQuotes(IEnumerable<string> items) => String.Join(", ", items.Select(n => $"'{n}'"));
    }
}
