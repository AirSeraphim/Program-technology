using Les0.Validators;
using System;

namespace Les0
{
    /// <summary>
    /// Information about person
    /// </summary>

    class Person
    {
        public Person(
            int height, 
            int weight, 
            string firstname, 
            string lastname, 
            DateTime birthday)
        {
            if (!IntValidator.Validate(height))
                throw new ArgumentOutOfRangeException("");
            if (!IntValidator.Validate(weight))
                throw new ArgumentOutOfRangeException("");
            if (!StringValidator.Validate(firstname))
                throw new ArgumentException("");
            if (!StringValidator.Validate(lastname))
                throw new ArgumentException("");
            Height = height;
            Weight = weight;
            BirthDay = birthday;
            FirstName = firstname;
            LastName = lastname;
        }
        public int Height { get; private set; }

        public int Weight { get; private set; }
        
        public string FirstName { get; private set; }
        
        public string LastName { get; private set;  }

        public DateTime BirthDay { get; }
        
        public string FullName 
        {
            get 
            {
                return FirstName + " " + LastName;
            }
        }
        
        public int Age
        {
            get 
            {
                return (DateTime.Now - BirthDay).Days /365;
            }
        }

        public bool ChangeHeight(int height) 
        {
            bool flag = IntValidator.Validate(Height);
            if (flag)
                this.Height = Height;
            return flag;
        }
    }
}
