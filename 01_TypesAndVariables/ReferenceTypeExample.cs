using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class ReferenceTypeExample
    {
        [TestMethod]
        public void String()
        {
            string thisIsDeclaration;

            string declared;
            declared = "This is initialized.";

            string declarationAndInitialization = "This is both delcaring and initializing.";

            //Concatenation

            string firstName = "Bobert";
            string lastName = "Billiam";

            string concatenatedFullName = firstName + " " + lastName;
            int age = 112;
            //composite

            string compositeFullName = string.Format("{0} {1}", firstName, lastName);

            //interpolation

            string interpolationFullName = $"{lastName}, {firstName} {lastName}. I am {age}.";
            Console.WriteLine(concatenatedFullName);
            Console.WriteLine(compositeFullName);
            Console.WriteLine(interpolationFullName);
        }
        [TestMethod]
        public void Collections()
        {
            //Arrays
            string stringExample = "Hello, world";
            string[] stringArray = { "Hello", "World", "Why", "si it", "always", stringExample, "?" };
            string thirdItem = stringArray[2];
            Console.WriteLine(thirdItem);
            stringArray[0] = "Hey there";
            Console.WriteLine(stringArray[0]);

            //Lists
            List<string> listOfStrings = new List<string>();
            List<int> listOfIntegers = new List<int>();
            listOfStrings.Add("42");
            listOfIntegers.Add(42);
            Console.WriteLine(listOfIntegers[0]);

            //Queue
            Queue<string> firstInFirstOut = new Queue<string>();
            firstInFirstOut.Enqueue("I'm first.");
            firstInFirstOut.Enqueue("I'm next.");
            Console.WriteLine(firstInFirstOut);
            string firstItem = firstInFirstOut.Dequeue();
            Console.WriteLine(firstItem);

            //Dictionaries
            Dictionary<int, string> keyAndValue = new Dictionary<int, string>();
            keyAndValue.Add(007, "Agent");
            string valueSeven = keyAndValue[007];
            Console.WriteLine(valueSeven);

            //other examples
            SortedList<int, string> sortedKeyAndValue = new SortedList<int, string>();
            HashSet<int> uniqueList = new HashSet<int>();
            Stack<string> lastInFirstOut = new Stack<string>();
        }

        [TestMethod]
        public void Classes()
        {
            Random rng = new Random();
            int randomNum = rng.Next();
            Console.WriteLine(randomNum);
        }
    }
}
