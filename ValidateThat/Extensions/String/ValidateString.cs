using System;
using System.Collections.Generic;
using System.Linq;
using static ValidateThat.ValidateStringUtil;

namespace ValidateThat
{
    /// <summary>
    /// Validation methods for string values.
    /// </summary>
    public static class ValidateString
    {
        /// <summary>
        /// Throws if string is empty.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsNotEmpty(this Validator<string> validator)
        {
            if (validator.Value != null)
            {
                if (String.IsNullOrEmpty(validator.Value))
                    validator.Throw($"{validator.ValueIsExpectedTo} be populated (i.e. not contain just an empty string)");
            }

            return validator;
        }

        /// <summary>
        /// Throws if string contains only whitespace characters.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsNotWhiteSpace(this Validator<string> validator)
        {
            if (validator.Value != null)
            {
                if (String.IsNullOrWhiteSpace(validator.Value))
                    validator.Throw($"{validator.ValueIsExpectedTo} be populated (i.e. not contain only whitespace characters)");
            }

            return validator;
        }

        /// <summary>
        /// Throws if string is empty, contains only whitespace characters, or has whitespace characters at the beginning or at the end of the string.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsWellFormed(this Validator<string> validator)
        {
            if (validator.Value != null)
            {
                validator.IsNotWhiteSpace();

                if (validator.Value.Trim() != validator.Value)
                    validator.Throw($"{validator.ValueIsExpectedTo} not contain whitespace characters at the beginning or at the end of the string, but specified value was '{validator.Value}'");
            }

            return validator;
        }

        /// <summary>
        /// Checks if string contains one of the allowed values, ignoring the case.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsOneOf(this Validator<string> validator, IEnumerable<string> allowedValuesIgnoreCase) => validator.IsOneOf(allowedValuesIgnoreCase.ToArray());

        /// <summary>
        /// Checks if string contains one of the allowed values, ignoring the case.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsOneOf(this Validator<string> validator, params string[] allowedValuesIgnoreCase) => CheckOneOf(validator, allowedValuesIgnoreCase, false);

        /// <summary>
        /// Checks if string contains one of the allowed values, exactly matching the case.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsOneOfExact(this Validator<string> validator, IEnumerable<string> allowedValuesMatchCase) => validator.IsOneOf(allowedValuesMatchCase.ToArray());

        /// <summary>
        /// Checks if string contains one of the allowed values, exactly matching the case.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsOneOfExact(this Validator<string> validator, params string[] allowedValuesMatchCase) => CheckOneOf(validator, allowedValuesMatchCase, true);

        /// <summary>
        /// Checks if string contains only 0-9 numeric characters (e.g. '12345').
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> HasOnlyNumericChars(this Validator<string> validator) => CheckAllowedChars(
            validator,
            IsNumericChar,
            "0-9 numeric characters (e.g. '12345')");

        /// <summary>
        /// Checks if string contains only hexadecimal characters (e.g. '043c26fc' or '043C26FC').
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> HasOnlyHexChars(this Validator<string> validator) => CheckAllowedChars(
            validator,
            IsHexChar,
            "hexadecimal characters (e.g. '043c26fc' or '043C26FC')");

        /// <summary>
        /// Checks if string contains only hexadecimal or dash characters (e.g. '7b58-4923-a4e0' or '7B58-4923-A4E0').
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> HasOnlyGuidChars(this Validator<string> validator) => CheckAllowedChars(
            validator,
            c => IsHexChar(c) || IsAllowedChar(c, '-'),
            "hexadecimal or dash characters (e.g. '7b58-4923-a4e0' or '7B58-4923-A4E0')");

        /// <summary>
        /// Throws if string has too many characters.
        /// Will not throw if the value is null, prepend with IsNotNull() or use Validate.Required(…) when checking required fields.
        /// </summary>
        public static Validator<string> IsNoLongerThan(this Validator<string> validator, int maximumLength)
        {
            if (validator.Value != null)
            {
                if (validator.Value.Length > maximumLength)
                    validator.Throw($"{validator.ValueIsExpectedTo} have a maximum length of {maximumLength}, but specified value had {validator.Value.Length} characters: '{validator.Value}'");
            }

            return validator;
        }
    }
}
