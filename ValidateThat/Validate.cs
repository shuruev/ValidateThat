using System;
using System.Linq.Expressions;

namespace ValidateThat
{
    /// <summary>
    /// Validates input arguments, members, fields etc.
    /// Use Validate.Throw to override which exception should be thrown when validation error occurs.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Validates single field, specifying its name via expression.
        /// E.g. Validate.That(() => person.LastName).Is…();
        /// </summary>
        public static Validator<T> That<T>(Expression<Func<T>> value)
        {
            var name = ExtractName(value);
            return new Validator<T>(name, value.Compile().Invoke());
        }

        /// <summary>
        /// Tries to extract name from specified expression.
        /// </summary>
        private static string ExtractName<T>(Expression<Func<T>> value)
        {

            if (value?.Body != null)
            {
                var text = value.Body.ToString();
                var index = text.IndexOf(")", 0, StringComparison.Ordinal);
                if (index > 0)
                {
                    return text.Substring(index + 1).Trim('.');
                }
            }

            throw new InvalidOperationException("Unknown expression used for validation");
        }

        /// <summary>
        /// Defines what to do when validation error occurs, will throw ValidationException by default.
        /// Override this method to change which exception to throw on validation error.
        /// E.g. Validate.Throw = e => throw new MyException(e.Message, e.Name, e);
        /// </summary>
        public static Action<ValidationException> Throw { get; set; } = e => throw e;
    }
}
