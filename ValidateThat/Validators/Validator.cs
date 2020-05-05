namespace ValidateThat
{
    /// <summary>
    /// Validates single argument value.
    /// </summary>
    public class Validator<T> : AbstractValidator
    {
        /// <summary>
        /// Name of argument which is being validated.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of argument which is being validated.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Validator(string name, T value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Returns string "The value of '&lt;field name&gt;' is expected to", which can be used for error messages.
        /// </summary>
        public string ValueIsExpectedTo => $"The value of '{Name}' is expected to";

        /// <summary>
        /// Throws validation exception using known argument name and value.
        /// This can be overriden by replacing Validate.Throw method with anything suitable for your project.
        /// </summary>
        public void Throw(string message) => Throw(message, Name, Value);
    }
}
