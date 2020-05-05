namespace ValidateThat
{
    /// <summary>
    /// Validation methods for nullable values.
    /// </summary>
    public static class ValidateNullable
    {
        /// <summary>
        /// Throws if value is null.
        /// </summary>
        public static Validator<T> IsNotNull<T>(this Validator<T> validator) where T : class
        {
            if (validator.Value == null)
                validator.Throw($"{validator.ValueIsExpectedTo} be specified (i.e. not be null)");

            return validator;
        }

        /// <summary>
        /// Throws if value is null.
        /// </summary>
        public static Validator<T?> IsNotNull<T>(this Validator<T?> validator) where T : struct
        {
            if (validator.Value == null)
                validator.Throw($"{validator.ValueIsExpectedTo} be specified (i.e. not be null)");

            return validator;
        }
    }
}
