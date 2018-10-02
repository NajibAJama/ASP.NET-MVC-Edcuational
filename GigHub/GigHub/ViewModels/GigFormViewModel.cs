using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        //for drop down list we need numeric value for each option
        //this int will be genre Id.
        public int Genre { get; set; }
        //list of genere from the database
        //we wont add anything to this list or use it's options 
        //using index.(list and collections are unecesory)
        public IEnumerable<Genre> Genres  { get; set; }

    }
}