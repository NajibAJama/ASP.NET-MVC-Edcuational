﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required] //foreign key string guid auto generated by database
        public string ArtistId { get; set; }

        [Required]//genere foreign key
        public byte GenreId { get; set; }

        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        //navigation propeirty
        public ApplicationUser Artist { get; set; }

       //navigation propeirty
        public Genre Genre { get; set; }
    }
}