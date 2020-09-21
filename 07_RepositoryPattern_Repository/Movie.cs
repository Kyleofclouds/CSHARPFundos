using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class Movie : StreamingContent
    {
        public double RunTime { get; set; }

        public Movie()
        {

        }
        public Movie(string title, string description, float starRating, MaturityRating mRatin, bool famFriendly, GenreType tOG, double runTime):base(title,description ,starRating, mRatin, famFriendly, tOG)
        {
            RunTime = runTime;
        }
    }
}
