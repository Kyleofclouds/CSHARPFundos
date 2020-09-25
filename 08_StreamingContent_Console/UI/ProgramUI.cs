using _07_RepositoryPattern_Repository;
using _10_StreamingContent_UIRefactor;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        public ProgramUI(IConsole console)
        {
            _console = console;
        }
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
                _console.Clear();//don't know what this is
                _console.WriteLine("Enter the number of the option you'd like to select: \n" +
                    "1) Show all streaming content. \n" +
                    "2) Find by title \n" +
                    "3) Add new content \n" +
                    "4) Remove Content \n" +
                    "5) Show All Movies \n" +
                    "6) Exit");
                string userInput = _console.ReadLine();
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
                        //show all movies
                        ShowAllMovies();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        //default
                        _console.WriteLine("Please enter a valid number between 1 & 5. \n" +
                            "press any key to continue........");
                        _console.ReadKey();
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
            _console.WriteLine("Please enter the title of the new content: ");
            content.Title = _console.ReadLine();
            //Description
            _console.WriteLine($"Please enter a description for {content.Title}");
            content.Description = _console.ReadLine();
            //StarRating
            _console.WriteLine($"Please enter the star rating for {content.Title}");
            content.StarRating = float.Parse(_console.ReadLine());
            //MatuirityRating
            _console.WriteLine("Select a Maturity Rating: \n" +
                "1)G \n" +
                "2)PG \n" +
                "3)PG 12 \n" +
                "4)R \n" +
                "5)NC 17 \n" +
                "6)MA \n");
            string maturityResponse = _console.ReadLine();
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
            _console.WriteLine("Select a genre: \n" +
                "1) Horror \n" +
                "2)RomCom \n" +
                "3)Fantasy \n" +
                "4)Sci-Fi \n" +
                "5)Drama \n" +
                "6)Bromance \n" +
                "7)Action \n"+
                "8)Documentary \n"+
                "9)Thriller \n");
            string genResponse = _console.ReadLine();
            int genreID = int.Parse(genResponse);
            content.TypeOfGenre = (GenreType)genreID;
            //a new content with properties filled out by user
            //pass that to the add emthod in our repo
            _streamingRepo.AddContentToDirectory(content);
        }
        private void ShowAllContent()
        {
            _console.Clear();
            //Get all items from our fake database
            List<StreamingContent> listOfContents = _streamingRepo.GetContent();
            //Take each item from fake database and display property values
            foreach(StreamingContent content in listOfContents)
            {
                DisplaySimple(content);
            }
            //Puase the program so the user can see the printed objects
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
            //Show all items in our fake database

        }
        private void DisplaySimple(StreamingContent content)
        {
            _console.WriteLine($"{content.Title} \n" +
                    $"{content.Description} \n" +
                    "-----------------");
        }
        private void DisplayAllProps(StreamingContent content)
        {
            _console.WriteLine($"Title: {content.Title} \n" +
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

            Movie movieOne = new Movie();
            Movie movieTwo = new Movie("Venom", "Two Bros", 9001, MaturityRating.NC_17, true, GenreType.RomCom, 123);
            Movie movieThree = new Movie("Another Movie", "Test Data", 1, MaturityRating.NC_17, true, GenreType.RomCom, 123);
            _streamingRepo.AddContentToDirectory(movieOne);
            _streamingRepo.AddContentToDirectory(movieTwo);
            _streamingRepo.AddContentToDirectory(movieThree);

            _streamingRepo.AddContentToDirectory(titleOne);
            _streamingRepo.AddContentToDirectory(titleTwo);
            _streamingRepo.AddContentToDirectory(titleThree);
            _streamingRepo.AddContentToDirectory(titleFour);
            _streamingRepo.AddContentToDirectory(titleFive);
        }
        /*private void FindByTitle()
        {
            List<StreamingContent> listOfContents = _streamingRepo.GetContent();
            _console.WriteLine("Enter the title of the content you are searching for: ");
            string title = _console.ReadLine();
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
                _console.WriteLine($"{title} was not found in the repository.");
            }
        }*/
        private void ShowContentByTitle()//Same as above
        {
            _console.Clear();
            //Show only one object found by title
            //Step one: get title from user
            _console.WriteLine("Enter the title: ");
            string title = _console.ReadLine();
            //Use title to find the ONE object
            StreamingContent foundContent = _streamingRepo.GetContentByTitle(title);
            //If object found, display data / if not, inform user that title does not exist
            if (foundContent != null)
            {
                DisplayAllProps(foundContent);
            }
            else
            {
                _console.WriteLine("There are no titles that matched the one you gave me.");
            }
            _console.WriteLine("Press any key to continue.....");
            _console.ReadKey();
        }
        private void RemoveContentFromList()
        {
            //prompt the user
            _console.WriteLine("Which item would you like to remove?");
            //need a list of items
            List<StreamingContent> contentList = _streamingRepo.GetContent();
            int count = 0;
            foreach(var content in contentList)
            {
                count++;
                _console.WriteLine($"{count}) {content.Title}");
            }
            //take in user response
            int targetContentID = int.Parse(_console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[correctIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Title} successfully removed.");
                }
                else
                {
                    _console.WriteLine($"Was not able to remove {desiredContent.Title}.");
                }
            }
            else
            {
                _console.WriteLine("INVALID OPTION");
            }
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
            
            //Remove that item
        }
        private void ShowAllMovies()
        {
            _console.Clear();
            //Get all the movies
            List<Movie> listOfMovies = _streamingRepo.GetAllMovies();
            foreach(var oneMovie in listOfMovies)
            {
                DisplaySimple(oneMovie);
            }
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }
        //challenge below
       /* private List<StreamingContent> GetAllShows()
        {
            List<StreamingContent> content = _streamingRepo.GetContent();
            List<StreamingContent> listOfShows = new List<StreamingContent>();
            foreach(StreamingContent maybeShow in content)
            {
                if (maybeShow is Show)
                {
                    listOfShows.Add((Show)maybeShow);
                }
            }
            return listOfShows;
        }*/
    }
}
