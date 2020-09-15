using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace W1D3Project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrintLetters()
        {
            string testWord = "Supercalifragilisticexpialidocious";
            foreach (char letter in testWord)
            {
                Console.WriteLine(letter);
            }
        }

        [TestMethod]
        public void IsOnly()
        {
            string testWord = "Supercalifragilisticexpialidocious";
            foreach (char x in testWord)
            {
                Console.WriteLine((x == 'i')? x.ToString():"Not an 'i'");
            }
        }

        [TestMethod]
        public void NumOfLetters()
        {
            string testWord = "Supercalifragilisticexpialidocious";
            int counter = 0;
            for (int i = 0; i < testWord.Length; i++)
            {
                if (testWord[i] == 'l')
                {
                    Console.WriteLine(testWord[i]);
                }
                counter++;
            }
            Console.WriteLine(counter);
        }

        [TestMethod]
        public void IsAndLsOnly()
        {
            string testWord = "Supercalifragilisticexpialidocious";
            foreach(char x in testWord)
            {
                Console.WriteLine((x == 'i' || x == 'l') ? x.ToString() : "Not an 'i', or an 'l'.");
            }
        }
    }
}
