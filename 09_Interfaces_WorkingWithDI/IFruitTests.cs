using System;
using System.Collections.Generic;
using _09_Interfaces_Introduction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _09_Interfaces_WorkingWithDI
{
    [TestClass]
    public class IFruitTests
    {
        [TestMethod]
        public void CallingInterfaceMethods()
        {
            IFruit banana = new Banana();
            var output = banana.Peel();
            Console.WriteLine(output);
            Banana bananaTwo = new Banana();
            var anotherOutput = bananaTwo.Peel();
            Console.WriteLine(anotherOutput);
        }
        [TestMethod]
        public void InterfacesInCollections()
        {
            var orangeObject = new Orange();
            var fruitSalad = new List<IFruit>
            {
                new Banana(),
                new Grape(),
                new Orange(true),
                orangeObject
            };
            foreach(var oneFruit in fruitSalad)
            {
                Console.WriteLine(oneFruit.Name);
                Console.WriteLine(oneFruit.Peel());
                Assert.IsInstanceOfType(oneFruit, typeof(IFruit));
                Assert.IsInstanceOfType(orangeObject, typeof(Orange));
            }
        }
        private string GetFruitName(IFruit fruit)
        {
            return $"This fruit is called a {fruit.Name}.";
        }
        [TestMethod]
        public void InterfacesInMethods()
        {
            var grape = new Grape();
            var output = GetFruitName(grape);
            Console.WriteLine(output);
        }
        [TestMethod]
        public void TypeOfInstance()
        {
            var fruitSalad = new List<IFruit>
            {
                new Grape(),
                new Orange(true),
                new Banana(),
                new Orange(),
                new Banana(),
                new Grape(),
                new Orange(true)
            };
            Console.WriteLine("Is the orange peeled?");
            foreach(var oneFruit in fruitSalad)
            {
                if(oneFruit is Orange orangeObject)// Casting at same time
                {
                    if (orangeObject.IsPeeled)
                    {
                        Console.WriteLine("This is a peeled orange.");
                        Console.WriteLine(orangeObject.Squeeze());
                    }
                    else
                    {
                        Console.WriteLine("Not peeled. Do not squeeze.");
                    }
                }
                else if (oneFruit.GetType() == typeof(Grape))
                {
                    Console.WriteLine("This is a grape");
                    var grape = (Grape)oneFruit;// Example of casting
                }
                else if (oneFruit.IsPeeled)
                {
                    Console.WriteLine("That is a peeled banana.");
                }
                else
                {
                    Console.WriteLine("One unpeeled banana.");
                }
            }
        }
    }
}
