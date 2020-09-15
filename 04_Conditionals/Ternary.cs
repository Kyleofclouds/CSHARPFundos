using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Conditionals
{
    [TestClass]
    public class Ternary
    {
        [TestMethod]
        public void Ternaries()
        {
            int age = 31;
            //(conditional/boolean) ? trueResult:falseResult;
            bool isAdult = (age > 17) ? true : false;

            int numOne = 10; //think of this as a user input
            string output = (numOne == 10) ? "You guessed correctly" : "You did not guess correctly.";
            Console.WriteLine((output =="You guessed correctly") ? "Congrats" : "Try again");
        }
    }
}
