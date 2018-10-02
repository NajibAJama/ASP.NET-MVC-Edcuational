using GigHub.Models;
using GigHub.ViewModels;
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
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
        };


            return View(viewModel);
        }
    }
}