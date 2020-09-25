using System;
using System.Collections.Generic;
using _08_StreamingContent_Console.UI;
using _10_StreamingContent_UIRefactor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _10_StreamingContent_UIRefactor_Tests
{
    [TestClass]
    public class ProgramUITests
    {
        [TestMethod]
        public void GetList_OutputShouldContainList()
        {
            //Arrange
            List<string> commandList = new List<string> { "1","6"};
            MockConsole console = new MockConsole(commandList);
            ProgramUI programUI = new ProgramUI(console);
            //Act
            programUI.Run();
            Console.WriteLine(console.Output);

            //Assert
            Assert.IsTrue(console.Output.Contains("Your driver for the night is a baby"));
        }
        [TestMethod]
        public void AddToList_ShouldSeeItemInList()
        {
            //Arrange
            var customDesc = "This is my custom thoughts on this movie";
            var commandList = new List<string>
            {
                "3",
                "This is the title",
                customDesc,
                "42",
                "3",
                "4",
                "1",
                "6"
            };
            var mockConsole = new MockConsole(commandList);
            var ui = new ProgramUI(mockConsole);
            //Act
            ui.Run();
            Console.WriteLine(mockConsole.Output);
            //Assert
            Assert.IsTrue(mockConsole.Output.Contains(customDesc));
        }
        [TestMethod]
        public void RemoveFromList_ShouldSeeRemovedMessage()
        {
            //Arrange
            var commandList = new List<string>
            {
                "4",
                "3",
                "6"
            };
            var fakeConsole = new MockConsole(commandList);
            var ui = new ProgramUI(fakeConsole);
            //Act
            ui.Run();
            Console.WriteLine(fakeConsole.Output);
            //Assert
            Assert.IsTrue(fakeConsole.Output.Contains("Another Movie successfully removed"));
        }
    }
}
