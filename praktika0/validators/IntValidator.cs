using System;

namespace praktika1.validators
{
    class IntValidator
    {
        static public bool IsBelowZero(int value)
        {
            return value < 0;
        }
    }
}
