﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Operators
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComparisonOperators()
        {
            int age = 142;
            string username = "Sandy";
            bool equals = age == 12;
            bool userIsAdam = username == "Spongebob";

            bool notEqual = age != 1001;
            bool userIsNotPatrick = username != "Patrick";
            bool testBool = false;

            List<string> firstList = new List<string>();
            firstList.Add(username);

            List<string> secondList = new List<string>();
            firstList.Add(username);

            bool listsAreEqual = firstList == secondList;
            //firstList = secondList; no reason to do this. They are references not values.

            bool greaterThan = age > 10;
            //bool greaterThanOrEqual = age >= 142;
            bool greaterThanOrEqual = age <= 9001;
            bool lessThanOrEqual = age <= 142;

            //bool orValue = greaterThan || lessThan;
            bool anotherOr = age < 9005 || username == "banana";

            //bool andValue = greaterThan && lessThan;
            bool anotherAnd = username == "Sandy" && age >= 42;
        }
    }
}
