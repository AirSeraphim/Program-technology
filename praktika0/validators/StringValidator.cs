using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika1.validators
{
    class StringValidator
    {
        static public bool IsNotEmpty(string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
