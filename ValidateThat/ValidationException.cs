using System;

namespace ValidateThat
{
    /// <summary>
    /// Validation exception.
    /// Use Validate.Throw to override this exception with any other suitable approach for your project.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Name of argument which is being validated.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of argument which is being validated.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ValidationException(string message, string name, object value)
            : base(message)
        {
            Name = name;
            Value = value;
        }
    }
}
