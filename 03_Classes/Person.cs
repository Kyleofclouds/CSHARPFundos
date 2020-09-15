using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        //behind the scenese stuff
        private string myVar;

        public string _lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        //end of behind the scenes stuff
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Vehicle Transport { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DateOfBirth;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOfAge;
            }
        }

        public Person() { }
        public Person(string firstName, string lastName, DateTime dob, Vehicle transport)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Transport = transport;
        }

    }
}
