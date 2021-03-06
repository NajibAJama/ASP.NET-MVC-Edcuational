﻿using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Gigs
        //initialize _context
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        //create view model and set the genera properties
        [Authorize]//control who can see this page 
        //will only allow loged in user aka artist
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };


            return View(viewModel);
        }

        [Authorize]
        [HttpPost]//called only by http post method
        public ActionResult Create(GigFormViewModel viewModel)
            //mvc will touch each property of a viewmodel 
            //convert problematic properties to methods so it won't touch it
            //as it uses refelection to inspect those properties
        {
            if(!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
            //these two send two quries to the database not good. 
            //var artist = _context.Users.Single(u => u.Id == artistID);
            //var genere = _context.Genres.Where(g => g.Id == viewModel.Genre).Single();
            ////convert viewmodel to gig object and save to context
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}