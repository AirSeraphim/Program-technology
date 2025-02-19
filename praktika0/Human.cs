using praktika1.validators;
using System;


namespace praktika1
{
    /// <summary>
    /// Class for storing info about a human
    /// </summary>
    class Human
    {
        public int Height { get; private set; }

        public int Weight { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; }

        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        public int Age
        {
            get
            {
                return (DateTime.Now - Birthday).Days/365;
            }
        }

        public bool SetHeight(int height)
        {
            bool flag = IntValidator.IsBelowZero(height);
            if (flag)
            {
                this.Height = height;
                return flag;
            }
            else
            {
                return flag;
            }
        }
        public Human(int height,
                     int weight,
                     string firstname,
                     string lastname,
                     DateTime birthday) 
        {
            if (IntValidator.IsBelowZero(height))
            {
                throw new ArgumentOutOfRangeException("Рост ниже нуля");
            }
            if (IntValidator.IsBelowZero(weight))
            {
                throw new ArgumentOutOfRangeException("Рост ниже нуля");
            }
            if (StringValidator.IsNotEmpty(firstname))
            {
                throw new ArgumentOutOfRangeException("Рост ниже нуля");
            }
            if (StringValidator.IsNotEmpty(lastname))
            {
                throw new ArgumentOutOfRangeException("Рост ниже нуля");
            }

            Height = height;
            Weight = weight;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
        }
    }
}
