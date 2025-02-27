using System;


namespace Les0.Validators
{
    class StringValidator
    {
        public static bool Validate(string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
