using System;
using System.Linq;
using static ValidateThat.ValidateUtil;

namespace ValidateThat
{
    /// <summary>
    /// Utility methods to use in string validators.
    /// </summary>
    public static class ValidateStringUtil
    {
        /// <summary>
        /// Used to check if string contains one of the allowed values, with or without matching the case.
        /// </summary>
        public static Validator<string> CheckOneOf(Validator<string> validator, string[] allowedValues, bool matchCase)
        {
            if (validator.Value != null)
            {
                var comparison = matchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                var description = matchCase ? "matching the case" : "ignoring the case";

                if (allowedValues.Any(v => String.Compare(validator.Value, v, comparison) != 0))
                    validator.Throw($"{validator.ValueIsExpectedTo} be one of the following: [{JoinQuotes(allowedValues)}] ({description}), but specified value was '{validator.Value}'");
            }

            return validator;
        }

        /// <summary>
        /// Used to check if string contains only characters conforming some specified criteria.
        /// </summary>
        public static Validator<string> CheckAllowedChars(Validator<string> validator, Func<char, bool> checkCharacter, string description)
        {
            if (validator.Value != null)
            {
                if (!validator.Value.All(checkCharacter))
                    validator.Throw($"{validator.ValueIsExpectedTo} only have {description}");
            }

            return validator;
        }

        /// <summary>
        /// Returns true only for numeric characters from '0' to '9'.
        /// </summary>
        public static bool IsNumericChar(char c) => c >= '0' && c <= '9';

        /// <summary>
        /// Returns true only for ASCII characters from 'a' to 'z', or 'A' to 'Z'.
        /// </summary>
        public static bool IsAsciiChar(char c) => c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';

        /// <summary>
        /// Returns true only for hexadecimal characters from '0' to '9', or 'a' to 'f', or 'A' to 'F'.
        /// </summary>
        public static bool IsHexChar(char c) => IsNumericChar(c) || c >= 'a' && c <= 'f' || c >= 'A' && c <= 'F';

        /// <summary>
        /// Returns true only for specified list of allowed characters.
        /// </summary>
        public static bool IsAllowedChar(char c, params char[] allowedChars) => allowedChars.Contains(c);
    }
}
