using Les0;
using System;

namespace les0
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new(161, 50, "Adolf", "Shwars", DateTime.Parse("12.12.1221"));
                person.ChangeHeight(1787);
            Console.WriteLine();
        }
    }
}
