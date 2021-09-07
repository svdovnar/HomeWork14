using System;
using ClassLibrary;

namespace ReflectionAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Person spiderman = new Person("Pe7er", "Parker");
            Person man = new Person("JHON", "$ENA");

            spiderman.IsValid();

            Console.WriteLine();

            man.IsValid();
            
        }

    }
}
