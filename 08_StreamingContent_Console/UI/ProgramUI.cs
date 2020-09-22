using _07_RepositoryPattern_Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Console.UI
{
    class ProgramUI
    {
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select: \n" +
                    "1) Show all streaming content. \n" +
                    "2) Find by title \n" +
                    "3) Add new content \n" +
                    "4) Remove Content \n" +
                    "5) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show all
                        //get all shows
                        //get all movies
                        //get show movie/by title
                        ShowAllContent();
                        break;
                    case "2":
                        //Find by title
                        break;
                    case "3":
                        //Add new
                        CreateNewContent();
                        break;
                    case "4":
                        //Remove
                        break;
                    case "5":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.WriteLine("Please enter a valid number between 1 & 5. \n" +
                            "press any key to continue........");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void CreateNewContent()
        {
            //a new content object
            StreamingContent content = new StreamingContent();
            //ask user for information
            //Title
            Console.WriteLine("Please enter the title of the new content: ");
            content.Title = Console.ReadLine();
            //Description
            Console.WriteLine($"Please enter a description for {content.Title}");
            content.Description = Console.ReadLine();
            //StarRating
            Console.WriteLine($"Please enter the star rating for {content.Title}");
            content.StarRating = float.Parse(Console.ReadLine());
            //MatuirityRating
            Console.WriteLine("Select a Maturity Rating: \n" +
                "1)G \n" +
                "2)PG \n" +
                "3)PG 12 \n" +
                "4)R \n" +
                "5)NC 17 \n" +
                "6)MA \n");
            string maturityResponse = Console.ReadLine();
            switch (maturityResponse)
            {
                case "1":
                    content.MaturityRatin = MaturityRating.G;
                    break;
                case "2":
                    content.MaturityRatin = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRatin = MaturityRating.PG_13;
                    break;
                case "4":
                    content.MaturityRatin = MaturityRating.R;
                    RemoveContentFromList();
                    break;
                case "5":
                    content.MaturityRatin = MaturityRating.NC_17;
                    break;
                case "6":
                    content.MaturityRatin = MaturityRating.MA;
                    break;
            }
            //TypeOfGenre
            Console.WriteLine("Select a genre: \n" +
                "1) Horror \n" +
                "2)RomCom \n" +
                "3)Fantasy \n" +
                "4)Sci-Fi \n" +
                "5)Drama \n" +
                "6)Bromance \n" +
                "7)Action \n"+
                "8)Documentary \n"+
                "9)Thriller \n");
            string genResponse = Console.ReadLine();
            int genreID = int.Parse(genResponse);
            content.TypeOfGenre = (GenreType)genreID;
            //a new content with properties filled out by user
            //pass that to the add emthod in our repo
            _streamingRepo.AddContentToDirectory(content);
        }
        private void ShowAllContent()
        {
            Console.Clear();
            //Get all items from our fake database
            List<StreamingContent> listOfContents = _streamingRepo.GetContent();
            //Take each item from fake database and display property values
            foreach(StreamingContent content in listOfContents)
            {
                DisplaySimple(content);
            }
            //Puase the program so the user can see the printed objects
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //Show all items in our fake database

        }
        private void DisplaySimple(StreamingContent content)
        {
            Console.WriteLine($"{content.Title} \n" +
                    $"{content.Description} \n" +
                    "-----------------");
        }
        private void DisplayAllProps(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title} \n" +
                $"Description: {content.Description} \n" +
                $"Genre: {content.TypeOfGenre} \n"+
                $"Stars: {content.StarRating} \n"+
                $"Content is family friendly {content.IsFamilyFriendly} \n"+
                $"Matruity Rating: {content.MaturityRatin} \n");
        }
        private void SeedContent()
        {
            var titleOne = new StreamingContent("Toy Story", "Toys have a story", 4.5f, MaturityRating.PG, false, GenreType.Bromance);
            var titleTwo = new StreamingContent("Star Wars", "Empires and such", 4.0f, MaturityRating.PG_13, true, GenreType.Action);
            var titleThree = new StreamingContent("Hannibal", "Life of a cannibal", 5f, MaturityRating.R, true, GenreType.Thriller);
            var titleFour = new StreamingContent("Enter the Dragon", "Bruce Lee stuff", 5f, MaturityRating.PG_13, false, GenreType.Documentary);
            var titleFive = new StreamingContent("Harry Potter", "Story of a harry potter", 4.5f, MaturityRating.PG, false, GenreType.Fantasy);
            _streamingRepo.AddContentToDirectory(titleOne);
            _streamingRepo.AddContentToDirectory(titleTwo);
            _streamingRepo.AddContentToDirectory(titleThree);
            _streamingRepo.AddContentToDirectory(titleFour);
            _streamingRepo.AddContentToDirectory(titleFive);
        }
        /*private void FindByTitle()
        {
            List<StreamingContent> listOfContents = _streamingRepo.GetContent();
            Console.WriteLine("Enter the title of the content you are searching for: ");
            string title = Console.ReadLine();
            StreamingContent found;
            bool isWithin = false;
            foreach(StreamingContent content in listOfContents)
            {
                if(content.Title.ToLower() == title.ToLower())
                {
                    found = content;
                    isWithin = true;
                }
            }
            if (isWithin)
            {
                DisplayAllProps(found);
            }
            else
            {
                Console.WriteLine($"{title} was not found in the repository.");
            }
        }*/
        private void ShowContentByTitle()//Same as above
        {
            Console.Clear();
            //Show only one object found by title
            //Step one: get title from user
            Console.WriteLine("Enter the title: ");
            string title = Console.ReadLine();
            //Use title to find the ONE object
            StreamingContent foundContent = _streamingRepo.GetContentByTitle(title);
            //If object found, display data / if not, inform user that title does not exist
            if (foundContent != null)
            {
                DisplayAllProps(foundContent);
            }
            else
            {
                Console.WriteLine("There are no titles that matched the one you gave me.");
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        private void RemoveContentFromList()
        {
            //prompt the user
            Console.WriteLine("Which item would you like to remove?");
            //need a list of items
            List<StreamingContent> contentList = _streamingRepo.GetContent();
            int count = 0;
            foreach(var content in contentList)
            {
                count++;
                Console.WriteLine($"{count}) {content.Title}");
            }
            //take in user response
            int targetContentID = int.Parse(Console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[correctIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Title} successfully removed.");
                }
                else
                {
                    Console.WriteLine($"Was not able to remove {desiredContent.Title}.");
                }
            }
            else
            {
                Console.WriteLine("INVALID OPTION");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            //Remove that item
        }
        private List<StreamingContent> GetAllShows()
        {
            List<StreamingContent> content = _streamingRepo.GetContent();
            List<StreamingContent> listOfShows = new List<StreamingContent>();
            foreach(StreamingContent maybeShow in content)
            {
                if (maybeShow is Show)
                {
                    listOfShows.Add(maybeShow);
                }
            }
            return listOfShows;
        }
    }
}
