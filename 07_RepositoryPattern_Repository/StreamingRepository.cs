using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07_RepositoryPattern_Repository
{
    public class StreamingRepository : StreamingContentRepository
    {
        public Show GetShowByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Show))
                {
                    return (Show)content;
                }
            }
            return null;
        }
        public Movie GetMovieByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Movie))
                {
                    return (Movie)content;
                }
            }
            return null;
        }
        public List<Show> GetAllShows()
        {
            //make a space to save all shows
            List<Show> allShows = new List<Show>();
            //Pull all shows from my list
            //save the list off to the side
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content is Show)
                {
                    allShows.Add((Show)content);
                }
            }
            //return that list
            return allShows;
        }
        //write GetAllMovies
        //Get by other parameter (famFriendly)
        public List<Movie> GetAllMovies(bool fam)
        {
            List<Movie> friendly = new List<Movie>();

            foreach(StreamingContent content in _contentDirectory)
            {
                if(content is Movie && content.IsFamilyFriendly == fam)
                {
                    friendly.Add((Movie)content);
                }
            }
            return friendly;
        }
        public List<Show> GetAllShowsOverACeratainEpisodeCount(int episodeCount)
        {
            List<Show> finalList = new List<Show>();
            var listOfAllShows = GetAllShows();
            foreach(var eachShow in listOfAllShows)
            {
                if(eachShow.Episodes.Count() >= episodeCount)
                {
                    finalList.Add((Show)eachShow);
                }
            }
            return finalList;
        }
    }
}
