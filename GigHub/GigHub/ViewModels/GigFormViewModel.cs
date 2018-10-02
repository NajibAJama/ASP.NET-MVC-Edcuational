using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        //for drop down list we need numeric value for each option
        //this int will be genre Id.
        public byte Genre { get; set; }
        //list of genere from the database
        //we wont add anything to this list or use it's options 
        //using index.(list and collections are unecesory)
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime()
        {
           return DateTime.Parse(string.Format("{0} {1}", Date, Time)); 
        }
    }
}