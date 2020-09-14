using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Classes
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Person firstPerson = new Person("Bill", "Stefanopolous", new DateTime(1785,02,14), new Vehicle());
            Console.WriteLine(firstPerson.FirstName);
            Console.WriteLine(firstPerson.LastName);
            Console.WriteLine(firstPerson.DateOfBirth);
            Console.WriteLine(firstPerson.Transport);
        }
    }
}
