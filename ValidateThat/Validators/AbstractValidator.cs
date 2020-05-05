namespace ValidateThat
{
    /// <summary>
    /// Abstract validation features.
    /// </summary>
    public abstract class AbstractValidator
    {
        /// <summary>
        /// Throws validation exception.
        /// This can be overriden by replacing Validate.Throw method with anything suitable for your project.
        /// </summary>
        public void Throw(string message, string name, object value) => Validate.Throw.Invoke(new ValidationException(message, name, value));
    }
}
