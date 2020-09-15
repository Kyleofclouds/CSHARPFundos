using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Conditionals
{
    [TestClass]
    public class IfElse
    {
        [TestMethod]
        public void IfStatements()
        {
            bool userIsHungry = true;
            if (userIsHungry)
            {
                Console.WriteLine("You should probably eat something");
            }

            int hoursSpentStudying = 4;
            if (hoursSpentStudying < 10)
            {
                Console.WriteLine("Are you even trying?");
            }
        }
        [TestMethod]
        public void MyTestMethod()
        {
            bool choresAreDone = false;
            if (choresAreDone)
            {
                Console.WriteLine("Go play Playstation");
            }
            else
            {
                Console.WriteLine("You need to finish your chores");
            }

            string input = "7";
            int totalHours = int.Parse(input);

            if (totalHours >= 8)
            {
                Console.WriteLine("You should be well-rested.");
                if (totalHours < 3)
                {
                    Console.WriteLine("You should try to get more sleep");
                }
            }

            int age = 5;
            if (age > 17)
            {
                Console.WriteLine("You are an adult");
            }
            else{
                if (age > 12)
                {
                    Console.WriteLine("You are a juvenile");
                }
                else if (age > 2)
                {
                    Console.WriteLine("You are just a little kid");
                }
                else
                {
                    Console.WriteLine("How are you on the computer?");
                }
            }

            if (age < 65 && age > 18)
            {
                Console.WriteLine("Your age is between 19 & 64");
            }

            if (age < 17 || age > 19)
            {
                Console.WriteLine("18 isn't a real age");
            }
        }
    }
}
