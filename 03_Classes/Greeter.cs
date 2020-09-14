using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    class Greeter
    {//The first example is an overload case of SayHello().
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello there, {name}");
        }
        public void SayHello()
        {
            Console.WriteLine("Hello, stranger");
        }
        Random rando = new Random();
        public void GetRandomGreeting()
        {
            string[] availableGreetings = new string[] { "Hello", "Howdy", "'Sup", "Hola", "Hi, y'all", "Guten Tag", "Hello there", "Ni hao" };
            int randomNumber = rando.Next(0, availableGreetings.Length);
            string randoGreeting = availableGreetings[randomNumber];
            Console.WriteLine(randoGreeting);
        }
    }
}
